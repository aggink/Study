using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Shelter;
using Study.Lab3.Web.Features.Shelter.Customers.DtoModels;

namespace Study.Lab3.Web.Features.Shelter.Customers.Commands;

/// <summary>
/// Создание клиента
/// </summary>
public class CreateShelterCustomerCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные клиента
    /// </summary>
    [Required]
    [FromBody]
    public CreateShelterCustomerDto ShelterCustomer { get; init; }
}

public sealed class CreateCustomerCommandHandler : IRequestHandler<CreateShelterCustomerCommand, Guid>
{
    private readonly DataContext _dataContext;

    public CreateCustomerCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Guid> Handle(CreateShelterCustomerCommand request, CancellationToken cancellationToken)
    {
        // Проверка уникальности email
        if (await _dataContext.Customers.AnyAsync(c => c.Email == request.ShelterCustomer.Email, cancellationToken))
            throw new BusinessLogicException($"Клиент с email \"{request.ShelterCustomer.Email}\" уже существует");

        var customer = new Customer
        {
            IsnCustomer = Guid.NewGuid(),
            Name = request.ShelterCustomer.Name,
            LastName = request.ShelterCustomer.LastName,
            Email = request.ShelterCustomer.Email,
            PhoneNumber = request.ShelterCustomer.PhoneNumber,
            Address = request.ShelterCustomer.Address,
            Adoptions = new List<Adoption>()
        };

        await _dataContext.ShelterCustomers.AddAsync(customer, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return customer.IsnCustomer;
    }
}