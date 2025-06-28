using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Museum;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Museum.MuseumVisitors.DtoModels;

namespace Study.Lab3.Web.Features.Museum.MuseumVisitors.Command;

/// <summary>
/// Обновление данных посетителя музея
/// </summary>
public sealed class UpdateMuseumVisitorCommand : IRequest
{
    /// <summary>
    /// Обновленные данные посетителя
    /// </summary>
    [Required]
    [FromBody]
    public UpdateMuseumVisitorDto Visitor { get; init; }
}

public sealed class UpdateMuseumVisitorCommandHandler : IRequestHandler<UpdateMuseumVisitorCommand>
{
    private readonly DataContext _dataContext;
    private readonly IMuseumVisitorService _visitorService;

    public UpdateMuseumVisitorCommandHandler(
        DataContext dataContext,
        IMuseumVisitorService visitorService)
    {
        _dataContext = dataContext;
        _visitorService = visitorService;
    }

    public async Task Handle(UpdateMuseumVisitorCommand request, CancellationToken cancellationToken)
    {
        var visitor = await _dataContext.MuseumVisitors
                          .FirstOrDefaultAsync(x => x.IsnMuseumVisitor == request.Visitor.IsnMuseumVisitor, cancellationToken)
                      ?? throw new BusinessLogicException($"Посетитель с идентификатором \"{request.Visitor.IsnMuseumVisitor}\" не существует");

        visitor.FirstName = request.Visitor.FirstName;
        visitor.LastName = request.Visitor.LastName;
        visitor.Email = request.Visitor.Email;
        visitor.Phone = request.Visitor.Phone;
        visitor.DateOfBirth = request.Visitor.DateOfBirth;
        visitor.VisitDate = request.Visitor.VisitDate;
        visitor.TicketType = request.Visitor.TicketType;
        visitor.TicketPrice = request.Visitor.TicketPrice;
        visitor.IsMember = request.Visitor.IsMember;
        visitor.MembershipNumber = request.Visitor.MembershipNumber;

        await _visitorService.CreateOrUpdateVisitorValidateAndThrowAsync(
            _dataContext, visitor, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}
