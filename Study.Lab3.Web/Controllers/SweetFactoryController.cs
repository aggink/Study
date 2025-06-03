using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Web.Features.Sweets.SweetFactories.Commands;
using Study.Lab3.Web.Features.Sweets.SweetFactories.DtoModels;
using Study.Lab3.Web.Features.Sweets.SweetFactories.Queries;
using Study.Lab3.Web.Features.Sweets.Sweets.Commands;
using Study.Lab3.Web.Features.Sweets.Sweets.DtoModels;
using Study.Lab3.Web.Features.Sweets.Sweets.Queries;
using Study.Lab3.Web.Features.Sweets.SweetProduction.Commands;
using Study.Lab3.Web.Features.Sweets.SweetProduction.DtoModels;
using Study.Lab3.Web.Features.Sweets.SweetProduction.Queries;
using Study.Lab3.Web.Features.Sweets.SweetType.Commands;
using Study.Lab3.Web.Features.Sweets.SweetType.DtoModels;
using Study.Lab3.Web.Features.Sweets.SweetType.Queries;
using Study.Lab3.Web.Features.Sweets.Commands;

namespace Study.Lab3.Web.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class SweetController : Controller
{
    private readonly IMediator _mediator;

    public SweetController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region Sweets

    /// <summary>
    /// Создание сладости
    /// </summary>
    [HttpPost(nameof(CreateSweet), Name = nameof(CreateSweet))]
    public async Task<ActionResult<Guid>> CreateSweet(CreateSweetCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Обновление сладости
    /// </summary>
    [HttpPost(nameof(UpdateSweet), Name = nameof(UpdateSweet))]
    public async Task<ActionResult<Guid>> UpdateSweet(UpdateSweetCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление сладости
    /// </summary>
    [HttpPost(nameof(DeleteSweet), Name = nameof(DeleteSweet))]
    public async Task<ActionResult> DeleteSweet(DeleteSweetCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение сладости по идентификатору
    /// </summary>
    [HttpGet(nameof(GetSweetByIdQuery), Name = nameof(GetSweetByIdQuery))]
    public async Task<ActionResult<GetSweetByIdQuery>> GetMovieById([FromQuery] GetSweetByIdQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение списка сладостей
    /// </summary>
    [HttpGet(nameof(GetListSweets), Name = nameof(GetListSweets))]
    public async Task<ActionResult<SweetDto[]>> GetListSweets([FromQuery] GetListSweetsQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region SweetFactory

    /// <summary>
    /// Создание фабрики
    /// </summary>
    [HttpPost(nameof(CreateSweetFactory), Name = nameof(CreateSweetFactory))]
    public async Task<ActionResult<Guid>> CreateSweetFactory(CreateSweetFactoryCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Обновление фабрики
    /// </summary>
    [HttpPost(nameof(UpdateSweetFactory), Name = nameof(UpdateSweetFactory))]
    public async Task<ActionResult<Guid>> UpdateSweetFactory(UpdateSweetFactoryCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление фабрики
    /// </summary>
    [HttpPost(nameof(DeleteSweetFactory), Name = nameof(DeleteSweetFactory))]
    public async Task<ActionResult> DeleteSweetFactory(DeleteSweetFactoryCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение списка фабрик
    /// </summary>
    [HttpGet(nameof(GetListSweetFactory), Name = nameof(GetListSweetFactory))]
    public async Task<ActionResult<SweetFactoryDto[]>> GetListSweetFactory([FromQuery] GetListSweetFactoryQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region Halls

    /// <summary>
    /// Создание зала
    /// </summary>
    [HttpPost(nameof(CreateHall), Name = nameof(CreateHall))]
    public async Task<ActionResult<Guid>> CreateHall(CreateHallCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Обновление зала
    /// </summary>
    [HttpPost(nameof(UpdateHall), Name = nameof(UpdateHall))]
    public async Task<ActionResult<Guid>> UpdateHall(UpdateHallCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление зала
    /// </summary>
    [HttpPost(nameof(DeleteHall), Name = nameof(DeleteHall))]
    public async Task<ActionResult> DeleteHall(DeleteHallCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение зала по идентификатору
    /// </summary>
    [HttpGet(nameof(GetHallById), Name = nameof(GetHallById))]
    public async Task<ActionResult<HallDto>> GetHallById([FromQuery] GetHallByIdQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение зала с местами
    /// </summary>
    [HttpGet(nameof(GetHallWithSeats), Name = nameof(GetHallWithSeats))]
    public async Task<ActionResult<HallWithSeatsDto>> GetHallWithSeats([FromQuery] GetHallWithSeatsQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение списка залов
    /// </summary>
    [HttpGet(nameof(GetListHalls), Name = nameof(GetListHalls))]
    public async Task<ActionResult<HallDto[]>> GetListHalls([FromQuery] GetListHallsQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region Sessions

    /// <summary>
    /// Создание сеанса
    /// </summary>
    [HttpPost(nameof(CreateSession), Name = nameof(CreateSession))]
    public async Task<ActionResult<Guid>> CreateSession(CreateSessionCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Обновление сеанса
    /// </summary>
    [HttpPost(nameof(UpdateSession), Name = nameof(UpdateSession))]
    public async Task<ActionResult<Guid>> UpdateSession(UpdateSessionCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление сеанса
    /// </summary>
    [HttpPost(nameof(DeleteSession), Name = nameof(DeleteSession))]
    public async Task<ActionResult> DeleteSession(DeleteSessionCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение сеанса по идентификатору
    /// </summary>
    [HttpGet(nameof(GetSessionById), Name = nameof(GetSessionById))]
    public async Task<ActionResult<SessionDto>> GetSessionById([FromQuery] GetSessionByIdQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение сеанса с информацией о местах
    /// </summary>
    [HttpGet(nameof(GetSessionWithSeats), Name = nameof(GetSessionWithSeats))]
    public async Task<ActionResult<SessionWithSeatsDto>> GetSessionWithSeats([FromQuery] GetSessionWithSeatsQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение списка сеансов
    /// </summary>
    [HttpGet(nameof(GetListSessions), Name = nameof(GetListSessions))]
    public async Task<ActionResult<SessionDto[]>> GetListSessions([FromQuery] GetListSessionsQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение сеансов по фильму
    /// </summary>
    [HttpGet(nameof(GetSessionsByMovie), Name = nameof(GetSessionsByMovie))]
    public async Task<ActionResult<SessionDto[]>> GetSessionsByMovie([FromQuery] GetSessionsByMovieQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region Customers

    /// <summary>
    /// Создание клиента
    /// </summary>
    [HttpPost(nameof(CreateCustomer), Name = nameof(CreateCustomer))]
    public async Task<ActionResult<Guid>> CreateCustomer(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Обновление клиента
    /// </summary>
    [HttpPost(nameof(UpdateCustomer), Name = nameof(UpdateCustomer))]
    public async Task<ActionResult<Guid>> UpdateCustomer(UpdateCustomerCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление клиента
    /// </summary>
    [HttpPost(nameof(DeleteCustomer), Name = nameof(DeleteCustomer))]
    public async Task<ActionResult> DeleteCustomer(DeleteCustomerCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение клиента по идентификатору
    /// </summary>
    [HttpGet(nameof(GetCustomerById), Name = nameof(GetCustomerById))]
    public async Task<ActionResult<CustomerDto>> GetCustomerById([FromQuery] GetCustomerByIdQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение клиента с историей покупок
    /// </summary>
    [HttpGet(nameof(GetCustomerWithHistory), Name = nameof(GetCustomerWithHistory))]
    public async Task<ActionResult<CustomerWithHistoryDto>> GetCustomerWithHistory([FromQuery] GetCustomerWithHistoryQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение списка клиентов
    /// </summary>
    [HttpGet(nameof(GetListCustomers), Name = nameof(GetListCustomers))]
    public async Task<ActionResult<CustomerDto[]>> GetListCustomers([FromQuery] GetListCustomersQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region Tickets

    /// <summary>
    /// Покупка билета
    /// </summary>
    [HttpPost(nameof(BuyTicket), Name = nameof(BuyTicket))]
    public async Task<ActionResult<Guid>> BuyTicket(BuyTicketCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Отмена билета
    /// </summary>
    [HttpPost(nameof(CancelTicket), Name = nameof(CancelTicket))]
    public async Task<ActionResult> CancelTicket(CancelTicketCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Использование билета
    /// </summary>
    [HttpPost(nameof(UseTicket), Name = nameof(UseTicket))]
    public async Task<ActionResult> UseTicket(UseTicketCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение билета по идентификатору
    /// </summary>
    [HttpGet(nameof(GetTicketById), Name = nameof(GetTicketById))]
    public async Task<ActionResult<TicketDto>> GetTicketById([FromQuery] GetTicketByIdQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение билета с детальной информацией
    /// </summary>
    [HttpGet(nameof(GetTicketWithDetails), Name = nameof(GetTicketWithDetails))]
    public async Task<ActionResult<TicketWithDetailsDto>> GetTicketWithDetails([FromQuery] GetTicketWithDetailsQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение билетов клиента
    /// </summary>
    [HttpGet(nameof(GetTicketsByCustomer), Name = nameof(GetTicketsByCustomer))]
    public async Task<ActionResult<TicketDto[]>> GetTicketsByCustomer([FromQuery] GetTicketsByCustomerQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение билетов на сеанс
    /// </summary>
    [HttpGet(nameof(GetTicketsBySession), Name = nameof(GetTicketsBySession))]
    public async Task<ActionResult<TicketDto[]>> GetTicketsBySession([FromQuery] GetTicketsBySessionQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion
}