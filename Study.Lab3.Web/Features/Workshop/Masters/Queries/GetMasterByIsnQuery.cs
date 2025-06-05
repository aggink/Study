using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Workshop.Masters.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Workshop.Masters.Queries;

/// <summary>
/// Получить мастера по идентификатору
/// </summary>
public sealed class GetMasterByIsnQuery : IRequest<MasterDto>
{
    /// <summary>
    /// Идентификатор мастера
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnMaster { get; init; }
}

public sealed class GetMasterByIsnQueryHandler : IRequestHandler<GetMasterByIsnQuery, MasterDto>
{
    private readonly DataContext _dataContext;

    public GetMasterByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<MasterDto> Handle(GetMasterByIsnQuery request, CancellationToken cancellationToken)
    {
        var master = await _dataContext.Masters
                         .AsNoTracking()
                         .FirstOrDefaultAsync(x => x.IsnMaster == request.IsnMaster, cancellationToken)
                     ?? throw new BusinessLogicException(
                         $"Мастер с идентификатором \"{request.IsnMaster}\" не существует");

        return new MasterDto
        {
            IsnMaster = master.IsnMaster,
            Name = master.Name,
            Email = master.Email,
            Phone = master.Phone,
            Specialization = master.Specialization
        };
    }
}