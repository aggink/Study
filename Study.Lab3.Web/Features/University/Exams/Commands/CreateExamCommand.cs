using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;
using Study.Lab3.Web.Features.University.Exams.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Exams.Commands;

/// <summary>
/// Создание экзамена
/// </summary>
public sealed class CreateExamCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные экзамена
    /// </summary>
    [Required]
    [FromBody]
    public CreateExamDto Exam { get; init; }
}

public sealed class CreateExamCommandHandler : IRequestHandler<CreateExamCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IExamService _examService;

    public CreateExamCommandHandler(
        DataContext dataContext,
        IExamService examService)
    {
        _dataContext = dataContext;
        _examService = examService;
    }

    public async Task<Guid> Handle(CreateExamCommand request, CancellationToken cancellationToken)
    {
        var exam = new Exam
        {
            IsnExam = Guid.NewGuid(),
            IsnSubject = request.Exam.IsnSubject,
            Name = request.Exam.Name,
            Description = request.Exam.Description,
            ExamDate = request.Exam.ExamDate,
            Duration = request.Exam.Duration,
            MaxScore = request.Exam.MaxScore,
            PassingScore = request.Exam.PassingScore
        };

        await _examService.CreateOrUpdateExamValidateAndThrowAsync(
            _dataContext, exam, cancellationToken);

        await _dataContext.Exams.AddAsync(exam, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return exam.IsnExam;
    }
}