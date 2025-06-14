using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.GameStore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.GameStore.Developers.DtoModels;

namespace Study.Lab3.Web.Features.GameStore.Developers.Commands;

/// <summary>
/// Обновление разработчика
/// </summary>
public sealed class UpdateDeveloperCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные разработчика
    /// </summary>
    [Required]
    [FromBody]
    public UpdateDeveloperDto Developer { get; init; }
}

public sealed class UpdateDeveloperCommandHandler : IRequestHandler<UpdateDeveloperCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IDeveloperService _developerService;

    public UpdateDeveloperCommandHandler(
        DataContext dataContext,
        IDeveloperService developerService)
    {
        _dataContext = dataContext;
        _developerService = developerService;
    }

    public async Task<Guid> Handle(UpdateDeveloperCommand request, CancellationToken cancellationToken)
    {
        var developer = await _dataContext.Developers
                            .FirstOrDefaultAsync(x => x.IsnDeveloper == request.Developer.IsnDeveloper,
                                cancellationToken)
                        ?? throw new BusinessLogicException(
                            $"Разработчик с идентификатором \"{request.Developer.IsnDeveloper}\" не существует");

        developer.CompanyName = request.Developer.CompanyName;
        developer.Country = request.Developer.Country;
        developer.FoundedDate = request.Developer.FoundedDate;
        developer.Website = request.Developer.Website;
        developer.ContactEmail = request.Developer.ContactEmail;
        developer.IsActive = request.Developer.IsActive;
        developer.Description = request.Developer.Description;

        await _developerService.CreateOrUpdateDeveloperValidateAndThrowAsync(
            _dataContext, developer, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return developer.IsnDeveloper;
    }
}