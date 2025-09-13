using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.PoliceDepartament.Officer.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.PoliceDepartament.Officer.Queries;

public sealed class GetOfficerByIsnQuery : IRequest<OfficerDto>
{
    [Required]
    [FromQuery]
    public Guid IsnOfficer { get; init; }
}

public sealed class GetOfficerByIsnQueryHandler : IRequestHandler<GetOfficerByIsnQuery, OfficerDto>
{
    private readonly DataContext _dataContext;

    public GetOfficerByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<OfficerDto> Handle(GetOfficerByIsnQuery request, CancellationToken cancellationToken)
    {
        var officer = await _dataContext.Officers
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.IsnOfficer == request.IsnOfficer, cancellationToken)
                ?? throw new BusinessLogicException($"Стажера с идентификатором \"{request.IsnOfficer}\" не существует");

        return new OfficerDto
        {
            IsnOfficer = officer.IsnOfficer,
            Name = officer.Name,
            SurName = officer.SurName,
            Rank = officer.Rank
        };
    }
}
