using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Sweets.Sweet.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Sweets.Sweet.Commands;

/// <summary>
/// Обновление таблицы сладостей
/// </summary>
public sealed class UpdateSweetCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные сладости
    /// </summary>
    [Required]
    [FromBody]
    public UpdateSweetDto Sweet { get; init; }
}

public sealed class UpdateSweetCommandHandler : IRequestHandler<UpdateSweetCommand, Guid>
{
    private readonly DataContext _dataContext;

    public UpdateSweetCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Guid> Handle(UpdateSweetCommand request, CancellationToken cancellationToken)
    {
        var sweet = await _dataContext.Sweets
                           .FirstOrDefaultAsync(c => c.IsnSweet == request.Sweet.IsnSweet, cancellationToken)
                       ?? throw new BusinessLogicException(
                           $"Сладости с идентификатором \"{request.Sweet.IsnSweet}\" не существует");

        sweet.IsnSweet = request.Sweet.IsnSweet;
        sweet.Name = request.Sweet.Name;
        sweet.IsnSweetType = request.Sweet.IsnSweetType;
        sweet.Ingredients = request.Sweet.Ingredients;

        await _dataContext.SaveChangesAsync(cancellationToken);
        return sweet.IsnSweet;
    }
}