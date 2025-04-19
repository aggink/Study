using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Groups.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Groups.Queries;

/// <summary>
/// Получить группу по идентификатору
/// </summary>
public sealed class GetGroupByIsnQuery : IRequest<GroupDto>
{
    /// <summary>
    /// Идентификатор группы
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnGroup { get; init; }
}

public sealed class GetGroupByIsnQueryHandler : IRequestHandler<GetGroupByIsnQuery, GroupDto>
{
    private readonly DataContext _dataContext;

    public GetGroupByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<GroupDto> Handle(GetGroupByIsnQuery request, CancellationToken cancellationToken)
    {
        var group = await _dataContext.Groups
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.IsnGroup == request.IsnGroup, cancellationToken)
                ?? throw new BusinessLogicException($"Группы с идентификатором \"{request.IsnGroup}\" не существует");

        return new GroupDto
        {
            IsnGroup = group.IsnGroup,
            Name = group.Name
        };
    }
}
