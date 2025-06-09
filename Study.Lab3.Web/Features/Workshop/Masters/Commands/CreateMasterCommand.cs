using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.Workshop;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Workshop;
using Study.Lab3.Web.Features.Workshop.Masters.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Workshop.Masters.Commands;

/// <summary>
/// Создание мастера
/// </summary>
public sealed class CreateMasterCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные мастера
    /// </summary>
    [Required]
    [FromBody]
    public CreateMasterDto Master { get; init; }
}

public sealed class CreateMasterCommandHandler : IRequestHandler<CreateMasterCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IMasterService _masterService;

    public CreateMasterCommandHandler(
        DataContext dataContext,
        IMasterService masterService)
    {
        _dataContext = dataContext;
        _masterService = masterService;
    }

    public async Task<Guid> Handle(CreateMasterCommand request, CancellationToken cancellationToken)
    {
        var master = new Master
        {
            IsnMaster = Guid.NewGuid(),
            Name = request.Master.Name,
            Email = request.Master.Email,
            Phone = request.Master.Phone,
            Specialization = request.Master.Specialization
        };

        await _masterService.CreateOrUpdateMasterValidateAndThrowAsync(
            _dataContext, master, cancellationToken);

        await _dataContext.Masters.AddAsync(master, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return master.IsnMaster;
    }
}