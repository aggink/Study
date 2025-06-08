using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
<<<<<<< HEAD
using Study.Lab3.Web.Features.University.TheCareer.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TheCareer.Commands;
=======
using Study.Lab3.Web.Features.University.Career.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Career.Commands;
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117

/// <summary>
/// Редактирование карьеры
/// </summary>
public sealed class UpdateCareerCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные карьеры
    /// </summary>
    [Required]
    [FromBody]
    public UpdateCareerDto Career { get; init; }
}

public sealed class UpdateCareerCommandHandler : IRequestHandler<UpdateCareerCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly ICareerService _careerService;

    public UpdateCareerCommandHandler(
        DataContext dataContext,
        ICareerService careerService)
    {
        _dataContext = dataContext;
        _careerService = careerService;
    }

    public async Task<Guid> Handle(UpdateCareerCommand request, CancellationToken cancellationToken)
    {
        var career = await _dataContext.Career
            .Include(x => x.Subject)
            .FirstOrDefaultAsync(x => x.IsnCareer == request.Career.IsnCareer, cancellationToken)
                ?? throw new BusinessLogicException($"Собеседования с идентификатором \"{request.Career.IsnCareer}\" не существует");

        career.ParticipantsCount = request.Career.ParticipantsCount;
        career.CareerDate = request.Career.CareerDate;

        await _careerService.CreateOrUpdateCareerValidateAndThrowAsync(
            _dataContext, career, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return career.IsnCareer;
    }
}