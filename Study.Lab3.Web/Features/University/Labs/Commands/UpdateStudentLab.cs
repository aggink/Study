using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Labs.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Labs.Commands;

/// <summary>
/// Редактирование группы
/// </summary>
public sealed class UpdateStudentLabCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные группы
    /// </summary>
    [Required]
    [FromBody]
    public UpdateStudentLabDto StudentLab { get; init; }
}

public sealed class UpdateStudentLabCommandHandler : IRequestHandler<UpdateStudentLabCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly ILabService _labService;

    public UpdateStudentLabCommandHandler(
        DataContext dataContext,
        ILabService labService)
    {
        _dataContext = dataContext;
        _labService = labService;
    }

    public async Task<Guid> Handle(UpdateStudentLabCommand request, CancellationToken cancellationToken)
    {
        var studentlab = await _dataContext.StudentLab.FirstOrDefaultAsync(x => x.IsnStudentLab == request.StudentLab.IsnStudentLab, cancellationToken)
            ?? throw new BusinessLogicException($"Группы с идентификатором \"{request.StudentLab.IsnStudentLab}\" не существует");

        studentlab.Value = request.StudentLab.Value;

        await _labService.CreateOrUpdateStudentLabValidateAndThrowAsync(
            _dataContext, studentlab, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return studentlab.IsnStudentLab;
    }
}
