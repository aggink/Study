using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Workshop;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Workshop.Masters.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Workshop.Masters.Commands;

/// <summary>
/// Обновление мастера
/// </summary>
public sealed class UpdateMasterCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные мастера
    /// </summary>
    [Required]
    [FromBody]
    public UpdateMasterDto Master { get; init; }
}

public sealed class UpdateMasterCommandHandler : IRequestHandler<UpdateMasterCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IMasterService _masterService;

    public UpdateMasterCommandHandler(
        DataContext dataContext,
        IMasterService masterService)
    {
        _dataContext = dataContext;
        _masterService = masterService;
    }

    public async Task<Guid> Handle(UpdateMasterCommand request, CancellationToken cancellationToken)
    {
        var master = await _dataContext.Masters
                         .FirstOrDefaultAsync(x => x.IsnMaster == request.Master.IsnMaster, cancellationToken)
                     ?? throw new BusinessLogicException(
                         $"Мастер с идентификатором \"{request.Master.IsnMaster}\" не существует");

        master.Name = request.Master.Name;
        master.Email = request.Master.Email;
        master.Phone = request.Master.Phone;
        master.Specialization = request.Master.Specialization;

        await _masterService.CreateOrUpdateMasterValidateAndThrowAsync(
            _dataContext, master, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return master.IsnMaster;
    }
}
