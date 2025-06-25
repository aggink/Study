using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Museum.MuseumVisitors.DtoModels;

namespace Study.Lab3.Web.Features.Museum.MuseumVisitors.Queries;

/// <summary>
/// Получить посетителя по идентификатору
/// </summary>
public sealed class GetMuseumVisitorByIsnQuery : IRequest<MuseumVisitorDto>
{
    /// <summary>
    /// Идентификатор посетителя
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnMuseumVisitor { get; init; }
}

public sealed class GetMuseumVisitorByIsnQueryHandler : IRequestHandler<GetMuseumVisitorByIsnQuery, MuseumVisitorDto>
{
    private readonly DataContext _dataContext;

    public GetMuseumVisitorByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<MuseumVisitorDto> Handle(GetMuseumVisitorByIsnQuery request, CancellationToken cancellationToken)
    {
        var visitor = await _dataContext.MuseumVisitors
                          .AsNoTracking()
                          .FirstOrDefaultAsync(x => x.IsnMuseumVisitor == request.IsnMuseumVisitor, cancellationToken)
                      ?? throw new BusinessLogicException($"Посетитель с идентификатором \"{request.IsnMuseumVisitor}\" не существует");

        return new MuseumVisitorDto
        {
            IsnMuseumVisitor = visitor.IsnMuseumVisitor,
            FirstName = visitor.FirstName,
            LastName = visitor.LastName,
            Email = visitor.Email,
            Phone = visitor.Phone,
            DateOfBirth = visitor.DateOfBirth,
            VisitDate = visitor.VisitDate,
            TicketType = visitor.TicketType,
            TicketPrice = visitor.TicketPrice,
            IsMember = visitor.IsMember,
            MembershipNumber = visitor.MembershipNumber
        };
    }
}
