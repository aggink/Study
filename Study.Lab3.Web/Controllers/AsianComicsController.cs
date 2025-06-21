using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Web.Features.AsianComics.Manga.Commands;
using Study.Lab3.Web.Features.AsianComics.Manga.DtoModels;
using Study.Lab3.Web.Features.AsianComics.Manga.Queries;
using Study.Lab3.Web.Features.AsianComics.Manhua.Commands;
using Study.Lab3.Web.Features.AsianComics.Manhua.DtoModels;
using Study.Lab3.Web.Features.AsianComics.Manhua.Queries;
using Study.Lab3.Web.Features.AsianComics.Manhva.Commands;
using Study.Lab3.Web.Features.AsianComics.Manhva.DtoModels;
using Study.Lab3.Web.Features.AsianComics.Manhva.Queries;

namespace Study.Lab3.Web.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class AsianComicsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AsianComicsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region Manga

    /// <summary>
    /// Создать новую запись
    /// </summary>
    [HttpPost(nameof(CreateManga), Name = nameof(CreateManga))]
    public async Task<ActionResult<Guid>> CreateManga(CreateMangaCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Обновить существующую запись
    /// </summary>
    [HttpPost(nameof(UpdateManga), Name = nameof(UpdateManga))]
    public async Task<ActionResult<Guid>> UpdateManga(UpdateMangaCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удалить запись
    /// </summary>
    [HttpPost(nameof(DeleteManga), Name = nameof(DeleteManga))]
    public async Task<ActionResult> DeleteManga(DeleteMangaCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получить запись по идентификатору
    /// </summary>
    [HttpGet(nameof(GetMangaByIsn), Name = nameof(GetMangaByIsn))]
    public async Task<ActionResult<MangaDto>> GetMangaByIsn([FromQuery] GetMangaByIsnQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    /// <summary>
    /// Получить список всех записей
    /// </summary>
    [HttpGet(nameof(GetListManga), Name = nameof(GetListManga))]
    public async Task<ActionResult<MangaDto[]>> GetListManga([FromQuery] GetListMangaQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region Manhva

    /// <summary>
    /// Создать новую запись
    /// </summary>
    [HttpPost(nameof(CreateManhva), Name = nameof(CreateManhva))]
    public async Task<ActionResult<Guid>> CreateManhva(CreateManhvaCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Обновить существующую запись
    /// </summary>
    [HttpPost(nameof(UpdateManhva), Name = nameof(UpdateManhva))]
    public async Task<ActionResult<Guid>> UpdateManhva(UpdateManhvaCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удалить запись
    /// </summary>
    [HttpPost(nameof(DeleteManhva), Name = nameof(DeleteManhva))]
    public async Task<ActionResult> DeleteManhva(DeleteManhvaCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получить запись по идентификатору
    /// </summary>
    [HttpGet(nameof(GetManhvaByIsn), Name = nameof(GetManhvaByIsn))]
    public async Task<ActionResult<ManhvaDto>> GetManhvaByIsn([FromQuery] GetManhvaByIsnQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    /// <summary>
    /// Получить список всех записей
    /// </summary>
    [HttpGet(nameof(GetListManhva), Name = nameof(GetListManhva))]
    public async Task<ActionResult<ManhvaDto[]>> GetListManhva([FromQuery] GetListManhvaQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region Manhua

    /// <summary>
    /// Создать новую запись
    /// </summary>
    [HttpPost(nameof(CreateManhua), Name = nameof(CreateManhua))]
    public async Task<ActionResult<Guid>> CreateManhua(CreateManhuaCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Обновить существующую запись
    /// </summary>
    [HttpPost(nameof(UpdateManhua), Name = nameof(UpdateManhua))]
    public async Task<ActionResult<Guid>> UpdateManhua(UpdateManhuaCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удалить запись
    /// </summary>
    [HttpPost(nameof(DeleteManhua), Name = nameof(DeleteManhua))]
    public async Task<ActionResult> DeleteManhua(DeleteManhuaCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получить запись по идентификатору
    /// </summary>
    [HttpGet(nameof(GetManhuaByIsn), Name = nameof(GetManhuaByIsn))]
    public async Task<ActionResult<ManhuaDto>> GetManhuaByIsn([FromQuery] GetManhuaByIsnQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    /// <summary>
    /// Получить список всех записей
    /// </summary>
    [HttpGet(nameof(GetListManhua), Name = nameof(GetListManhua))]
    public async Task<ActionResult<ManhuaDto[]>> GetListManhua([FromQuery] GetListManhuaQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

}