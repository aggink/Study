using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Web.Features.CarService.Cars.Commands;
using Study.Lab3.Web.Features.CarService.Cars.DtoModels;
using Study.Lab3.Web.Features.CarService.Cars.Queries;
using Study.Lab3.Web.Features.CarService.Owners.Commands;
using Study.Lab3.Web.Features.CarService.Owners.DtoModels;
using Study.Lab3.Web.Features.CarService.Owners.Queries;
using Study.Lab3.Web.Features.CarService.ServiceRecord.Commands;
using Study.Lab3.Web.Features.CarService.ServiceRecord.DtoModels;
using Study.Lab3.Web.Features.CarService.ServiceRecord.Queries;

namespace Study.Lab3.Web.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class CarServiceController : Controller
{
    private readonly IMediator _mediator;
 
    public CarServiceController(IMediator mediator)
    {
        _mediator = mediator;
    }
 
    #region Owner
 
    /// <summary>
    /// Создание владельца
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор владельца</returns>
    [HttpPost(nameof(CreateOwner), Name = nameof(CreateOwner))]
    public async Task<ActionResult<Guid>> CreateOwner(CreateOwnerCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
 
    /// <summary>
    /// Редактирование данных владельца
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор владельца</returns>
    [HttpPost(nameof(UpdateOwner), Name = nameof(UpdateOwner))]
    public async Task<ActionResult<Guid>> UpdateOwner(UpdateOwnerCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
 
    /// <summary>
    /// Удаление владельца
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPost(nameof(DeleteOwner), Name = nameof(DeleteOwner))]
    public async Task<ActionResult> DeleteOwner(DeleteOwnerCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }
 
    /// <summary>
    /// Получение списка владельцев
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список владельцев</returns>
    [HttpGet(nameof(GetListOwners), Name = nameof(GetListOwners))]
    public async Task<ActionResult<OwnerDto[]>> GetListOwners([FromQuery] GetListOwnersQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
 
    /// <summary>
    /// Получение данных владельца
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные владельца</returns>
    [HttpGet(nameof(GetOwnerByIsn), Name = nameof(GetOwnerByIsn))]
    public async Task<ActionResult<OwnerDto>> GetOwnerByIsn(GetOwnerByIsnQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
 
    #endregion
 
    #region Car
 
    /// <summary>
    /// Создание автомобиля
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор автомобиля</returns>
    [HttpPost(nameof(CreateCar), Name = nameof(CreateCar))]
    public async Task<ActionResult<Guid>> CreateCar(CreateCarCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
 
    /// <summary>
    /// Редактирование данных автомобиля
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор автомобиля</returns>
    [HttpPost(nameof(UpdateCar), Name = nameof(UpdateCar))]
    public async Task<ActionResult<Guid>> UpdateCar(UpdateCarCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
 
    /// <summary>
    /// Удаление автомобиля
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPost(nameof(DeleteCar), Name = nameof(DeleteCar))]
    public async Task<ActionResult> DeleteCar(DeleteCarCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }
 
    /// <summary>
    /// Получение списка автомобилей
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список автомобилей</returns>
    [HttpGet(nameof(GetListCars), Name = nameof(GetListCars))]
    public async Task<ActionResult<CarDto[]>> GetListCars([FromQuery] GetListCarsQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
 
    /// <summary>
    /// Получение данных автомобиля
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные автомобиля</returns>
    [HttpGet(nameof(GetCarByIsn), Name = nameof(GetCarByIsn))]
    public async Task<ActionResult<CarDto>> GetCarByIsn(GetCarByIsnQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
 
    #endregion
 
    #region ServiceRecord
 
    /// <summary>
    /// Создание записи обслуживания
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор записи обслуживания</returns>
    [HttpPost(nameof(CreateServiceRecord), Name = nameof(CreateServiceRecord))]
    public async Task<ActionResult<Guid>> CreateServiceRecord(CreateServiceRecordCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
 
    /// <summary>
    /// Редактирование данных записи обслуживания
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор записи обслуживания</returns>
    [HttpPost(nameof(UpdateServiceRecord), Name = nameof(UpdateServiceRecord))]
    public async Task<ActionResult<Guid>> UpdateServiceRecord(UpdateServiceRecordCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
 
    /// <summary>
    /// Удаление записи обслуживания
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPost(nameof(DeleteServiceRecord), Name = nameof(DeleteServiceRecord))]
    public async Task<ActionResult> DeleteServiceRecord(DeleteServiceRecordCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }
 
    /// <summary>
    /// Получение списка записей обслуживания
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список записей обслуживания</returns>
    [HttpGet(nameof(GetListServiceRecords), Name = nameof(GetListServiceRecords))]
    public async Task<ActionResult<ServiceRecordDto[]>> GetListServiceRecords([FromQuery] GetListServiceRecordsQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
 
    /// <summary>
    /// Получение данных записи обслуживания
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные записи обслуживания</returns>
    [HttpGet(nameof(GetServiceRecordByIsn), Name = nameof(GetServiceRecordByIsn))]
    public async Task<ActionResult<ServiceRecordDto>> GetServiceRecordByIsn(GetServiceRecordByIsnQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
 
    #endregion
}