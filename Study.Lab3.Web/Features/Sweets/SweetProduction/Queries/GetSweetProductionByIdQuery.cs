using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Sweets;
using Study.Lab3.Web.Features.Sweets.SweetFactories.DtoModels;
using Study.Lab3.Web.Features.Sweets.SweetProductions.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Sweets.SweetProductions.Queries;

/// <summary>
/// Получение по идентификатору фабрики
/// </summary>
public sealed class GetSweetProductionByIdQuery : IRequest<SweetProductionDto>
{
    /// <summary>
    /// Идентификатор фабрики
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnFactory { get; init; }
}

public sealed class GetSweetProductionByIdQueryHandler : IRequestHandler<GetSweetProductionByIdQuery, SweetProductionDto>
{
    private readonly DataContext _dataContext;

    public GetSweetProductionByIdQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<SweetProductionDto> Handle(GetSweetProductionByIdQuery request, CancellationToken cancellationToken)
    {
        var sweetproduction = await _dataContext.SweetProductions
                           .AsNoTracking()
                           .FirstOrDefaultAsync(c => c.IsnSweetFactory == request.IsnFactory, cancellationToken)
                       ?? throw new BusinessLogicException(
                           $"Фабрика с идентификатором \"{request.IsnFactory}\" не существует");

        return new SweetProductionDto
        {
            IsnFactory = sweetproduction.IsnSweetFactory,
            IsnSweet = sweetproduction.IsnSweet
        };
    }
}