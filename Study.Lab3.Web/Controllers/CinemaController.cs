using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Web.Features.Cinema.Movies.Commands;
using Study.Lab3.Web.Features.Cinema.Movies.DtoModels;
using Study.Lab3.Web.Features.Cinema.Movies.Queries;
using Study.Lab3.Web.Features.Cinema.Genres.Commands;
using Study.Lab3.Web.Features.Cinema.Genres.DtoModels;
using Study.Lab3.Web.Features.Cinema.Genres.Queries;
using Study.Lab3.Web.Features.Cinema.Halls.Commands;
using Study.Lab3.Web.Features.Cinema.Halls.DtoModels;
using Study.Lab3.Web.Features.Cinema.Halls.Queries;
using Study.Lab3.Web.Features.Cinema.Sessions.Commands;
using Study.Lab3.Web.Features.Cinema.Sessions.DtoModels;
using Study.Lab3.Web.Features.Cinema.Sessions.Queries;
using Study.Lab3.Web.Features.Cinema.Customers.Commands;
using Study.Lab3.Web.Features.Cinema.Customers.DtoModels;
using Study.Lab3.Web.Features.Cinema.Customers.Queries;
using Study.Lab3.Web.Features.Cinema.Tickets.Commands;
using Study.Lab3.Web.Features.Cinema.Tickets.DtoModels;
using Study.Lab3.Web.Features.Cinema.Tickets.Queries;

namespace Study.Lab3.Web.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class CinemaController : Controller
{
    private readonly IMediator _mediator;

    public CinemaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region Movies

    /// <summary>
    /// Создание фильма
    /// </summary>
    [HttpPost(nameof(CreateMovie), Name = nameof(CreateMovie))]
    public async Task<ActionResult<Guid>> CreateMovie(CreateMovieCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Обновление фильма
    /// </summary>
    [HttpPost(nameof(UpdateMovie), Name = nameof(UpdateMovie))]
    public async Task<ActionResult<Guid>> UpdateMovie(UpdateMovieCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление фильма
    /// </summary>
    [HttpPost(nameof(DeleteMovie), Name = nameof(DeleteMovie))]
    public async Task<ActionResult> DeleteMovie(DeleteMovieCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Добавление жанра к фильму
    /// </summary>
    [HttpPost(nameof(AddGenreToMovie), Name = nameof(AddGenreToMovie))]
    public async Task<ActionResult> AddGenreToMovie(AddGenreToMovieCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Удаление жанра из фильма
    /// </summary>
    [HttpPost(nameof(RemoveGenreFromMovie), Name = nameof(RemoveGenreFromMovie))]
    public async Task<ActionResult> RemoveGenreFromMovie(RemoveGenreFromMovieCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение фильма по идентификатору
    /// </summary>
    [HttpGet(nameof(GetMovieById), Name = nameof(GetMovieById))]
    public async Task<ActionResult<MovieDto>> GetMovieById([FromQuery] GetMovieByIdQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение фильма с детальной информацией
    /// </summary>
    [HttpGet(nameof(GetMovieWithDetails), Name = nameof(GetMovieWithDetails))]
    public async Task<ActionResult<MovieWithDetailsDto>> GetMovieWithDetails([FromQuery] GetMovieWithDetailsQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение списка фильмов
    /// </summary>
    [HttpGet(nameof(GetListMovies), Name = nameof(GetListMovies))]
    public async Task<ActionResult<MovieDto[]>> GetListMovies([FromQuery] GetListMoviesQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение фильмов по жанру
    /// </summary>
    [HttpGet(nameof(GetMoviesByGenre), Name = nameof(GetMoviesByGenre))]
    public async Task<ActionResult<MovieDto[]>> GetMoviesByGenre([FromQuery] GetMoviesByGenreQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region Genres

    /// <summary>
    /// Создание жанра
    /// </summary>
    [HttpPost(nameof(CreateGenre), Name = nameof(CreateGenre))]
    public async Task<ActionResult<Guid>> CreateGenre(CreateGenreCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Обновление жанра
    /// </summary>
    [HttpPost(nameof(UpdateGenre), Name = nameof(UpdateGenre))]
    public async Task<ActionResult<Guid>> UpdateGenre(UpdateGenreCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление жанра
    /// </summary>
    [HttpPost(nameof(DeleteGenre), Name = nameof(DeleteGenre))]
    public async Task<ActionResult> DeleteGenre(DeleteGenreCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение списка жанров
    /// </summary>
    [HttpGet(nameof(GetListGenres), Name = nameof(GetListGenres))]
    public async Task<ActionResult<GenreDto[]>> GetListGenres([FromQuery] GetListGenresQuery query, CancellationToken cancellationToken)
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