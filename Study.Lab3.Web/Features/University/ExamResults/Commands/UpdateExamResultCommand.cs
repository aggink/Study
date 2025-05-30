using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.ExamResults.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.ExamResults.Commands;

/// <summary>
/// Обновление результата экзамена
/// </summary>
public sealed class UpdateExamResultCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные результата
    /// </summary>
    [Required]
    [FromBody]
    public UpdateExamResultDto Result { get; init; }
}

public sealed class UpdateExamResultCommandHandler : IRequestHandler<UpdateExamResultCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IExamResultService _resultService;

    public UpdateExamResultCommandHandler(
        DataContext dataContext,
        IExamResultService resultService)
    {
        _dataContext = dataContext;
        _resultService = resultService;
    }

    public async Task<Guid> Handle(UpdateExamResultCommand request, CancellationToken cancellationToken)
    {
        var result = await _dataContext.ExamResults
                         .FirstOrDefaultAsync(x => x.IsnExamResult == request.Result.IsnExamResult, cancellationToken)
                     ?? throw new BusinessLogicException($"Результат с идентификатором \"{request.Result.IsnExamResult}\" не существует");

        result.Score = request.Result.Score;
        result.Comments = request.Result.Comments;

        await _resultService.CreateOrUpdateResultValidateAndThrowAsync(
            _dataContext, result, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return result.IsnExamResult;
    }
}