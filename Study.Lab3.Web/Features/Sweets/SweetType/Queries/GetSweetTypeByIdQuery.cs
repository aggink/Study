using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Sweets.SweetFactories.DtoModels;
using Study.Lab3.Web.Features.Sweets.SweetTypes.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Sweets.SweetTypes.Queries;

/// <summary>
/// Получение сладости по идентификатору
/// </summary>
public sealed class GetSweetTypeByIdQuery : IRequest<SweetTypeDto>
{
    /// <summary>
    /// Идентификатор cладости
    /// </summary>
    [Required]
    [FromQuery]
    public Guid ID { get; init; }
}

public sealed class GetSweetTypeByIdQueryHandler : IRequestHandler<GetSweetTypeByIdQuery, SweetTypeDto>
{
    private readonly DataContext _dataContext;

    public GetSweetTypeByIdQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<SweetTypeDto> Handle(GetSweetTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var sweettype = await _dataContext.SweetTypes
                           .AsNoTracking()
                           .FirstOrDefaultAsync(c => c.IsnSweetType == request.ID, cancellationToken)
                       ?? throw new BusinessLogicException(
                           $"Фабрика с идентификатором \"{request.ID}\" не существует");

        return new SweetTypeDto
        {
            IsnSweetType = sweettype.IsnSweetType,
            Name = sweettype.Name,
        };
    }
}