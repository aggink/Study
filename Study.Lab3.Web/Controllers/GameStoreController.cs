using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Web.Features.GameStore.Developers.Commands;
using Study.Lab3.Web.Features.GameStore.Developers.DtoModels;
using Study.Lab3.Web.Features.GameStore.Developers.Queries;
using Study.Lab3.Web.Features.GameStore.Games.Commands;
using Study.Lab3.Web.Features.GameStore.Games.DtoModels;
using Study.Lab3.Web.Features.GameStore.Games.Queries;
using Study.Lab3.Web.Features.GameStore.Platforms.Commands;
using Study.Lab3.Web.Features.GameStore.Platforms.DtoModels;
using Study.Lab3.Web.Features.GameStore.Platforms.Queries;

namespace Study.Lab3.Web.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class GameStoreController : Controller
{
    private readonly IMediator _mediator;

    public GameStoreController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region Game

    /// <summary>
    /// Создание игры
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор игры</returns>
    [HttpPost(nameof(CreateGame), Name = nameof(CreateGame))]
    public async Task<ActionResult<Guid>> CreateGame(CreateGameCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование данных игры
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор игры</returns>
    [HttpPost(nameof(UpdateGame), Name = nameof(UpdateGame))]
    public async Task<ActionResult<Guid>> UpdateGame(UpdateGameCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление игры
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPost(nameof(DeleteGame), Name = nameof(DeleteGame))]
    public async Task<ActionResult> DeleteGame(DeleteGameCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение списка игр
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список игр</returns>
    [HttpGet(nameof(GetListGames), Name = nameof(GetListGames))]
    public async Task<ActionResult<GameDto[]>> GetListGames([FromQuery] GetListGamesQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение данных игры
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные игры</returns>
    [HttpGet(nameof(GetGameByIsn), Name = nameof(GetGameByIsn))]
    public async Task<ActionResult<GameDto>> GetGameByIsn([FromQuery] GetGameByIsnQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение игры с деталями разработчика
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Игра с деталями</returns>
    [HttpGet(nameof(GetGameWithDetails), Name = nameof(GetGameWithDetails))]
    public async Task<ActionResult<GameWithDetailsDto>> GetGameWithDetails([FromQuery] GetGameWithDetailsQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region Developer

    /// <summary>
    /// Создание разработчика
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор разработчика</returns>
    [HttpPost(nameof(CreateDeveloper), Name = nameof(CreateDeveloper))]
    public async Task<ActionResult<Guid>> CreateDeveloper(CreateDeveloperCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование данных разработчика
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор разработчика</returns>
    [HttpPost(nameof(UpdateDeveloper), Name = nameof(UpdateDeveloper))]
    public async Task<ActionResult<Guid>> UpdateDeveloper(UpdateDeveloperCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление разработчика
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPost(nameof(DeleteDeveloper), Name = nameof(DeleteDeveloper))]
    public async Task<ActionResult> DeleteDeveloper(DeleteDeveloperCommand command,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение списка разработчиков
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список разработчиков</returns>
    [HttpGet(nameof(GetListDevelopers), Name = nameof(GetListDevelopers))]
    public async Task<ActionResult<DeveloperDto[]>> GetListDevelopers([FromQuery] GetListDevelopersQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение данных разработчика
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные разработчика</returns>
    [HttpGet(nameof(GetDeveloperByIsn), Name = nameof(GetDeveloperByIsn))]
    public async Task<ActionResult<DeveloperDto>> GetDeveloperByIsn([FromQuery] GetDeveloperByIsnQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение разработчика с количеством игр
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Разработчик с деталями</returns>
    [HttpGet(nameof(GetDeveloperWithDetails), Name = nameof(GetDeveloperWithDetails))]
    public async Task<ActionResult<DeveloperWithDetailsDto>> GetDeveloperWithDetails(
        [FromQuery] GetDeveloperWithDetailsQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region Platform

    /// <summary>
    /// Создание платформы
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор платформы</returns>
    [HttpPost(nameof(CreatePlatform), Name = nameof(CreatePlatform))]
    public async Task<ActionResult<Guid>> CreatePlatform(CreatePlatformCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование данных платформы
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор платформы</returns>
    [HttpPost(nameof(UpdatePlatform), Name = nameof(UpdatePlatform))]
    public async Task<ActionResult<Guid>> UpdatePlatform(UpdatePlatformCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление платформы
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPost(nameof(DeletePlatform), Name = nameof(DeletePlatform))]
    public async Task<ActionResult> DeletePlatform(DeletePlatformCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение списка платформ
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список платформ</returns>
    [HttpGet(nameof(GetListPlatforms), Name = nameof(GetListPlatforms))]
    public async Task<ActionResult<PlatformDto[]>> GetListPlatforms([FromQuery] GetListPlatformsQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение данных платформы
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные платформы</returns>
    [HttpGet(nameof(GetPlatformByIsn), Name = nameof(GetPlatformByIsn))]
    public async Task<ActionResult<PlatformDto>> GetPlatformByIsn([FromQuery] GetPlatformByIsnQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion
}