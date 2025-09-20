using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.MusicStore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.MusicStore;
using Study.Lab3.Web.Features.MusicStore.Customers.DtoModels;

namespace Study.Lab3.Web.Features.MusicStore.Customers.Commands;

/// <summary>
/// Создание покупателя
/// </summary>
public sealed class CreateMusicCustomerCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные покупателя
    /// </summary>
    [Required]
    [FromBody]
    public CreateMusicCustomerDto Customer { get; init; }
}

public sealed class CreateMusicCustomerCommandHandler : IRequestHandler<CreateMusicCustomerCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IMusicCustomerService _customerService;

    public CreateMusicCustomerCommandHandler(
        DataContext dataContext,
        IMusicCustomerService customerService)
    {
        _dataContext = dataContext;
        _customerService = customerService;
    }

    public async Task<Guid> Handle(CreateMusicCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new MusicCustomer
        {
            IsnCustomer = Guid.NewGuid(),
            FirstName = request.Customer.FirstName,
            LastName = request.Customer.LastName,
            Email = request.Customer.Email,
            Phone = request.Customer.Phone,
            BirthDate = request.Customer.BirthDate,
            PreferredGenre = request.Customer.PreferredGenre,
            Status = request.Customer.Status,
            RegistrationDate = DateTime.UtcNow
        };

        await _customerService.CreateOrUpdateCustomerValidateAndThrowAsync(
            _dataContext, customer, cancellationToken);

        await _dataContext.MusicCustomers.AddAsync(customer, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return customer.IsnCustomer;
    }
}