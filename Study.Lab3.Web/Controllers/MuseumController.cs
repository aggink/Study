using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Web.Features.Museum.MuseumExhibits.Command;
using Study.Lab3.Web.Features.Museum.MuseumExhibits.DtoModels;
using Study.Lab3.Web.Features.Museum.MuseumExhibits.Queries;
using Study.Lab3.Web.Features.Museum.MuseumVisitors.Command;
using Study.Lab3.Web.Features.Museum.MuseumVisitors.DtoModels;
using Study.Lab3.Web.Features.Museum.MuseumVisitors.Queries;

namespace Study.Lab3.Web.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class MuseumController : Controller
{
    private readonly IMediator _mediator;

    public MuseumController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region Exhibits

    /// <summary>
    /// Создание экспоната музея
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор экспоната</returns>
    [HttpPost(nameof(CreateExhibit), Name = nameof(CreateExhibit))]
    public async Task<ActionResult<Guid>> CreateExhibit(CreateMuseumExhibitCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Обновление экспоната музея
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор экспоната</returns>
    [HttpPut(nameof(UpdateExhibit), Name = nameof(UpdateExhibit))]
    public async Task<ActionResult<Guid>> UpdateExhibit(UpdateMuseumExhibitCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление экспоната музея
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpDelete(nameof(DeleteExhibit), Name = nameof(DeleteExhibit))]
    public async Task<ActionResult> DeleteExhibit([FromQuery] DeleteMuseumExhibitCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение списка экспонатов
    /// </summary>
    /// <param name="query">Параметры запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список экспонатов</returns>
    [HttpGet(nameof(GetExhibits), Name = nameof(GetExhibits))]
    public async Task<ActionResult<MuseumExhibitDto[]>> GetExhibits([FromQuery] GetListMuseumExhibitsQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение экспоната с детальной информацией
    /// </summary>
    /// <param name="query">Параметры запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Экспонат с деталями</returns>
    [HttpGet(nameof(GetExhibitWithDetails), Name = nameof(GetExhibitWithDetails))]
    public async Task<ActionResult<MuseumExhibitWithDetailsDto>> GetExhibitWithDetails([FromQuery] GetMuseumExhibitWithDetailsQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Создание детальной информации об экспонате
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор детальной информации</returns>
    [HttpPost(nameof(CreateExhibitDetails), Name = nameof(CreateExhibitDetails))]
    public async Task<ActionResult<Guid>> CreateExhibitDetails(CreateMuseumExhibitDetailsCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
    
    /// <summary>
    /// Получение списка членов музея
    /// </summary>
    /// <param name="query">Параметры запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список членов музея</returns>
    [HttpGet(nameof(GetMembers), Name = nameof(GetMembers))]
    public async Task<ActionResult<MuseumVisitorDto[]>> GetMembers([FromQuery] GetMuseumMembersQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    #endregion

    #region Visitors

    /// <summary>
    /// Создание посетителя музея
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор посетителя</returns>
    [HttpPost(nameof(CreateVisitor), Name = nameof(CreateVisitor))]
    public async Task<ActionResult<Guid>> CreateVisitor(CreateMuseumVisitorCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Обновление данных посетителя музея
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPut(nameof(UpdateVisitor), Name = nameof(UpdateVisitor))]
    public async Task<ActionResult> UpdateVisitor(UpdateMuseumVisitorCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Удаление посетителя музея
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpDelete(nameof(DeleteVisitor), Name = nameof(DeleteVisitor))]
    public async Task<ActionResult> DeleteVisitor([FromQuery] DeleteMuseumVisitorCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение списка посетителей музея
    /// </summary>
    /// <param name="query">Параметры запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список посетителей</returns>
    [HttpGet(nameof(GetVisitors), Name = nameof(GetVisitors))]
    public async Task<ActionResult<MuseumVisitorDto[]>> GetVisitors([FromQuery] GetListMuseumVisitorsQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение посетителя по идентификатору
    /// </summary>
    /// <param name="query">Параметры запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные посетителя</returns>
    [HttpGet(nameof(GetVisitorById), Name = nameof(GetVisitorById))]
    public async Task<ActionResult<MuseumVisitorDto>> GetVisitorById([FromQuery] GetMuseumVisitorByIsnQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion
}