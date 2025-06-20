using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Sweets.SweetType.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Sweets.SweetType.Commands;

/// <summary>
/// Обновление таблицы сладостей
/// </summary>
public sealed class UpdateSweetTypeCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные сладости
    /// </summary>
    [Required]
    [FromBody]
    public UpdateSweetTypeDto SweetType { get; init; }
}

public sealed class UpdateSweetTypeCommandHandler : IRequestHandler<UpdateSweetTypeCommand, Guid>
{
    private readonly DataContext _dataContext;

    public UpdateSweetTypeCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Guid> Handle(UpdateSweetTypeCommand request, CancellationToken cancellationToken)
    {
        var sweettype = await _dataContext.SweetTypes
                           .FirstOrDefaultAsync(c => c.IsnSweetType == request.SweetType.IsnSweetType, cancellationToken)
                       ?? throw new BusinessLogicException(
                           $"Фабрики с идентификатором \"{request.SweetType.IsnSweetType}\" не существует");

        sweettype.IsnSweetType = request.SweetType.IsnSweetType;
        sweettype.Name = request.SweetType.Name;

        await _dataContext.SaveChangesAsync(cancellationToken);
        return sweettype.IsnSweetType;
    }
}