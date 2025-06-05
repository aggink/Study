using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Web.Features.BeautySalon.BeautyAppointment.Commands;
using Study.Lab3.Web.Features.BeautySalon.BeautyAppointment.DtoModels;
using Study.Lab3.Web.Features.BeautySalon.BeautyAppointment.Queries;
using Study.Lab3.Web.Features.BeautySalon.BeautyClient.Commands;
using Study.Lab3.Web.Features.BeautySalon.BeautyClient.DtoModels;
using Study.Lab3.Web.Features.BeautySalon.BeautyClient.Queries;
using Study.Lab3.Web.Features.BeautySalon.BeautyService.Commands;
using Study.Lab3.Web.Features.BeautySalon.BeautyService.DtoModels;
using Study.Lab3.Web.Features.BeautySalon.BeautyService.Queries;

namespace Study.Lab3.Web.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class BeautySalonController : ControllerBase
{
    private readonly IMediator _mediator;

    public BeautySalonController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region BeautyAppointments

    /// <summary>
    /// Создать новую запись
    /// </summary>
    [HttpPost(nameof(CreateAppointment), Name = nameof(CreateAppointment))]
    public async Task<ActionResult<Guid>> CreateAppointment(CreateAppointmentCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Обновить существующую запись
    /// </summary>
    [HttpPost(nameof(UpdateAppointment), Name = nameof(UpdateAppointment))]
    public async Task<ActionResult<Guid>> UpdateAppointment(UpdateAppointmentCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удалить запись
    /// </summary>
    [HttpPost(nameof(DeleteAppointment), Name = nameof(DeleteAppointment))]
    public async Task<ActionResult> DeleteAppointment(DeleteAppointmentCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получить запись по идентификатору
    /// </summary>
    [HttpGet(nameof(GetAppointmentByIsn), Name = nameof(GetAppointmentByIsn))]
    public async Task<ActionResult<AppointmentDto>> GetAppointmentByIsn([FromQuery] GetAppointmentByIsnQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    /// <summary>
    /// Получить список всех записей
    /// </summary>
    [HttpGet(nameof(GetListAppointments), Name = nameof(GetListAppointments))]
    public async Task<ActionResult<AppointmentDto[]>> GetListAppointments([FromQuery] GetListAppointmentsQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region BeautyServices

    /// <summary>
    /// Создать новую услугу
    /// </summary>
    [HttpPost(nameof(CreateService), Name = nameof(CreateService))]
    public async Task<ActionResult<Guid>> CreateService(CreateServiceCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Обновить существующую услугу
    /// </summary>
    [HttpPost(nameof(UpdateService), Name = nameof(UpdateService))]
    public async Task<ActionResult<Guid>> UpdateService(UpdateServiceCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удалить услугу
    /// </summary>
    [HttpPost(nameof(DeleteService), Name = nameof(DeleteService))]
    public async Task<ActionResult> DeleteService(DeleteServiceCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получить услугу по идентификатору
    /// </summary>
    [HttpGet(nameof(GetServiceByIsn), Name = nameof(GetServiceByIsn))]
    public async Task<ActionResult<ServiceDto>> GetServiceByIsn([FromQuery] GetServiceByIsnQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    /// <summary>
    /// Получить список всех услуг
    /// </summary>
    [HttpGet(nameof(GetListServices), Name = nameof(GetListServices))]
    public async Task<ActionResult<ServiceDto[]>> GetListServices([FromQuery] GetListServicesQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region BeautyClients

    /// <summary>
    /// Создать нового клиента
    /// </summary>
    [HttpPost(nameof(CreateClient), Name = nameof(CreateClient))]
    public async Task<ActionResult<Guid>> CreateClient(CreateClientCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Обновить существующего клиента
    /// </summary>
    [HttpPost(nameof(UpdateClient), Name = nameof(UpdateClient))]
    public async Task<ActionResult<Guid>> UpdateClient(UpdateClientCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удалить клиента
    /// </summary>
    [HttpPost(nameof(DeleteClient), Name = nameof(DeleteClient))]
    public async Task<ActionResult> DeleteClient(DeleteClientCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получить клиента по идентификатору
    /// </summary>
    [HttpGet(nameof(GetCLientByIsn), Name = nameof(GetCLientByIsn))]
    public async Task<ActionResult<ClientDto>> GetCLientByIsn([FromQuery] GetClientByIsnQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    /// <summary>
    /// Получить список всех клиентов
    /// </summary>
    [HttpGet(nameof(GetListClients), Name = nameof(GetListClients))]
    public async Task<ActionResult<ClientDto[]>> GetListClients([FromQuery] GetListClientsQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion
}