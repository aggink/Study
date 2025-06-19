using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.MusicStore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.MusicStore.Customers.DtoModels;

namespace Study.Lab3.Web.Features.MusicStore.Customers.Commands;

/// <summary>
/// Обновление покупателя
/// </summary>
public sealed class UpdateMusicCustomerCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные покупателя
    /// </summary>
    [Required]
    [FromBody]
    public UpdateMusicCustomerDto Customer { get; init; }
}

public sealed class UpdateMusicCustomerCommandHandler : IRequestHandler<UpdateMusicCustomerCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IMusicCustomerService _customerService;

    public UpdateMusicCustomerCommandHandler(
        DataContext dataContext,
        IMusicCustomerService customerService)
    {
        _dataContext = dataContext;
        _customerService = customerService;
    }

    public async Task<Guid> Handle(UpdateMusicCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _dataContext.MusicCustomers
                           .FirstOrDefaultAsync(x => x.IsnCustomer == request.Customer.IsnCustomer, cancellationToken)
                       ?? throw new BusinessLogicException(
                           $"Покупатель с идентификатором \"{request.Customer.IsnCustomer}\" не существует");

        customer.FirstName = request.Customer.FirstName;
        customer.LastName = request.Customer.LastName;
        customer.Email = request.Customer.Email;
        customer.Phone = request.Customer.Phone;
        customer.BirthDate = request.Customer.BirthDate;
        customer.PreferredGenre = request.Customer.PreferredGenre;
        customer.Status = request.Customer.Status;

        await _customerService.CreateOrUpdateCustomerValidateAndThrowAsync(
            _dataContext, customer, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return customer.IsnCustomer;
    }
}