using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Subjects.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Subjects.Commands;

/// <summary>
/// Редактирование данных предмета
/// </summary>
public sealed class UpdateSubjectCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные предмета
    /// </summary>
    [Required]
    [FromBody]
    public UpdateSubjectDto Subject { get; init; }
}

public sealed class UpdateSubjectCommandHandler : IRequestHandler<UpdateSubjectCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly ISubjectService _subjectService;

    public UpdateSubjectCommandHandler(
        DataContext dataContext,
        ISubjectService subjectService)
    {
        _dataContext = dataContext;
        _subjectService = subjectService;
    }

    public async Task<Guid> Handle(UpdateSubjectCommand request, CancellationToken cancellationToken)
    {
        var subject = await _dataContext.Subjects.FirstOrDefaultAsync(x => x.IsnSubject == request.Subject.IsnSubject, cancellationToken)
            ?? throw new BusinessLogicException($"Предмета с идентификатором \"{request.Subject.IsnSubject}\" не существует");

        subject.Name = request.Subject.Name;

        await _subjectService.CreateOrUpdateSubjectAndThrowAsync(
            _dataContext, subject, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);

        return subject.IsnSubject;
    }
}
