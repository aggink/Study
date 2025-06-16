using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Labs.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Labs.Queries;

/// <summary>
/// Получить группу по идентификатору
/// </summary>
public sealed class GetLabByIsnQuery : IRequest<LabDto>
{
    /// <summary>
    /// Идентификатор группы
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnLab { get; init; }
}

public sealed class GetLabByIsnQueryHandler : IRequestHandler<GetLabByIsnQuery, LabDto>
{
    private readonly DataContext _dataContext;

    public GetLabByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<LabDto> Handle(GetLabByIsnQuery request, CancellationToken cancellationToken)
    {
        var lab = await _dataContext.Labs
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.IsnLab == request.IsnLab, cancellationToken)
                ?? throw new BusinessLogicException($"Группы с идентификатором \"{request.IsnLab}\" не существует");

        return new LabDto
        {
            IsnLab = lab.IsnLab,
            Name = lab.Name
        };
    }
}
