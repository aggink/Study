using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Web.Features.Messenger.ImageEmbeds.Commands;
using Study.Lab3.Web.Features.Messenger.ImageEmbeds.DtoModels;
using Study.Lab3.Web.Features.Messenger.ImageEmbeds.Queries;
using Study.Lab3.Web.Features.Messenger.Images.Commands;
using Study.Lab3.Web.Features.Messenger.Images.DtoModels;
using Study.Lab3.Web.Features.Messenger.Images.Queries;
using Study.Lab3.Web.Features.Messenger.Posts.Commands;
using Study.Lab3.Web.Features.Messenger.Posts.DtoModels;
using Study.Lab3.Web.Features.Messenger.Posts.Queries;
using Study.Lab3.Web.Features.Messenger.Users.Commands;
using Study.Lab3.Web.Features.Messenger.Users.DtoModels;
using Study.Lab3.Web.Features.Messenger.Users.Queries;

namespace Study.Lab3.Web.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class MessengerController : Controller
{
    private readonly IMediator _mediator;

    public MessengerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region Users

    /// <summary>
    /// Создание пользователя
    /// </summary>
    [HttpPost("users")]
    public async Task<ActionResult<Guid>> CreateUser(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование пользователя
    /// </summary>
    [HttpPut("users")]
    public async Task<ActionResult<Guid>> UpdateUser(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление пользователя
    /// </summary>
    [HttpDelete("users")]
    public async Task<ActionResult> DeleteUser(DeleteUserCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение списка пользователей
    /// </summary>
    [HttpGet("users")]
    public async Task<ActionResult<UserDto[]>> GetUserList(CancellationToken cancellationToken)
    {
        var query = new GetUserListQuery();
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение пользователя по идентификатору
    /// </summary>
    [HttpGet("users/{Id}")]
    public async Task<ActionResult<UserDto>> GetUserById(GetUserByIdQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    /// <summary>
    /// Получение пользователя по почтовому адресу
    /// </summary>
    [HttpGet("users/email/{Email}")]
    public async Task<ActionResult<UserDto>> GetUserByEmail(GetUserByEmailQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    /// <summary>
    /// Получение списка пользователей по имени
    /// </summary>
    [HttpGet("users/username/{Username}")]
    public async Task<ActionResult<UserDto>> GetUserListByUsernameQuery(GetUserListByUsernameQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    #endregion

    #region Posts

    /// <summary>
    /// Создание сообщения
    /// </summary>
    [HttpPost("posts")]
    public async Task<ActionResult<Guid>> CreatePost(CreatePostCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование сообщения
    /// </summary>
    [HttpPut("posts")]
    public async Task<ActionResult<Guid>> UpdatePost(UpdatePostCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление сообщения
    /// </summary>
    [HttpDelete("posts")]
    public async Task<ActionResult> DeletePost(DeletePostCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение всех сообщений
    /// </summary>
    [HttpGet("posts")]
    public async Task<ActionResult<PostDto[]>> GetPostList(CancellationToken cancellationToken)
    {
        var query = new GetPostListQuery();
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение сообщения по идентификатору
    /// </summary>
    [HttpGet("posts/{Id}")]
    public async Task<ActionResult<PostDto>> GetPostById(GetPostByIdQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    /// <summary>
    /// Получение сообщений по идентификатору пользователя
    /// </summary>
    [HttpGet("posts/user_id/{UserId}")]
    public async Task<ActionResult<PostDto[]>> GetPostListByUserId(GetPostListByUserIdQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    #endregion

    #region Images

    /// <summary>
    /// Создание изображения
    /// </summary>
    [HttpPost("images")]
    public async Task<ActionResult<Guid>> CreateImage(CreateImageCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование изображения
    /// </summary>
    [HttpPut("images")]
    public async Task<ActionResult<Guid>> UpdateImage(UpdateImageCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление изображения
    /// </summary>
    [HttpDelete("images")]
    public async Task<ActionResult> DeleteImage(DeleteImageCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение всех сообщений
    /// </summary>
    [HttpGet("images")]
    public async Task<ActionResult<ImageDto[]>> GetImageList(CancellationToken cancellationToken)
    {
        var query = new GetImageListQuery();
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение изображения по идентификатору
    /// </summary>
    [HttpGet("images/{Id}")]
    public async Task<ActionResult<ImageDto>> GetImageById(GetImageByIdQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    #endregion

    #region ImageEmbeds

    /// <summary>
    /// Создание вставки
    /// </summary>
    [HttpPost("image_embeds")]
    public async Task<ActionResult<Guid>> CreateImageEmbed(CreateImageEmbedCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование вставки
    /// </summary>
    [HttpPut("image_embeds")]
    public async Task<ActionResult<Guid>> UpdateImageEmbed(UpdateImageEmbedCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление вставки
    /// </summary>
    [HttpDelete("image_embeds")]
    public async Task<ActionResult> DeleteImageEmbed(DeleteImageEmbedCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение всех сообщений
    /// </summary>
    [HttpGet("image_embeds")]
    public async Task<ActionResult<ImageEmbedDto[]>> GetImageEmbedList(CancellationToken cancellationToken)
    {
        var query = new GetImageEmbedListQuery();
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение вставок по идентификатору сообщения
    /// </summary>
    [HttpGet("image_embeds/post_id/{PostId}")]
    public async Task<ActionResult<ImageEmbedDto[]>> GetImageEmbedListByPostId(GetImageEmbedListByPostIdQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    /// <summary>
    /// Получение вставок по идентификатору изображения
    /// </summary>
    [HttpGet("image_embeds/image_id/{ImageId}")]
    public async Task<ActionResult<ImageEmbedDto[]>> GetImageEmbedListByImageId(GetImageEmbedListByImageIdQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    #endregion
}
