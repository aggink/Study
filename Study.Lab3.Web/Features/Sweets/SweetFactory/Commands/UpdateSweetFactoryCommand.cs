using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Sweets.SweetFactories.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Sweets.SweetFactories.Commands;


/// <summary>
/// Обновление таблицы сладостей
/// </summary>
public sealed class UpdateSweetFactoryCommand : IRequest<long>
{
    /// <summary>
    /// Данные сладости
    /// </summary>
    [Required]
    [FromBody]
    public UpdateSweetFactoryDto SweetFactory { get; init; }
}

public sealed class UpdateSweetFactoryCommandHandler : IRequestHandler<UpdateSweetFactoryCommand, long>
{
    private readonly DataContext _dataContext;

    public UpdateSweetFactoryCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<long> Handle(UpdateSweetFactoryCommand request, CancellationToken cancellationToken)
    {
        var sweetfactory = await _dataContext.SweetFactories
                           .FirstOrDefaultAsync(c => c.ID == request.SweetFactory.ID, cancellationToken)
                       ?? throw new BusinessLogicException(
                           $"Фабрики с идентификатором \"{request.SweetFactory.ID}\" не существует");

        sweetfactory.ID = request.SweetFactory.ID;
        sweetfactory.Name = request.SweetFactory.Name;
        sweetfactory.Address = request.SweetFactory.Address;
        sweetfactory.Volume = request.SweetFactory.Volume;

        await _dataContext.SaveChangesAsync(cancellationToken);
        return sweetfactory.ID;
    }
}