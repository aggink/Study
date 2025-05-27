using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Cinema;
using Study.Lab3.Web.Features.Cinema.Customers.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Cinema.Customers.Commands;

/// <summary>
/// Создание клиента
/// </summary>
public sealed class CreateCustomerCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные клиента
    /// </summary>
    [Required]
    [FromBody]
    public CreateCustomerDto Customer { get; init; }
}

public sealed class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Guid>
{
    private readonly DataContext _dataContext;

    public CreateCustomerCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        // Проверка уникальности email
        if (await _dataContext.Customers.AnyAsync(c => c.Email == request.Customer.Email, cancellationToken))
            throw new BusinessLogicException($"Клиент с email \"{request.Customer.Email}\" уже существует");

        var customer = new Customer
        {
            IsnCustomer = Guid.NewGuid(),
            FirstName = request.Customer.FirstName,
            LastName = request.Customer.LastName,
            Email = request.Customer.Email,
            Phone = request.Customer.Phone,
            BirthDate = request.Customer.BirthDate,
            RegistrationDate = DateTime.UtcNow,
            IsActive = true,
            Tickets = new List<Ticket>()
        };

        await _dataContext.Customers.AddAsync(customer, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);
        
        return customer.IsnCustomer;
    }
}