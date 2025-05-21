using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Web.Features.University.Announcements.Commands;
using Study.Lab3.Web.Features.University.Announcements.DtoModels;
using Study.Lab3.Web.Features.University.Announcements.Queries;
using Study.Lab3.Web.Features.University.Assignments.Commands;
using Study.Lab3.Web.Features.University.Assignments.DtoModels;
using Study.Lab3.Web.Features.University.Assignments.Queries;
using Study.Lab3.Web.Features.University.Grades.Commands;
using Study.Lab3.Web.Features.University.Grades.DtoModels;
using Study.Lab3.Web.Features.University.Grades.Queries;
using Study.Lab3.Web.Features.University.Groups.Commands;
using Study.Lab3.Web.Features.University.Groups.DtoModels;
using Study.Lab3.Web.Features.University.Groups.Queries;
using Study.Lab3.Web.Features.University.Materials.Commands;
using Study.Lab3.Web.Features.University.Materials.DtoModels;
using Study.Lab3.Web.Features.University.Materials.Queries;
using Study.Lab3.Web.Features.University.Students.Commands;
using Study.Lab3.Web.Features.University.Students.DtoModels;
using Study.Lab3.Web.Features.University.Students.Queries;
using Study.Lab3.Web.Features.University.Subjects.Commands;
using Study.Lab3.Web.Features.University.Subjects.Queries;
using Study.Lab3.Web.Features.University.Teachers.Commands;
using Study.Lab3.Web.Features.University.Teachers.DtoModels;
using Study.Lab3.Web.Features.University.Teachers.Queries;
using Study.Lab3.Web.Features.University.TeacherSubjects.Commands;
using Study.Lab3.Web.Features.University.TeacherSubjects.DtoModels;
using Study.Lab3.Web.Features.University.TeacherSubjects.Queries;

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
    public async Task<ActionResult<GroupItemDto[]>> GetListGroups([FromQuery] GetListGroupsQuery query,
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
    [HttpGet(nameof(GetGroupByIsn), Name = nameof(GetGroupByIsn))]
    public async Task<ActionResult<GroupDto>> GetGroupByIsn(GetGroupByIsnQuery query,
        CancellationToken cancellationToken)
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
    public async Task<ActionResult<GroupWithSubjectItemDto[]>> GetListGroupsWithSubjects(
        [FromQuery] GetListGroupsWithSubjectsQuery query, CancellationToken cancellationToken)
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
    public async Task<ActionResult<Guid>> CreateStudent(CreateStudentCommand command,
        CancellationToken cancellationToken)
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
    public async Task<ActionResult<Guid>> UpdateStudent(UpdateStudentCommand command,
        CancellationToken cancellationToken)
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
    public async Task<ActionResult<Guid>> DeleteStudent(DeleteStudentCommand command,
        CancellationToken cancellationToken)
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
    public async Task<ActionResult<StudentItemDto[]>> GetListStudents([FromQuery] GetListStudentsQuery query,
        CancellationToken cancellationToken)
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
    public async Task<ActionResult<StudentDto>> GetStudentByIsn(GetStudentByIsnQuery query,
        CancellationToken cancellationToken)
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
    public async Task<ActionResult<Guid>> CreateSubject(CreateSubjectCommand command,
        CancellationToken cancellationToken)
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
    public async Task<ActionResult<Guid>> UpdateSubject(UpdateSubjectCommand command,
        CancellationToken cancellationToken)
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
    public async Task<ActionResult<Guid>> DeleteSubject(DeleteSubjectCommand command,
        CancellationToken cancellationToken)
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
    public async Task<ActionResult<StudentItemDto[]>> GetListSubjects([FromQuery] GetListSubjectsQuery query,
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
    [HttpGet(nameof(GetSubjectByIsn), Name = nameof(GetSubjectByIsn))]
    public async Task<ActionResult<StudentDto>> GetSubjectByIsn(GetSubjectByIsnQuery query,
        CancellationToken cancellationToken)
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
    public async Task<ActionResult> AddGroupAndSubject(AddGroupAndSubjectCommand command,
        CancellationToken cancellationToken)
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
    public async Task<ActionResult> DeleteGroupAndSubject(DeleteGroupAndSubjectCommand command,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    #endregion

    #region Teacher

    /// <summary>
    /// Создание учителя
    /// </summary>
    [HttpPost(nameof(CreateTeacher), Name = nameof(CreateTeacher))]
    public async Task<ActionResult<Guid>> CreateTeacher(CreateTeacherCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование данных учителя
    /// </summary>
    [HttpPost(nameof(UpdateTeacher), Name = nameof(UpdateTeacher))]
    public async Task<ActionResult<Guid>> UpdateTeacher(UpdateTeacherCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление учителя
    /// </summary>
    [HttpPost(nameof(DeleteTeacher), Name = nameof(DeleteTeacher))]
    public async Task<ActionResult> DeleteTeacher(DeleteTeacherCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение списка учителей
    /// </summary>
    [HttpGet(nameof(GetListTeachers), Name = nameof(GetListTeachers))]
    public async Task<ActionResult<TeacherDto[]>> GetListTeachers([FromQuery] GetListTeachersQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение данных учителя
    /// </summary>
    [HttpGet(nameof(GetTeacherByIsn), Name = nameof(GetTeacherByIsn))]
    public async Task<ActionResult<TeacherDto>> GetTeacherByIsn(GetTeacherByIsnQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение детальной информации об учителе
    /// </summary>
    [HttpGet(nameof(GetTeacherWithDetails), Name = nameof(GetTeacherWithDetails))]
    public async Task<ActionResult<TeacherWithDetailsDto>> GetTeacherWithDetails(GetTeacherWithDetailsQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region TeacherSubject

    /// <summary>
    /// Привязка предмета к учителю
    /// </summary>
    [HttpPost(nameof(CreateTeacherSubject), Name = nameof(CreateTeacherSubject))]
    public async Task<ActionResult> CreateTeacherSubject(CreateTeacherSubjectCommand command,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Отвязка предмета от учителя
    /// </summary>
    [HttpPost(nameof(DeleteTeacherSubject), Name = nameof(DeleteTeacherSubject))]
    public async Task<ActionResult> DeleteTeacherSubject(DeleteTeacherSubjectCommand command,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение списка предметов учителя
    /// </summary>
    [HttpGet(nameof(GetTeacherSubjectsByTeacher), Name = nameof(GetTeacherSubjectsByTeacher))]
    public async Task<ActionResult<TeacherSubjectWithDetailsDto[]>> GetTeacherSubjectsByTeacher(
        [FromQuery] GetTeacherSubjectsByTeacherQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение списка учителей по предмету
    /// </summary>
    [HttpGet(nameof(GetTeachersBySubject), Name = nameof(GetTeachersBySubject))]
    public async Task<ActionResult<TeacherSubjectWithDetailsDto[]>> GetTeachersBySubject(
        [FromQuery] GetTeachersBySubjectQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region Grade

    /// <summary>
    /// Создание оценки
    /// </summary>
    [HttpPost(nameof(CreateGrade), Name = nameof(CreateGrade))]
    public async Task<ActionResult<Guid>> CreateGrade([FromBody] CreateGradeCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование оценки
    /// </summary>
    [HttpPost(nameof(UpdateGrade), Name = nameof(UpdateGrade))]
    public async Task<ActionResult<Guid>> UpdateGrade([FromBody] UpdateGradeCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление оценки
    /// </summary>
    [HttpPost(nameof(DeleteGrade), Name = nameof(DeleteGrade))]
    public async Task<ActionResult> DeleteGrade([FromQuery] DeleteGradeCommand command,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение оценки по идентификатору
    /// </summary>
    [HttpGet(nameof(GetGradeByIsn), Name = nameof(GetGradeByIsn))]
    public async Task<ActionResult<GradeDto>> GetGradeByIsn([FromQuery] GetGradeByIsnQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение оценки с детальной информацией
    /// </summary>
    [HttpGet(nameof(GetGradeWithDetails), Name = nameof(GetGradeWithDetails))]
    public async Task<ActionResult<GradeWithDetailsDto>> GetGradeWithDetails([FromQuery] GetGradeWithDetailsQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение списка оценок
    /// </summary>
    [HttpGet(nameof(GetListGrades), Name = nameof(GetListGrades))]
    public async Task<ActionResult<GradeDto[]>> GetListGrades([FromQuery] GetListGradesQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region Assignment

    /// <summary>
    /// Создание задания
    /// </summary>
    [HttpPost(nameof(CreateAssignment), Name = nameof(CreateAssignment))]
    public async Task<ActionResult<Guid>> CreateAssignment(CreateAssignmentCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Обновление задания
    /// </summary>
    [HttpPost(nameof(UpdateAssignment), Name = nameof(UpdateAssignment))]
    public async Task<ActionResult<Guid>> UpdateAssignment(UpdateAssignmentCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление задания
    /// </summary>
    [HttpPost(nameof(DeleteAssignment), Name = nameof(DeleteAssignment))]
    public async Task<ActionResult> DeleteAssignment(DeleteAssignmentCommand command,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение задания по идентификатору
    /// </summary>
    [HttpGet(nameof(GetAssignmentByIsn), Name = nameof(GetAssignmentByIsn))]
    public async Task<ActionResult<AssignmentDto>> GetAssignmentByIsn([FromQuery] GetAssignmentByIsnQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение задания с детальной информацией
    /// </summary>
    [HttpGet(nameof(GetAssignmentWithDetails), Name = nameof(GetAssignmentWithDetails))]
    public async Task<ActionResult<AssignmentWithDetailsDto>> GetAssignmentWithDetails(
        [FromQuery] GetAssignmentWithDetailsQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение списка заданий
    /// </summary>
    [HttpGet(nameof(GetListAssignments), Name = nameof(GetListAssignments))]
    public async Task<ActionResult<AssignmentDto[]>> GetListAssignments([FromQuery] GetListAssignmentsQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение заданий по предмету
    /// </summary>
    [HttpGet(nameof(GetAssignmentsBySubject), Name = nameof(GetAssignmentsBySubject))]
    public async Task<ActionResult<AssignmentDto[]>> GetAssignmentsBySubject(
        [FromQuery] GetAssignmentsBySubjectQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region Material

    /// <summary>
    /// Создание материала
    /// </summary>
    [HttpPost(nameof(CreateMaterial), Name = nameof(CreateMaterial))]
    public async Task<ActionResult<Guid>> CreateMaterial(CreateMaterialCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Обновление материала
    /// </summary>
    [HttpPost(nameof(UpdateMaterial), Name = nameof(UpdateMaterial))]
    public async Task<ActionResult<Guid>> UpdateMaterial(UpdateMaterialCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление материала
    /// </summary>
    [HttpPost(nameof(DeleteMaterial), Name = nameof(DeleteMaterial))]
    public async Task<ActionResult> DeleteMaterial(DeleteMaterialCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение материала по идентификатору
    /// </summary>
    [HttpGet(nameof(GetMaterialByIsn), Name = nameof(GetMaterialByIsn))]
    public async Task<ActionResult<MaterialDto>> GetMaterialByIsn([FromQuery] GetMaterialByIsnQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение материала с детальной информацией
    /// </summary>
    [HttpGet(nameof(GetMaterialWithDetails), Name = nameof(GetMaterialWithDetails))]
    public async Task<ActionResult<MaterialWithDetailsDto>> GetMaterialWithDetails(
        [FromQuery] GetMaterialWithDetailsQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение списка материалов
    /// </summary>
    [HttpGet(nameof(GetListMaterials), Name = nameof(GetListMaterials))]
    public async Task<ActionResult<MaterialDto[]>> GetListMaterials([FromQuery] GetListMaterialsQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение материалов по предмету
    /// </summary>
    [HttpGet(nameof(GetMaterialsBySubject), Name = nameof(GetMaterialsBySubject))]
    public async Task<ActionResult<MaterialDto[]>> GetMaterialsBySubject([FromQuery] GetMaterialsBySubjectQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region Announcement

    /// <summary>
    /// Создание объявления
    /// </summary>
    [HttpPost(nameof(CreateAnnouncement), Name = nameof(CreateAnnouncement))]
    public async Task<ActionResult<Guid>> CreateAnnouncement(CreateAnnouncementCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Обновление объявления
    /// </summary>
    [HttpPost(nameof(UpdateAnnouncement), Name = nameof(UpdateAnnouncement))]
    public async Task<ActionResult<Guid>> UpdateAnnouncement(UpdateAnnouncementCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление объявления
    /// </summary>
    [HttpPost(nameof(DeleteAnnouncement), Name = nameof(DeleteAnnouncement))]
    public async Task<ActionResult> DeleteAnnouncement(DeleteAnnouncementCommand command,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Добавление группы к объявлению
    /// </summary>
    [HttpPost(nameof(AddGroupToAnnouncement), Name = nameof(AddGroupToAnnouncement))]
    public async Task<ActionResult> AddGroupToAnnouncement(AddGroupToAnnouncementCommand command,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Удаление группы из объявления
    /// </summary>
    [HttpPost(nameof(RemoveGroupFromAnnouncement), Name = nameof(RemoveGroupFromAnnouncement))]
    public async Task<ActionResult> RemoveGroupFromAnnouncement(RemoveGroupFromAnnouncementCommand command,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение объявления по идентификатору
    /// </summary>
    [HttpGet(nameof(GetAnnouncementByIsn), Name = nameof(GetAnnouncementByIsn))]
    public async Task<ActionResult<AnnouncementDto>> GetAnnouncementByIsn([FromQuery] GetAnnouncementByIsnQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение объявления с детальной информацией
    /// </summary>
    [HttpGet(nameof(GetAnnouncementWithDetails), Name = nameof(GetAnnouncementWithDetails))]
    public async Task<ActionResult<AnnouncementWithDetailsDto>> GetAnnouncementWithDetails(
        [FromQuery] GetAnnouncementWithDetailsQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение списка объявлений
    /// </summary>
    [HttpGet(nameof(GetListAnnouncements), Name = nameof(GetListAnnouncements))]
    public async Task<ActionResult<AnnouncementDto[]>> GetListAnnouncements([FromQuery] GetListAnnouncementsQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение объявлений по преподавателю
    /// </summary>
    [HttpGet(nameof(GetAnnouncementsByTeacher), Name = nameof(GetAnnouncementsByTeacher))]
    public async Task<ActionResult<AnnouncementDto[]>> GetAnnouncementsByTeacher(
        [FromQuery] GetAnnouncementsByTeacherQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение объявлений для группы
    /// </summary>
    [HttpGet(nameof(GetAnnouncementsByGroup), Name = nameof(GetAnnouncementsByGroup))]
    public async Task<ActionResult<AnnouncementDto[]>> GetAnnouncementsByGroup(
        [FromQuery] GetAnnouncementsByGroupQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion
}