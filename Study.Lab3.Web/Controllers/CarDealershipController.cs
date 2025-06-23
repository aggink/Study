using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Web.Features.CarDealership.Customers.Commands;
using Study.Lab3.Web.Features.CarDealership.Customers.DtoModels;
using Study.Lab3.Web.Features.CarDealership.Customers.Queries;
using Study.Lab3.Web.Features.CarDealership.Sales.Commands;
using Study.Lab3.Web.Features.CarDealership.Sales.DtoModels;
using Study.Lab3.Web.Features.CarDealership.Sales.Queries;
using Study.Lab3.Web.Features.CarDealership.Vehicles.Commands;
using Study.Lab3.Web.Features.CarDealership.Vehicles.DtoModels;
using Study.Lab3.Web.Features.CarDealership.Vehicles.Queries;

namespace Study.Lab3.Web.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class CarDealershipController : Controller
{
    private readonly IMediator _mediator;

    public CarDealershipController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region Customer

    /// <summary>
    /// Создание клиента автосалона
    /// </summary>
    /// <param name="command">Данные клиента</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор созданного клиента</returns>
    [HttpPost(nameof(CreateCustomer), Name = "CreateCarDealershipCustomer")]
    public async Task<ActionResult<Guid>> CreateCustomer(CreateCarDealershipCustomerCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Обновление данных клиента автосалона
    /// </summary>
    /// <param name="command">Данные клиента</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор обновленного клиента</returns>
    [HttpPost(nameof(UpdateCustomer), Name = "UpdateCarDealershipCustomer")]
    public async Task<ActionResult<Guid>> UpdateCustomer(UpdateCarDealershipCustomerCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление клиента автосалона
    /// </summary>
    /// <param name="command">Идентификатор клиента</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPost(nameof(DeleteCustomer), Name = "DeleteCarDealershipCustomer")]
    public async Task<ActionResult> DeleteCustomer(DeleteCarDealershipCustomerCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение списка клиентов автосалона
    /// </summary>
    /// <param name="query">Запрос</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список клиентов автосалона</returns>
    [HttpGet(nameof(GetListCustomers), Name = "GetCarDealershipCustomersList")]
    public async Task<ActionResult<CarDealershipCustomerDto[]>> GetListCustomers([FromQuery] GetCarDealershipCustomersListQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение клиента автосалона по идентификатору
    /// </summary>
    /// <param name="query">Запрос с идентификатором клиента</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные клиента автосалона</returns>
    [HttpGet(nameof(GetCustomerById), Name = "GetCarDealershipCustomerById")]
    public async Task<ActionResult<CarDealershipCustomerDto>> GetCustomerById([FromQuery] GetCarDealershipCustomerByIdQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region Vehicle

    /// <summary>
    /// Создание автомобиля
    /// </summary>
    /// <param name="command">Данные автомобиля</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор созданного автомобиля</returns>
    [HttpPost(nameof(CreateVehicle), Name = nameof(CreateVehicle))]
    public async Task<ActionResult<Guid>> CreateVehicle(CreateVehicleCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Обновление данных автомобиля
    /// </summary>
    /// <param name="command">Данные автомобиля</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор обновленного автомобиля</returns>
    [HttpPost(nameof(UpdateVehicle), Name = nameof(UpdateVehicle))]
    public async Task<ActionResult<Guid>> UpdateVehicle(UpdateVehicleCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление автомобиля
    /// </summary>
    /// <param name="command">Идентификатор автомобиля</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPost(nameof(DeleteVehicle), Name = nameof(DeleteVehicle))]
    public async Task<ActionResult> DeleteVehicle(DeleteVehicleCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение списка автомобилей
    /// </summary>
    /// <param name="query">Запрос</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список автомобилей</returns>
    [HttpGet(nameof(GetListVehicles), Name = nameof(GetListVehicles))]
    public async Task<ActionResult<VehicleDto[]>> GetListVehicles([FromQuery] GetVehiclesListQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение автомобиля по идентификатору
    /// </summary>
    /// <param name="query">Запрос с идентификатором автомобиля</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные автомобиля</returns>
    [HttpGet(nameof(GetVehicleById), Name = nameof(GetVehicleById))]
    public async Task<ActionResult<VehicleDto>> GetVehicleById([FromQuery] GetVehicleByIdQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region Sale

    /// <summary>
    /// Создание продажи автомобиля
    /// </summary>
    /// <param name="command">Данные продажи</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор созданной продажи</returns>
    [HttpPost(nameof(CreateSale), Name = nameof(CreateSale))]
    public async Task<ActionResult<Guid>> CreateSale(CreateCarDealershipSaleCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Обновление данных продажи автомобиля
    /// </summary>
    /// <param name="command">Данные продажи</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор обновленной продажи</returns>
    [HttpPost(nameof(UpdateSale), Name = nameof(UpdateSale))]
    public async Task<ActionResult<Guid>> UpdateSale(UpdateCarDealershipSaleCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление продажи автомобиля
    /// </summary>
    /// <param name="command">Идентификатор продажи</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPost(nameof(DeleteSale), Name = nameof(DeleteSale))]
    public async Task<ActionResult> DeleteSale(DeleteCarDealershipSaleCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение списка продаж автомобилей
    /// </summary>
    /// <param name="query">Запрос</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список продаж автомобилей</returns>
    [HttpGet(nameof(GetListSales), Name = nameof(GetListSales))]
    public async Task<ActionResult<CarDealershipSaleDto[]>> GetListSales([FromQuery] GetCarDealershipSalesListQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение продажи автомобиля по идентификатору
    /// </summary>
    /// <param name="query">Запрос с идентификатором продажи</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные продажи автомобиля</returns>
    [HttpGet(nameof(GetSaleById), Name = nameof(GetSaleById))]
    public async Task<ActionResult<CarDealershipSaleDto>> GetSaleById([FromQuery] GetCarDealershipSaleByIdQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion
}