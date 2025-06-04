using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TheCareer.Commands;

/// <summary>
/// ”даление карьеры
/// </summary>
public sealed class DeleteCareerCommand : IRequest
{
    /// <summary>
    /// »дентификатор карьеры
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnCareer { get; init; }
}

public sealed class DeleteCareerCommandHandler : IRequestHandler<DeleteCareerCommand>
{
    private readonly DataContext _dataContext;
    private readonly ICareerService _careerService;

    public DeleteCareerCommandHandler(
        DataContext dataContext,
        ICareerService careerService)
    {
        _dataContext = dataContext;
        _careerService = careerService;
    }

    public async Task Handle(DeleteCareerCommand request, CancellationToken cancellationToken)
    {
        var career = await _dataContext.Career
            .Include(x => x.Subject)
            .FirstOrDefaultAsync(x => x.IsnCareer == request.IsnCareer, cancellationToken)
                ?? throw new BusinessLogicException($"—обеседовани¤ с идентификатором \"{request.IsnCareer}\" не существует");

        await _careerService.CanDeleteAndThrowAsync(
            _dataContext, career, cancellationToken);

        _dataContext.Career.Remove(career);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}