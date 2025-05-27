using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Cinema.Customers.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Cinema.Customers.Commands;

/// <summary>
/// Обновление клиента
/// </summary>
public sealed class UpdateCustomerCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные клиента
    /// </summary>
    [Required]
    [FromBody]
    public UpdateCustomerDto Customer { get; init; }
}

public sealed class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Guid>
{
    private readonly DataContext _dataContext;

    public UpdateCustomerCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Guid> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _dataContext.Customers
                           .FirstOrDefaultAsync(c => c.IsnCustomer == request.Customer.IsnCustomer, cancellationToken)
                       ?? throw new BusinessLogicException(
                           $"Клиент с идентификатором \"{request.Customer.IsnCustomer}\" не существует");

        // Проверка уникальности email
        if (customer.Email != request.Customer.Email && 
            await _dataContext.Customers.AnyAsync(c => c.Email == request.Customer.Email, cancellationToken))
            throw new BusinessLogicException($"Клиент с email \"{request.Customer.Email}\" уже существует");

        customer.FirstName = request.Customer.FirstName;
        customer.LastName = request.Customer.LastName;
        customer.Email = request.Customer.Email;
        customer.Phone = request.Customer.Phone;
        customer.BirthDate = request.Customer.BirthDate;
        customer.IsActive = request.Customer.IsActive;

        await _dataContext.SaveChangesAsync(cancellationToken);
        return customer.IsnCustomer;
    }
}