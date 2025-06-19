using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Web.Features.MusicStore.Albums.Commands;
using Study.Lab3.Web.Features.MusicStore.Albums.DtoModels;
using Study.Lab3.Web.Features.MusicStore.Albums.Queries;
using Study.Lab3.Web.Features.MusicStore.Artists.Commands;
using Study.Lab3.Web.Features.MusicStore.Artists.DtoModels;
using Study.Lab3.Web.Features.MusicStore.Artists.Queries;
using Study.Lab3.Web.Features.MusicStore.Customers.Commands;
using Study.Lab3.Web.Features.MusicStore.Customers.DtoModels;
using Study.Lab3.Web.Features.MusicStore.Customers.Queries;

namespace Study.Lab3.Web.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class MusicStoreController : Controller
{
    private readonly IMediator _mediator;

    public MusicStoreController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    #region Albums

    /// <summary>
    /// Создание музыкального альбома
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор альбома</returns>
    [HttpPost(nameof(CreateAlbum), Name = nameof(CreateAlbum))]
    public async Task<ActionResult<Guid>> CreateAlbum(CreateMusicAlbumCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование музыкального альбома
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор альбома</returns>
    [HttpPost(nameof(UpdateAlbum), Name = nameof(UpdateAlbum))]
    public async Task<ActionResult<Guid>> UpdateAlbum(UpdateMusicAlbumCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление музыкального альбома
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPost(nameof(DeleteAlbum), Name = nameof(DeleteAlbum))]
    public async Task<ActionResult> DeleteAlbum(DeleteMusicAlbumCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение списка альбомов
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список альбомов</returns>
    [HttpGet(nameof(GetListAlbums), Name = nameof(GetListAlbums))]
    public async Task<ActionResult<MusicAlbumDto[]>> GetListAlbums([FromQuery] GetListMusicAlbumsQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение альбома по идентификатору
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные альбома</returns>
    [HttpGet(nameof(GetAlbumByIsn), Name = nameof(GetAlbumByIsn))]
    public async Task<ActionResult<MusicAlbumDto>> GetAlbumByIsn(GetMusicAlbumByIsnQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region Artists

    /// <summary>
    /// Создание музыкального исполнителя
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор исполнителя</returns>
    [HttpPost(nameof(CreateArtist), Name = nameof(CreateArtist))]
    public async Task<ActionResult<Guid>> CreateArtist(CreateMusicArtistCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование музыкального исполнителя
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор исполнителя</returns>
    [HttpPost(nameof(UpdateArtist), Name = nameof(UpdateArtist))]
    public async Task<ActionResult<Guid>> UpdateArtist(UpdateMusicArtistCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление музыкального исполнителя
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPost(nameof(DeleteArtist), Name = nameof(DeleteArtist))]
    public async Task<ActionResult> DeleteArtist(DeleteMusicArtistCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение списка исполнителей
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список исполнителей</returns>
    [HttpGet(nameof(GetListArtists), Name = nameof(GetListArtists))]
    public async Task<ActionResult<MusicArtistDto[]>> GetListArtists([FromQuery] GetListMusicArtistsQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение исполнителя по идентификатору
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные исполнителя</returns>
    [HttpGet(nameof(GetArtistByIsn), Name = nameof(GetArtistByIsn))]
    public async Task<ActionResult<MusicArtistDto>> GetArtistByIsn(GetMusicArtistByIsnQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region Customers

    /// <summary>
    /// Создание покупателя
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор покупателя</returns>
    [HttpPost(nameof(CreateCustomer), Name = "CreateMusicCustomer")]
    public async Task<ActionResult<Guid>> CreateCustomer(CreateMusicCustomerCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование покупателя
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор покупателя</returns>
    [HttpPost(nameof(UpdateCustomer), Name = "UpdateMusicCustomer")]
    public async Task<ActionResult<Guid>> UpdateCustomer(UpdateMusicCustomerCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление покупателя
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPost(nameof(DeleteCustomer), Name = "DeleteMusicCustomer")]
    public async Task<ActionResult> DeleteCustomer(DeleteMusicCustomerCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение списка покупателей
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список покупателей</returns>
    [HttpGet(nameof(GetListCustomers), Name = "GetListMusicCustomers")]
    public async Task<ActionResult<MusicCustomerDto[]>> GetListCustomers([FromQuery] GetListMusicCustomersQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение покупателя по идентификатору
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные покупателя</returns>
    [HttpGet(nameof(GetCustomerByIsn), Name = "GetMusicCustomerByIsn")]
    public async Task<ActionResult<MusicCustomerDto>> GetCustomerByIsn(GetMusicCustomerByIsnQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion
}