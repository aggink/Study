using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Exams.Commands;

/// <summary>
/// Удаление экзамена
/// </summary>
public sealed class DeleteExamCommand : IRequest
{
    /// <summary>
    /// Идентификатор экзамена
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnExam { get; init; }
}

public sealed class DeleteExamCommandHandler : IRequestHandler<DeleteExamCommand>
{
    private readonly DataContext _dataContext;
    private readonly IExamService _examService;

    public DeleteExamCommandHandler(
        DataContext dataContext,
        IExamService examService)
    {
        _dataContext = dataContext;
        _examService = examService;
    }

    public async Task Handle(DeleteExamCommand request, CancellationToken cancellationToken)
    {
        var exam = await _dataContext.Exams
                       .FirstOrDefaultAsync(x => x.IsnExam == request.IsnExam, cancellationToken)
                   ?? throw new BusinessLogicException($"Экзамен с идентификатором \"{request.IsnExam}\" не существует");

        await _examService.CanDeleteAndThrowAsync(
            _dataContext, exam, cancellationToken);

        _dataContext.Exams.Remove(exam);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}