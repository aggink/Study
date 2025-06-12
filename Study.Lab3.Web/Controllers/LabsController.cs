using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Web.Features.University.Groups.Commands;
using Study.Lab3.Web.Features.University.Labs.Commands;
using Study.Lab3.Web.Features.University.Labs.DtoModels;
using Study.Lab3.Web.Features.University.Labs.Queries;


namespace Study.Lab3.Web.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class LabsController : Controller
{
    private readonly IMediator _mediator;

    public LabsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region Group

    /// <summary>
    /// Создание группы
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор группы</returns>
    [HttpPost(nameof(CreateLab), Name = nameof(CreateLab))]
    public async Task<ActionResult<Guid>> CreateLab(CreateLabCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование данных группы
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор группы</returns>
    [HttpPost(nameof(UpdateLab), Name = nameof(UpdateLab))]
    public async Task<ActionResult<Guid>> UpdateLab(UpdateLabCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление группы
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPost(nameof(DeleteLab), Name = nameof(DeleteLab))]
    public async Task<ActionResult<Guid>> DeleteLab(DeleteLabCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение списка групп
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список групп</returns>
    [HttpGet(nameof(GetListLabs), Name = nameof(GetListLabs))]
    public async Task<ActionResult<LabItemDto[]>> GetListLabs([FromQuery] GetListLabsQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение данных группы
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные группы</returns>
    [HttpGet(nameof(GetLabByIsn), Name = nameof(GetLabByIsn))]
    public async Task<ActionResult<LabDto>> GetLabByIsn(GetLabByIsnQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    /// <summary>
    /// Создание группы
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор группы</returns>
    [HttpPost(nameof(CreateStudentLab), Name = nameof(CreateStudentLab))]
    public async Task<ActionResult<Guid>> CreateStudentLab(CreateStudentLabCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование данных группы
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор группы</returns>
    [HttpPost(nameof(UpdateStudentLab), Name = nameof(UpdateStudentLab))]
    public async Task<ActionResult<Guid>> UpdateStudentLab(UpdateStudentLabCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление группы
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPost(nameof(DeleteStudentLab), Name = nameof(DeleteStudentLab))]
    public async Task<ActionResult<Guid>> DeleteStudentLab(DeleteStudentLabCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение списка групп
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список групп</returns>
    [HttpGet(nameof(GetListStudentLab), Name = nameof(GetListStudentLab))]
    public async Task<ActionResult<StudentLabItemDto[]>> GetListStudentLab([FromQuery] GetListLabsQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение данных группы
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные группы</returns>
    [HttpGet(nameof(GetStudentLabByIsn), Name = nameof(GetStudentLabByIsn))]
    public async Task<ActionResult<StudentLabDto>> GetStudentLabByIsn(GetStudentLabByIsnQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

}