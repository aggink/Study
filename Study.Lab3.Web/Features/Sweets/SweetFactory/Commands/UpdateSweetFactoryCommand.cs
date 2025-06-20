using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Sweets.SweetFactory.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Sweets.SweetFactory.Commands;


/// <summary>
/// Обновление таблицы сладостей
/// </summary>
public sealed class UpdateSweetFactoryCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные сладости
    /// </summary>
    [Required]
    [FromBody]
    public UpdateSweetFactoryDto SweetFactory { get; init; }
}

public sealed class UpdateSweetFactoryCommandHandler : IRequestHandler<UpdateSweetFactoryCommand, Guid>
{
    private readonly DataContext _dataContext;

    public UpdateSweetFactoryCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Guid> Handle(UpdateSweetFactoryCommand request, CancellationToken cancellationToken)
    {
        var sweetfactory = await _dataContext.SweetFactories
                           .FirstOrDefaultAsync(c => c.IsnSweetFactory == request.SweetFactory.IsnSweetFactory, cancellationToken)
                       ?? throw new BusinessLogicException(
                           $"Фабрики с идентификатором \"{request.SweetFactory.IsnSweetFactory}\" не существует");

        sweetfactory.IsnSweetFactory = request.SweetFactory.IsnSweetFactory;
        sweetfactory.Name = request.SweetFactory.Name;
        sweetfactory.Address = request.SweetFactory.Address;
        sweetfactory.Volume = request.SweetFactory.Volume;

        await _dataContext.SaveChangesAsync(cancellationToken);
        return sweetfactory.IsnSweetFactory;
    }
}