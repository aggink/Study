using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.GameStore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.GameStore;
using Study.Lab3.Web.Features.GameStore.Developers.DtoModels;

namespace Study.Lab3.Web.Features.GameStore.Developers.Commands;

/// <summary>
/// Создание разработчика
/// </summary>
public sealed class CreateDeveloperCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные разработчика
    /// </summary>
    [Required]
    [FromBody]
    public CreateDeveloperDto Developer { get; init; }
}

public sealed class CreateDeveloperCommandHandler : IRequestHandler<CreateDeveloperCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IDeveloperService _developerService;

    public CreateDeveloperCommandHandler(
        DataContext dataContext,
        IDeveloperService developerService)
    {
        _dataContext = dataContext;
        _developerService = developerService;
    }

    public async Task<Guid> Handle(CreateDeveloperCommand request, CancellationToken cancellationToken)
    {
        var developer = new Developer
        {
            IsnDeveloper = Guid.NewGuid(),
            CompanyName = request.Developer.CompanyName,
            Country = request.Developer.Country,
            FoundedDate = request.Developer.FoundedDate,
            Website = request.Developer.Website,
            ContactEmail = request.Developer.ContactEmail,
            IsActive = request.Developer.IsActive,
            Description = request.Developer.Description
        };

        await _developerService.CreateOrUpdateDeveloperValidateAndThrowAsync(
            _dataContext, developer, cancellationToken);

        await _dataContext.Developers.AddAsync(developer, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return developer.IsnDeveloper;
    }
}