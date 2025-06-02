using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Shelter.Customers.DtoModels;

namespace Study.Lab3.Web.Features.Shelter.Customers.Commands;

/// <summary>
/// Обновление клиента
/// </summary>
public sealed class UpdateShelterCustomerCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные клиента
    /// </summary>
    [Required]
    [FromBody]
    public UpdateShelterCustomerDto ShelterCustomer { get; init; }
}

public sealed class UpdateCustomerCommandHandler : IRequestHandler<UpdateShelterCustomerCommand, Guid>
{
    private readonly DataContext _dataContext;

    public UpdateCustomerCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Guid> Handle(UpdateShelterCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _dataContext.ShelterCustomers
                           .FirstOrDefaultAsync(c => c.Id == request.ShelterCustomer.Id, cancellationToken)
                       ?? throw new BusinessLogicException(
                           $"Клиент с идентификатором \"{request.ShelterCustomer.Id}\" не существует");

        // Проверка уникальности email
        if (customer.Email != request.ShelterCustomer.Email && 
            await _dataContext.Customers.AnyAsync(c => c.Email == request.ShelterCustomer.Email, cancellationToken))
            throw new BusinessLogicException($"Клиент с email \"{request.ShelterCustomer.Email}\" уже существует");

        customer.Name = request.ShelterCustomer.Name;
        customer.LastName = request.ShelterCustomer.LastName;
        customer.Email = request.ShelterCustomer.Email;
        customer.PhoneNumber = request.ShelterCustomer.PhoneNumber;
        customer.Description = request.ShelterCustomer.Description;
        customer.Address = request.ShelterCustomer.Address;
        
        await _dataContext.SaveChangesAsync(cancellationToken);
        return customer.Id;
    }
}