using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Web.Features.Sweets.SweetType.Commands;
using Study.Lab3.Web.Features.Sweets.SweetFactory.Commands;
using Study.Lab3.Web.Features.Sweets.Sweet.Queries;
using Study.Lab3.Web.Features.Sweets.Sweet.Commands;
using Study.Lab3.Web.Features.Sweets.SweetProduction.Commands;
using Study.Lab3.Web.Features.Sweets.SweetType.DtoModels;
using Study.Lab3.Web.Features.Sweets.SweetType.Queries;
using Study.Lab3.Web.Features.Sweets.SweetProduction.Queries;
using Study.Lab3.Web.Features.Sweets.SweetFactory.Queries;
using Study.Lab3.Web.Features.Sweets.SweetFactory.DtoModels;
using Study.Lab3.Web.Features.Sweets.SweetProduction.DtoModels;
using Study.Lab3.Web.Features.Sweets.Sweet.DtoModels;

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

    #region SweetProduction

    /// <summary>
    /// Создание записи
    /// </summary>
    [HttpPost(nameof(CreateSweetProduction), Name = nameof(CreateSweetProduction))]
    public async Task<ActionResult<Guid>> CreateSweetProduction(CreateSweetProductionCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Обновление записи
    /// </summary>
    [HttpPost(nameof(UpdateSweetProduction), Name = nameof(UpdateSweetProduction))]
    public async Task<ActionResult<Guid>> UpdateSweetProduction(UpdateSweetProductionCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление записи
    /// </summary>
    [HttpPost(nameof(DeleteSweetProduction), Name = nameof(DeleteSweetProduction))]
    public async Task<ActionResult> DeleteSweetProduction(DeleteSweetProductionCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение записи по идентификатору
    /// </summary>
    [HttpGet(nameof(GetSweetProductionById), Name = nameof(GetSweetProductionById))]
    public async Task<ActionResult<SweetProductionDto>> GetSweetProductionById([FromQuery] GetSweetProductionByIdQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение списка записей
    /// </summary>
    [HttpGet(nameof(GetListSweetProduction), Name = nameof(GetListSweetProduction))]
    public async Task<ActionResult<SweetProductionDto[]>> GetListSweetProduction([FromQuery] GetListSweetProductionQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region SweetType

    /// <summary>
    /// Создание типа сладости
    /// </summary>
    [HttpPost(nameof(CreateSweetType), Name = nameof(CreateSweetType))]
    public async Task<ActionResult<Guid>> CreateSweetType(CreateSweetTypeCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Обновление типа сладости
    /// </summary>
    [HttpPost(nameof(UpdateSweetType), Name = nameof(UpdateSweetType))]
    public async Task<ActionResult<Guid>> UpdateSweetType(UpdateSweetTypeCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление типа сладости
    /// </summary>
    [HttpPost(nameof(DeleteSweetType), Name = nameof(DeleteSweetType))]
    public async Task<ActionResult> DeleteSweetType(DeleteSweetTypeCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение типа сладости по идентификатору
    /// </summary>
    [HttpGet(nameof(GetSweetTypeById), Name = nameof(GetSweetTypeById))]
    public async Task<ActionResult<SweetTypeDto>> GetSweetTypeById([FromQuery] GetSweetTypeByIdQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение списка типов сладости
    /// </summary>
    [HttpGet(nameof(GetListSweetType), Name = nameof(GetListSweetType))]
    public async Task<ActionResult<SweetTypeDto[]>> GetListSweetType([FromQuery] GetListSweetTypeQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion
}