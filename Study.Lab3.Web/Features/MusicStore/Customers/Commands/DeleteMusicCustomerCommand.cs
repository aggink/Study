using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.MusicStore;
using Study.Lab3.Storage.Database;

namespace Study.Lab3.Web.Features.MusicStore.Customers.Commands;

/// <summary>
/// Удаление покупателя
/// </summary>
public sealed class DeleteMusicCustomerCommand : IRequest
{
    /// <summary>
    /// Идентификатор покупателя
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnCustomer { get; init; }
}

public sealed class DeleteMusicCustomerCommandHandler : IRequestHandler<DeleteMusicCustomerCommand>
{
    private readonly DataContext _dataContext;
    private readonly IMusicCustomerService _customerService;

    public DeleteMusicCustomerCommandHandler(
        DataContext dataContext,
        IMusicCustomerService customerService)
    {
        _dataContext = dataContext;
        _customerService = customerService;
    }

    public async Task Handle(DeleteMusicCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _dataContext.MusicCustomers
                           .FirstOrDefaultAsync(x => x.IsnCustomer == request.IsnCustomer, cancellationToken)
                       ?? throw new BusinessLogicException(
                           $"Покупатель с идентификатором \"{request.IsnCustomer}\" не существует");

        await _customerService.CanDeleteAndThrowAsync(_dataContext, customer, cancellationToken);

        _dataContext.MusicCustomers.Remove(customer);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}