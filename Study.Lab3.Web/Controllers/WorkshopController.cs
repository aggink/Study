using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Web.Features.Workshop.Masters.Commands;
using Study.Lab3.Web.Features.Workshop.Masters.DtoModels;
using Study.Lab3.Web.Features.Workshop.Masters.Queries;
using Study.Lab3.Web.Features.Workshop.Services.Commands;
using Study.Lab3.Web.Features.Workshop.Services.DtoModels;
using Study.Lab3.Web.Features.Workshop.Services.Queries;
using Study.Lab3.Web.Features.Workshop.ServiceOrders.Commands;
using Study.Lab3.Web.Features.Workshop.ServiceOrders.DtoModels;
using Study.Lab3.Web.Features.Workshop.ServiceOrders.Queries;

namespace Study.Lab3.Web.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class WorkshopController : Controller
{
    private readonly IMediator _mediator;

    public WorkshopController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region Master

    /// <summary>
    /// Создание мастера
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор мастера</returns>
    [HttpPost(nameof(CreateMaster), Name = nameof(CreateMaster))]
    public async Task<ActionResult<Guid>> CreateMaster(CreateMasterCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование данных мастера
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор мастера</returns>
    [HttpPost(nameof(UpdateMaster), Name = nameof(UpdateMaster))]
    public async Task<ActionResult<Guid>> UpdateMaster(UpdateMasterCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление мастера
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPost(nameof(DeleteMaster), Name = nameof(DeleteMaster))]
    public async Task<ActionResult> DeleteMaster(DeleteMasterCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение списка мастеров
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список мастеров</returns>
    [HttpGet(nameof(GetListMasters), Name = nameof(GetListMasters))]
    public async Task<ActionResult<MasterDto[]>> GetListMasters([FromQuery] GetListMastersQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение данных мастера
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные мастера</returns>
    [HttpGet(nameof(GetMasterByIsn), Name = nameof(GetMasterByIsn))]
    public async Task<ActionResult<MasterDto>> GetMasterByIsn(GetMasterByIsnQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region Service

    /// <summary>
    /// Создание услуги
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор услуги</returns>
    [HttpPost(nameof(CreateService), Name = nameof(CreateService))]
    public async Task<ActionResult<Guid>> CreateService(CreateServiceCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование данных услуги
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор услуги</returns>
    [HttpPost(nameof(UpdateService), Name = nameof(UpdateService))]
    public async Task<ActionResult<Guid>> UpdateService(UpdateServiceCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление услуги
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPost(nameof(DeleteService), Name = nameof(DeleteService))]
    public async Task<ActionResult> DeleteService(DeleteServiceCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение списка услуг
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список услуг</returns>
    [HttpGet(nameof(GetListServices), Name = nameof(GetListServices))]
    public async Task<ActionResult<ServiceDto[]>> GetListServices([FromQuery] GetListServicesQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение данных услуги
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные услуги</returns>
    [HttpGet(nameof(GetServiceByIsn), Name = nameof(GetServiceByIsn))]
    public async Task<ActionResult<ServiceDto>> GetServiceByIsn(GetServiceByIsnQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region ServiceOrder

    /// <summary>
    /// Создание заказа
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор заказа</returns>
    [HttpPost(nameof(CreateServiceOrder), Name = nameof(CreateServiceOrder))]
    public async Task<ActionResult<Guid>> CreateServiceOrder(CreateServiceOrderCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование заказа
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор заказа</returns>
    [HttpPost(nameof(UpdateServiceOrder), Name = nameof(UpdateServiceOrder))]
    public async Task<ActionResult<Guid>> UpdateServiceOrder(UpdateServiceOrderCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление заказа
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPost(nameof(DeleteServiceOrder), Name = nameof(DeleteServiceOrder))]
    public async Task<ActionResult> DeleteServiceOrder(DeleteServiceOrderCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение списка заказов
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список заказов</returns>
    [HttpGet(nameof(GetListServiceOrders), Name = nameof(GetListServiceOrders))]
    public async Task<ActionResult<ServiceOrderDto[]>> GetListServiceOrders([FromQuery] GetListServiceOrdersQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение данных заказа
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные заказа</returns>
    [HttpGet(nameof(GetServiceOrderByIsn), Name = nameof(GetServiceOrderByIsn))]
    public async Task<ActionResult<ServiceOrderDto>> GetServiceOrderByIsn(GetServiceOrderByIsnQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение заказа с детальной информацией
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные заказа с деталями</returns>
    [HttpGet(nameof(GetServiceOrderWithDetails), Name = nameof(GetServiceOrderWithDetails))]
    public async Task<ActionResult<ServiceOrderWithDetailsDto>> GetServiceOrderWithDetails(GetServiceOrderWithDetailsQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение заказов мастера
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Заказы мастера</returns>
    [HttpGet(nameof(GetServiceOrdersByMaster), Name = nameof(GetServiceOrdersByMaster))]
    public async Task<ActionResult<ServiceOrderWithDetailsDto[]>> GetServiceOrdersByMaster(
        [FromQuery] GetServiceOrdersByMasterQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion
}