using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.Museum;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Museum;
using Study.Lab3.Web.Features.Museum.MuseumVisitors.DtoModels;

namespace Study.Lab3.Web.Features.Museum.MuseumVisitors.Command;

/// <summary>
/// Создание посетителя музея
/// </summary>
public sealed class CreateMuseumVisitorCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные посетителя
    /// </summary>
    [Required]
    [FromBody]
    public CreateMuseumVisitorDto Visitor { get; init; }
}

public sealed class CreateMuseumVisitorCommandHandler : IRequestHandler<CreateMuseumVisitorCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IMuseumVisitorService _visitorService;

    public CreateMuseumVisitorCommandHandler(
        DataContext dataContext,
        IMuseumVisitorService visitorService)
    {
        _dataContext = dataContext;
        _visitorService = visitorService;
    }

    public async Task<Guid> Handle(CreateMuseumVisitorCommand request, CancellationToken cancellationToken)
    {
        var visitor = new MuseumVisitor
        {
            IsnMuseumVisitor = Guid.NewGuid(),
            FirstName = request.Visitor.FirstName,
            LastName = request.Visitor.LastName,
            Email = request.Visitor.Email,
            Phone = request.Visitor.Phone,
            DateOfBirth = request.Visitor.DateOfBirth,
            VisitDate = request.Visitor.VisitDate,
            TicketType = request.Visitor.TicketType,
            TicketPrice = request.Visitor.TicketPrice,
            IsMember = request.Visitor.IsMember,
            MembershipNumber = request.Visitor.MembershipNumber
        };

        await _visitorService.CreateOrUpdateVisitorValidateAndThrowAsync(
            _dataContext, visitor, cancellationToken);

        await _dataContext.MuseumVisitors.AddAsync(visitor, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return visitor.IsnMuseumVisitor;
    }
}
