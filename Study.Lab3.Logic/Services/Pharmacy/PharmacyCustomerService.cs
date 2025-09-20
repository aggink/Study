using System.Text.RegularExpressions;
using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Pharmacy;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Pharmacy;

namespace Study.Lab3.Logic.Services.Pharmacy;

/// <summary>
/// Сервис для работы с клиентами аптеки
/// </summary>
public sealed class PharmacyCustomerService : IPharmacyCustomerService
{
    public async Task CreateOrUpdateCustomerValidateAndThrowAsync(
        DataContext dataContext,
        PharmacyCustomer customer,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(customer.FirstName))
            throw new BusinessLogicException("Имя клиента не может быть пустым");
        
        if (string.IsNullOrWhiteSpace(customer.LastName))
            throw new BusinessLogicException("Фамилия клиента не может быть пустой");
        
        // Проверка email
        if (!string.IsNullOrWhiteSpace(customer.Email))
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(customer.Email);
                if (addr.Address != customer.Email)
                    throw new BusinessLogicException("Неверный формат email");
                
                // Проверка на уникальность email
                if (await dataContext.PharmacyCustomers.AnyAsync(
                        x => x.IsnCustomer != customer.IsnCustomer && x.Email == customer.Email,
                        cancellationToken))
                {
                    throw new BusinessLogicException($"Клиент с email \"{customer.Email}\" уже существует");
                }
            }
            catch
            {
                throw new BusinessLogicException("Неверный формат email");
            }
        }
        
        // Проверка телефона
        if (!string.IsNullOrWhiteSpace(customer.Phone))
        {
            var phoneRegex = new Regex(@"^[\+]?[(]?[0-9]{1,4}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$");
            if (!phoneRegex.IsMatch(customer.Phone))
                throw new BusinessLogicException("Неверный формат телефона");
            
            // Проверка на уникальность телефона
            if (await dataContext.PharmacyCustomers.AnyAsync(
                    x => x.IsnCustomer != customer.IsnCustomer && x.Phone == customer.Phone,
                    cancellationToken))
            {
                throw new BusinessLogicException($"Клиент с телефоном \"{customer.Phone}\" уже существует");
            }
        }
        
        // Проверка даты рождения
        if (customer.DateOfBirth.HasValue)
        {
            if (customer.DateOfBirth.Value > DateTime.Today)
                throw new BusinessLogicException("Дата рождения не может быть в будущем");
            
            var age = DateTime.Today.Year - customer.DateOfBirth.Value.Year;
            if (customer.DateOfBirth.Value.Date > DateTime.Today.AddYears(-age))
                age--;
            
            if (age < 18)
                throw new BusinessLogicException("Клиент должен быть не младше 18 лет");
            
            if (age > 120)
                throw new BusinessLogicException("Указан некорректный возраст");
        }
        
        // Установка даты регистрации для новых клиентов
        if (customer.IsnCustomer == Guid.Empty)
        {
            customer.RegistrationDate = DateTime.UtcNow;
        }
    }
    
    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        PharmacyCustomer customer,
        CancellationToken cancellationToken = default)
    {
        if (await dataContext.Prescriptions.AnyAsync(x => x.IsnCustomer == customer.IsnCustomer, cancellationToken))
            throw new BusinessLogicException("Нельзя удалить клиента, у которого есть рецепты");
    }
}