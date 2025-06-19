using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Web.Features.Photography.Clients.Commands;
using Study.Lab3.Web.Features.Photography.Clients.DtoModels;
using Study.Lab3.Web.Features.Photography.Clients.Queries;
using Study.Lab3.Web.Features.Photography.Equipment.Commands;
using Study.Lab3.Web.Features.Photography.Equipment.DtoModels;
using Study.Lab3.Web.Features.Photography.Equipment.Queries;
using Study.Lab3.Web.Features.Photography.Sessions.Commands;
using Study.Lab3.Web.Features.Photography.Sessions.DtoModels;
using Study.Lab3.Web.Features.Photography.Sessions.Queries;

namespace Study.Lab3.Web.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class PhotographyController : Controller
{
    private readonly IMediator _mediator;

    public PhotographyController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region PhotographyClient

    /// <summary>
    /// Создание клиента фотостудии
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор клиента</returns>
    [HttpPost(nameof(CreatePhotographyClient), Name = nameof(CreatePhotographyClient))]
    public async Task<ActionResult<Guid>> CreatePhotographyClient(CreatePhotographyClientCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование данных клиента фотостудии
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор клиента</returns>
    [HttpPost(nameof(UpdatePhotographyClient), Name = nameof(UpdatePhotographyClient))]
    public async Task<ActionResult<Guid>> UpdatePhotographyClient(UpdatePhotographyClientCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление клиента фотостудии
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPost(nameof(DeletePhotographyClient), Name = nameof(DeletePhotographyClient))]
    public async Task<ActionResult> DeletePhotographyClient(DeletePhotographyClientCommand command,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение списка клиентов фотостудии
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список клиентов</returns>
    [HttpGet(nameof(GetListPhotographyClients), Name = nameof(GetListPhotographyClients))]
    public async Task<ActionResult<PhotographyClientDto[]>> GetListPhotographyClients(
        [FromQuery] GetListPhotographyClientsQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение данных клиента фотостудии
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные клиента</returns>
    [HttpGet(nameof(GetPhotographyClientByIsn), Name = nameof(GetPhotographyClientByIsn))]
    public async Task<ActionResult<PhotographyClientDto>> GetPhotographyClientByIsn(
        GetPhotographyClientByIsnQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region PhotographyEquipment

    /// <summary>
    /// Создание оборудования фотостудии
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор оборудования</returns>
    [HttpPost(nameof(CreatePhotographyEquipment), Name = nameof(CreatePhotographyEquipment))]
    public async Task<ActionResult<Guid>> CreatePhotographyEquipment(CreatePhotographyEquipmentCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование оборудования фотостудии
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор оборудования</returns>
    [HttpPost(nameof(UpdatePhotographyEquipment), Name = nameof(UpdatePhotographyEquipment))]
    public async Task<ActionResult<Guid>> UpdatePhotographyEquipment(UpdatePhotographyEquipmentCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление оборудования фотостудии
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPost(nameof(DeletePhotographyEquipment), Name = nameof(DeletePhotographyEquipment))]
    public async Task<ActionResult> DeletePhotographyEquipment(DeletePhotographyEquipmentCommand command,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение списка оборудования фотостудии
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список оборудования</returns>
    [HttpGet(nameof(GetListPhotographyEquipment), Name = nameof(GetListPhotographyEquipment))]
    public async Task<ActionResult<PhotographyEquipmentDto[]>> GetListPhotographyEquipment(
        [FromQuery] GetListPhotographyEquipmentQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение данных оборудования фотостудии
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные оборудования</returns>
    [HttpGet(nameof(GetPhotographyEquipmentByIsn), Name = nameof(GetPhotographyEquipmentByIsn))]
    public async Task<ActionResult<PhotographyEquipmentDto>> GetPhotographyEquipmentByIsn(
        GetPhotographyEquipmentByIsnQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region PhotographySession

    /// <summary>
    /// Создание фотосессии
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор фотосессии</returns>
    [HttpPost(nameof(CreatePhotographySession), Name = nameof(CreatePhotographySession))]
    public async Task<ActionResult<Guid>> CreatePhotographySession(CreatePhotographySessionCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование фотосессии
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор фотосессии</returns>
    [HttpPost(nameof(UpdatePhotographySession), Name = nameof(UpdatePhotographySession))]
    public async Task<ActionResult<Guid>> UpdatePhotographySession(UpdatePhotographySessionCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление фотосессии
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPost(nameof(DeletePhotographySession), Name = nameof(DeletePhotographySession))]
    public async Task<ActionResult> DeletePhotographySession(DeletePhotographySessionCommand command,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение списка фотосессий
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список фотосессий</returns>
    [HttpGet(nameof(GetListPhotographySessions), Name = nameof(GetListPhotographySessions))]
    public async Task<ActionResult<PhotographySessionDto[]>> GetListPhotographySessions(
        [FromQuery] GetListPhotographySessionsQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение данных фотосессии
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные фотосессии</returns>
    [HttpGet(nameof(GetPhotographySessionByIsn), Name = nameof(GetPhotographySessionByIsn))]
    public async Task<ActionResult<PhotographySessionDto>> GetPhotographySessionByIsn(
        GetPhotographySessionByIsnQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion
}