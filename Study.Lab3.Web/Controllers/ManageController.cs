using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Web.Features.University.Groups.Commands;
using Study.Lab3.Web.Features.University.Groups.DtoModels;
using Study.Lab3.Web.Features.University.Groups.Queries;
using Study.Lab3.Web.Features.University.Students.Commands;
using Study.Lab3.Web.Features.University.Students.DtoModels;
using Study.Lab3.Web.Features.University.Students.Queries;
using Study.Lab3.Web.Features.University.Subjects.Commands;
using Study.Lab3.Web.Features.University.Subjects.Queries;

namespace Study.Lab3.Web.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class ManageController : Controller
{
    private readonly IMediator _mediator;

    public ManageController(IMediator mediator)
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
    [HttpPost(nameof(CreateGroup), Name = nameof(CreateGroup))]
    public async Task<ActionResult<Guid>> CreateGroup(CreateGroupCommand command, CancellationToken cancellationToken)
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
    [HttpPost(nameof(UpdateGroup), Name = nameof(UpdateGroup))]
    public async Task<ActionResult<Guid>> UpdateGroup(UpdateGroupCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление группы
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPost(nameof(DeleteGroup), Name = nameof(DeleteGroup))]
    public async Task<ActionResult<Guid>> DeleteGroup(DeleteGroupCommand command, CancellationToken cancellationToken)
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
    [HttpGet(nameof(GetListGroups), Name = nameof(GetListGroups))]
    public async Task<ActionResult<GroupItemDto[]>> GetListGroups([FromQuery] GetListGroupsQuery query, CancellationToken cancellationToken)
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
    [HttpGet(nameof(GetGroupByIsn), Name = nameof(GetGroupByIsn))]
    public async Task<ActionResult<GroupDto>> GetGroupByIsn(GetGroupByIsnQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение список групп с предметами
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список групп с предметами</returns>
    [HttpGet(nameof(GetListGroupsWithSubjects), Name = nameof(GetListGroupsWithSubjects))]
    public async Task<ActionResult<GroupWithSubjectItemDto[]>> GetListGroupsWithSubjects([FromQuery] GetListGroupsWithSubjectsQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region Student

    /// <summary>
    /// Создание студента
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор студента</returns>
    [HttpPost(nameof(CreateStudent), Name = nameof(CreateStudent))]
    public async Task<ActionResult<Guid>> CreateStudent(CreateStudentCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование студента
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор студента</returns>
    [HttpPost(nameof(UpdateStudent), Name = nameof(UpdateStudent))]
    public async Task<ActionResult<Guid>> UpdateStudent(UpdateStudentCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление студента
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор студента</returns>
    [HttpPost(nameof(DeleteStudent), Name = nameof(DeleteStudent))]
    public async Task<ActionResult<Guid>> DeleteStudent(DeleteStudentCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение списка студентов
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список студентов</returns>
    [HttpGet(nameof(GetListStudents), Name = nameof(GetListStudents))]
    public async Task<ActionResult<StudentItemDto[]>> GetListStudents([FromQuery] GetListStudentsQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение данных студента
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные студента</returns>
    [HttpGet(nameof(GetStudentByIsn), Name = nameof(GetStudentByIsn))]
    public async Task<ActionResult<StudentDto>> GetStudentByIsn(GetStudentByIsnQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region Subject

    /// <summary>
    /// Создание предмета
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор предмета</returns>
    [HttpPost(nameof(CreateSubject), Name = nameof(CreateSubject))]
    public async Task<ActionResult<Guid>> CreateSubject(CreateSubjectCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование данных предмета
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор предмета</returns>
    [HttpPost(nameof(UpdateSubject), Name = nameof(UpdateSubject))]
    public async Task<ActionResult<Guid>> UpdateSubject(UpdateSubjectCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление предмета
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPost(nameof(DeleteSubject), Name = nameof(DeleteSubject))]
    public async Task<ActionResult<Guid>> DeleteSubject(DeleteSubjectCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение списка предметов
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список предметов</returns>
    [HttpGet(nameof(GetListSubjects), Name = nameof(GetListSubjects))]
    public async Task<ActionResult<StudentItemDto[]>> GetListSubjects([FromQuery] GetListSubjectsQuery query, CancellationToken cancellationToken)
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
    [HttpGet(nameof(GetSubjectByIsn), Name = nameof(GetSubjectByIsn))]
    public async Task<ActionResult<StudentDto>> GetSubjectByIsn(GetSubjectByIsnQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Привязать группу к предмету
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPost(nameof(AddGroupAndSubject), Name = nameof(AddGroupAndSubject))]
    public async Task<ActionResult> AddGroupAndSubject(AddGroupAndSubjectCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Отвязать группу от предмета
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPost(nameof(DeleteGroupAndSubject), Name = nameof(DeleteGroupAndSubject))]
    public async Task<ActionResult> DeleteGroupAndSubject(DeleteGroupAndSubjectCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    #endregion
}
