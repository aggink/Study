using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;
using Study.Lab3.Web.Features.University.Subjects.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Subjects.Commands;

/// <summary>
/// Создать предмет
/// </summary>
public sealed class CreateSubjectCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные предмета
    /// </summary>
    [Required]
    [FromBody]
    public CreateSubjectDto Subject { get; init; }
}

public sealed class CreateSubjectCommandHandler : IRequestHandler<CreateSubjectCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly ISubjectService _subjectService;

    public CreateSubjectCommandHandler(
        DataContext dataContext,
        ISubjectService subjectService)
    {
        _dataContext = dataContext;
        _subjectService = subjectService;
    }

    public async Task<Guid> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
    {
        var subject = new Subject
        {
            IsnSubject = Guid.NewGuid(),
            Name = request.Subject.Name,
        };

        await _subjectService.CreateOrUpdateSubjectAndThrowAsync(
            _dataContext, subject, cancellationToken);

        await _dataContext.Subjects.AddAsync(subject, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return subject.IsnSubject;
    }
}