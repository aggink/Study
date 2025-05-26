/*using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Exams.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Exams.Commands;

/// <summary>
/// Обновление экзамена
/// </summary>
public sealed class UpdateExamCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные экзамена
    /// </summary>
    [Required]
    [FromBody]
    public UpdateExamDto Exam { get; init; }
}

public sealed class UpdateExamCommandHandler : IRequestHandler<UpdateExamCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IExamService _examService;

    public UpdateExamCommandHandler(
        DataContext dataContext,
        IExamService examService)
    {
        _dataContext = dataContext;
        _examService = examService;
    }

    public async Task<Guid> Handle(UpdateExamCommand request, CancellationToken cancellationToken)
    {
        var exam = await _dataContext.Exams
                       .FirstOrDefaultAsync(x => x.IsnExam == request.Exam.IsnExam, cancellationToken)
                   ?? throw new BusinessLogicException($"Экзамен с идентификатором \"{request.Exam.IsnExam}\" не существует");

        exam.Name = request.Exam.Name;
        exam.Description = request.Exam.Description;
        exam.ExamDate = request.Exam.ExamDate;
        exam.Duration = request.Exam.Duration;
        exam.MaxScore = request.Exam.MaxScore;
        exam.PassingScore = request.Exam.PassingScore;

        await _examService.CreateOrUpdateExamValidateAndThrowAsync(
            _dataContext, exam, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return exam.IsnExam;
    }
}*/