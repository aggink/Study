using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
<<<<<<< HEAD
using Study.Lab3.Web.Features.Sweets.Sweets.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Sweets.Sweets.Queries;
=======
using Study.Lab3.Web.Features.Sweets.Sweet.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Sweets.Sweet.Queries;
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117

/// <summary>
/// Получение сладости по идентификатору
/// </summary>
public sealed class GetSweetByIdQuery : IRequest<SweetDto>
{
    /// <summary>
    /// Идентификатор cладости
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnSweet { get; init; }
}

public sealed class GetSweetByIdQueryHandler : IRequestHandler<GetSweetByIdQuery, SweetDto>
{
    private readonly DataContext _dataContext;

    public GetSweetByIdQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<SweetDto> Handle(GetSweetByIdQuery request, CancellationToken cancellationToken)
    {
        var sweet = await _dataContext.Sweets
                           .AsNoTracking()
                           .FirstOrDefaultAsync(c => c.IsnSweet == request.IsnSweet, cancellationToken)
                       ?? throw new BusinessLogicException(
                           $"Сладость с идентификатором \"{request.IsnSweet}\" не существует");

        return new SweetDto
        {
            IsnSweet = sweet.IsnSweet,
            Name = sweet.Name,
            IsnSweetType = sweet.IsnSweetType,
            Ingredients = sweet.Ingredients,
        };
    }
}