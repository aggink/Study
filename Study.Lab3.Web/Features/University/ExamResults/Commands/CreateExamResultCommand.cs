using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Enums.University;
using Study.Lab3.Storage.Models.University;
using Study.Lab3.Web.Features.University.ExamResults.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.ExamResults.Commands;

/// <summary>
/// Создание результата экзамена
/// </summary>
public sealed class CreateExamResultCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные результата
    /// </summary>
    [Required]
    [FromBody]
    public CreateExamResultDto Result { get; init; }
}

public sealed class CreateExamResultCommandHandler : IRequestHandler<CreateExamResultCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IExamResultService _resultService;

    public CreateExamResultCommandHandler(
        DataContext dataContext,
        IExamResultService resultService)
    {
        _dataContext = dataContext;
        _resultService = resultService;
    }

    public async Task<Guid> Handle(CreateExamResultCommand request, CancellationToken cancellationToken)
    {
        var result = new ExamResult
        {
            IsnExamResult = Guid.NewGuid(),
            IsnExamRegistration = request.Result.IsnExamRegistration,
            Score = request.Result.Score,
            Comments = request.Result.Comments,
            IsPassed = false // Будет установлено в сервисе валидации
        };

        await _resultService.CreateOrUpdateResultValidateAndThrowAsync(
            _dataContext, result, cancellationToken);

        await _dataContext.ExamResults.AddAsync(result, cancellationToken);

        // Обновляем статус регистрации на "Completed"
        var registration = await _dataContext.ExamRegistrations
            .FirstOrDefaultAsync(x => x.IsnExamRegistration == request.Result.IsnExamRegistration, cancellationToken);
        if (registration != null)
        {
            registration.Status = RegistrationStatus.Completed;
        }

        await _dataContext.SaveChangesAsync(cancellationToken);

        return result.IsnExamResult;
    }
}