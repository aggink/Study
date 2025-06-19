using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.MusicStore.Customers.DtoModels;

namespace Study.Lab3.Web.Features.MusicStore.Customers.Queries;

/// <summary>
/// Получить покупателя по идентификатору
/// </summary>
public sealed class GetMusicCustomerByIsnQuery : IRequest<MusicCustomerDto>
{
    /// <summary>
    /// Идентификатор покупателя
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnCustomer { get; init; }
}

public sealed class GetMusicCustomerByIsnQueryHandler : IRequestHandler<GetMusicCustomerByIsnQuery, MusicCustomerDto>
{
    private readonly DataContext _dataContext;

    public GetMusicCustomerByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<MusicCustomerDto> Handle(GetMusicCustomerByIsnQuery request, CancellationToken cancellationToken)
    {
        var customer = await _dataContext.MusicCustomers
                           .AsNoTracking()
                           .FirstOrDefaultAsync(x => x.IsnCustomer == request.IsnCustomer, cancellationToken)
                       ?? throw new BusinessLogicException(
                           $"Покупатель с идентификатором \"{request.IsnCustomer}\" не существует");

        return new MusicCustomerDto
        {
            IsnCustomer = customer.IsnCustomer,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Email = customer.Email,
            Phone = customer.Phone,
            BirthDate = customer.BirthDate,
            PreferredGenre = customer.PreferredGenre,
            Status = customer.Status,
            RegistrationDate = customer.RegistrationDate
        };
    }
}

