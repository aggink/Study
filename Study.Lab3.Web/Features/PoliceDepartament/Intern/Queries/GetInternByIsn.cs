using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.PoliceDepartament.Intern.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.PoliceDepartament.Intern.Queries;

public sealed class GetInternByIsnQuery : IRequest<InternDto>
{
    [Required]
    [FromQuery]
    public Guid IsnIntern { get; init; }
}

public sealed class GetInternByIsnQueryHandler : IRequestHandler<GetInternByIsnQuery, InternDto>
{
    private readonly DataContext _dataContext;

    public GetInternByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<InternDto> Handle(GetInternByIsnQuery request, CancellationToken cancellationToken)
    {
        var intern = await _dataContext.Interns
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.IsnIntern == request.IsnIntern, cancellationToken)
                ?? throw new BusinessLogicException($"Стажера с идентификатором \"{request.IsnIntern}\" не существует");

        return new InternDto
        {
            IsnIntern = intern.IsnIntern,
            Name = intern.Name,
            SurName = intern.SurName,
            SkillLevel = intern.SkillLevel
        };
    }
}
