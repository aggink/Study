/*using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Enums.University;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.ExamResults.Commands;

/// <summary>
/// Удаление результата экзамена
/// </summary>
public sealed class DeleteExamResultCommand : IRequest
{
    /// <summary>
    /// Идентификатор результата
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnExamResult { get; init; }
}

public sealed class DeleteExamResultCommandHandler : IRequestHandler<DeleteExamResultCommand>
{
    private readonly DataContext _dataContext;
    private readonly IExamResultService _resultService;

    public DeleteExamResultCommandHandler(
        DataContext dataContext,
        IExamResultService resultService)
    {
        _dataContext = dataContext;
        _resultService = resultService;
    }

    public async Task Handle(DeleteExamResultCommand request, CancellationToken cancellationToken)
    {
        var result = await _dataContext.ExamResults
                         .Include(x => x.Registration)
                         .FirstOrDefaultAsync(x => x.IsnExamResult == request.IsnExamResult, cancellationToken)
                     ?? throw new BusinessLogicException($"Результат с идентификатором \"{request.IsnExamResult}\" не существует");

        await _resultService.CanDeleteAndThrowAsync(
            _dataContext, result, cancellationToken);
        
        _dataContext.ExamResults.Remove(result);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}*/