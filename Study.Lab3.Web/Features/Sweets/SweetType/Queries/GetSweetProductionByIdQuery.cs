using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Sweets.SweetFactories.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Sweets.SweetTypes.Queries;
/// <summary>
/// Получение сладости по идентификатору
/// </summary>
public sealed class GetSweetFactoryByIdQuery : IRequest<SweetFactoryDto>
{
    /// <summary>
    /// Идентификатор cладости
    /// </summary>
    [Required]
    [FromQuery]
    public  Int64 FactoryID { get; init; }
}

public sealed class GetSweetFactoryByIdQueryHandler : IRequestHandler<GetSweetFactoryByIdQuery, SweetFactoryDto>
{
    private readonly DataContext _dataContext;

    public GetSweetFactoryByIdQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<SweetFactoryDto> Handle(GetSweetFactoryByIdQuery request, CancellationToken cancellationToken)
    {
        var sweetfactory = await _dataContext.SweetFactories
                           .AsNoTracking()
                           .FirstOrDefaultAsync(c => c.ID == request.ID, cancellationToken)
                       ?? throw new BusinessLogicException(
                           $"Фабрика с идентификатором \"{request.ID}\" не существует");

        return new SweetFactoryDto
        {
            ID = sweetfactory.ID,
            Name = sweetfactory.Name,
            Address = sweetfactory.Address,
            Volume = sweetfactory.Volume,
        };
    }
}