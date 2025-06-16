using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;
using Study.Lab3.Web.Features.University.Labs.DtoModels;
using System.ComponentModel.DataAnnotations;
namespace Study.Lab3.Web.Features.University.Labs.Commands;

/// <summary>
/// Создание группы
/// </summary>
public sealed class CreateStudentLabCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные группы
    /// </summary>
    [FromBody]
    [Required]
    public CreateStudentLabDto StudentLab { get; init; }
}

public sealed class CreateStudentLabCommandHandler : IRequestHandler<CreateStudentLabCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly ILabService _labService;

    public CreateStudentLabCommandHandler(
        DataContext dataContext,
        ILabService labService)
    {
        _dataContext = dataContext;
        _labService = labService;
    }

    public async Task<Guid> Handle(CreateStudentLabCommand request, CancellationToken cancellationToken)
    {
        var studentlab = new StudentLab
        {
            IsnStudentLab = Guid.NewGuid(),
            IsnLab = request.StudentLab.IsnLab,
            IsnStudent = request.StudentLab.IsnStudent,
            Value = request.StudentLab.Value
        };

        await _labService.CreateOrUpdateStudentLabValidateAndThrowAsync(
            _dataContext, studentlab, cancellationToken);

        await _dataContext.StudentLab.AddAsync(studentlab, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return studentlab.IsnStudentLab;
    }
}
