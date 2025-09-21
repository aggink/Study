using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Web.Features.TravelAgency.Customers.Commands;
using Study.Lab3.Web.Features.TravelAgency.Customers.DtoModels;
using Study.Lab3.Web.Features.TravelAgency.Customers.Queries;
using Study.Lab3.Web.Features.TravelAgency.Hotels.Commands;
using Study.Lab3.Web.Features.TravelAgency.Hotels.DtoModels;
using Study.Lab3.Web.Features.TravelAgency.Hotels.Queries;
using Study.Lab3.Web.Features.TravelAgency.Tours.Commands;
using Study.Lab3.Web.Features.TravelAgency.Tours.DtoModels;
using Study.Lab3.Web.Features.TravelAgency.Tours.Queries;

namespace Study.Lab3.Web.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class TravelAgencyController : Controller
{
    private readonly IMediator _mediator;

    public TravelAgencyController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region Tour

    /// <summary>
    /// Создание тура
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор тура</returns>
    [HttpPost(nameof(CreateTour), Name = nameof(CreateTour))]
    public async Task<ActionResult<Guid>> CreateTour(CreateTourCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование данных тура
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор тура</returns>
    [HttpPut(nameof(UpdateTour), Name = nameof(UpdateTour))]
    public async Task<ActionResult<Guid>> UpdateTour(UpdateTourCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление тура
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpDelete(nameof(DeleteTour), Name = nameof(DeleteTour))]
    public async Task<ActionResult> DeleteTour(DeleteTourCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение списка туров
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список туров</returns>
    [HttpGet(nameof(GetListTours), Name = nameof(GetListTours))]
    public async Task<ActionResult<TourDto[]>> GetListTours([FromQuery] GetListToursQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение данных тура
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные тура</returns>
    [HttpGet(nameof(GetTourByIsn), Name = nameof(GetTourByIsn))]
    public async Task<ActionResult<TourDto>> GetTourByIsn([FromQuery] GetTourByIsnQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region Hotel

    /// <summary>
    /// Создание отеля
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор отеля</returns>
    [HttpPost(nameof(CreateHotel), Name = nameof(CreateHotel))]
    public async Task<ActionResult<Guid>> CreateHotel(CreateHotelCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование данных отеля
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор отеля</returns>
    [HttpPut(nameof(UpdateHotel), Name = nameof(UpdateHotel))]
    public async Task<ActionResult<Guid>> UpdateHotel(UpdateHotelCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление отеля
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpDelete(nameof(DeleteHotel), Name = nameof(DeleteHotel))]
    public async Task<ActionResult> DeleteHotel(DeleteHotelCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение списка отелей
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список отелей</returns>
    [HttpGet(nameof(GetListHotels), Name = nameof(GetListHotels))]
    public async Task<ActionResult<HotelDto[]>> GetListHotels([FromQuery] GetListHotelsQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение данных отеля
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные отеля</returns>
    [HttpGet(nameof(GetHotelByIsn), Name = nameof(GetHotelByIsn))]
    public async Task<ActionResult<HotelDto>> GetHotelByIsn([FromQuery] GetHotelByIsnQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region Customer

    /// <summary>
    /// Создание клиента
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор клиента</returns>
    [HttpPost(nameof(CreateCustomer), Name = "TravelAgency.CreateCustomer")]
    public async Task<ActionResult<Guid>> CreateCustomer(CreateTravelCustomerCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование клиента
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор клиента</returns>
    [HttpPut(nameof(UpdateCustomer), Name = "TravelAgency.UpdateCustomer")]
    public async Task<ActionResult<Guid>> UpdateCustomer(UpdateTravelCustomerCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление клиента
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpDelete(nameof(DeleteCustomer), Name = "TravelAgency.DeleteCustomer")]
    public async Task<ActionResult> DeleteCustomer(DeleteTravelCustomerCommand command,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение списка клиентов
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список клиентов</returns>
    [HttpGet(nameof(GetListCustomers), Name = "TravelAgency.GetListCustomers")]
    public async Task<ActionResult<TravelCustomerDto[]>> GetListCustomers([FromQuery] GetListTravelCustomersQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение данных клиента
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные клиента</returns>
    [HttpGet(nameof(GetCustomerByIsn), Name = "TravelAgency.GetCustomerByIsn")]
    public async Task<ActionResult<TravelCustomerDto>> GetCustomerByIsn([FromQuery] GetTravelCustomerByIsnQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion
}