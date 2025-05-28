using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Cinema.Customers.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Cinema.Customers.Queries;

/// <summary>
/// Получение клиента с историей покупок
/// </summary>
public sealed class GetCustomerWithHistoryQuery : IRequest<CustomerWithHistoryDto>
{
    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnCustomer { get; init; }
}

public sealed class GetCustomerWithHistoryQueryHandler : IRequestHandler<GetCustomerWithHistoryQuery, CustomerWithHistoryDto>
{
    private readonly DataContext _dataContext;

    public GetCustomerWithHistoryQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<CustomerWithHistoryDto> Handle(GetCustomerWithHistoryQuery request, CancellationToken cancellationToken)
    {
        var customer = await _dataContext.Customers
                           .AsNoTracking()
                           .Include(c => c.Tickets)
                               .ThenInclude(t => t.Session)
                                   .ThenInclude(s => s.Movie)
                           .Include(c => c.Tickets)
                               .ThenInclude(t => t.Session)
                                   .ThenInclude(s => s.Hall)
                           .Include(c => c.Tickets)
                               .ThenInclude(t => t.Seat)
                           .FirstOrDefaultAsync(c => c.IsnCustomer == request.IsnCustomer, cancellationToken)
                       ?? throw new BusinessLogicException(
                           $"Клиент с идентификатором \"{request.IsnCustomer}\" не существует");

        return new CustomerWithHistoryDto
        {
            IsnCustomer = customer.IsnCustomer,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Email = customer.Email,
            Phone = customer.Phone,
            BirthDate = customer.BirthDate,
            RegistrationDate = customer.RegistrationDate,
            IsActive = customer.IsActive,
            TicketHistory = customer.Tickets
                .OrderByDescending(t => t.Session.StartTime)
                .Select(t => new TicketHistoryItemDto
                {
                    IsnTicket = t.IsnTicket,
                    MovieTitle = t.Session.Movie.Title,
                    HallName = t.Session.Hall.Name,
                    SessionDateTime = t.Session.StartTime,
                    SeatInfo = $"Ряд {t.Seat.Row}, Место {t.Seat.Number}",
                    Price = t.Price,
                    PurchaseDate = t.PurchaseDate,
                    Status = t.Status.ToString()
                })
                .ToArray(),
            TotalTicketsBought = customer.Tickets.Count,
            TotalSpent = customer.Tickets.Sum(t => t.Price)
        };
    }
}