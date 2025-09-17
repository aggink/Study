using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Web.Features.Library.AuthorBooks.Commands;
using Study.Lab3.Web.Features.Library.AuthorBooks.DtoModels;
using Study.Lab3.Web.Features.Library.AuthorBooks.Queries;
using Study.Lab3.Web.Features.Library.Authors.Commands;
using Study.Lab3.Web.Features.Library.Authors.DtoModels;
using Study.Lab3.Web.Features.Library.Authors.Queries;
using Study.Lab3.Web.Features.Library.Books.Commands;
using Study.Lab3.Web.Features.Library.Books.DtoModels;
using Study.Lab3.Web.Features.Library.Books.Queries;
using Study.Lab3.Web.Features.Shelter.Adoptions.Commands;
using Study.Lab3.Web.Features.Shelter.Cats.Commands;
using Study.Lab3.Web.Features.Shelter.Cats.DtoModels;
using Study.Lab3.Web.Features.Shelter.Cats.Queries;
using Study.Lab3.Web.Features.Shelter.Customers.Commands;
using Study.Lab3.Web.Features.Shelter.Customers.DtoModels;
using Study.Lab3.Web.Features.Shelter.Customers.Queries;
using Study.Lab3.Web.Features.Shelter.MiniPigAdoptions.Commands;
using Study.Lab3.Web.Features.Shelter.MiniPigs.Commands;
using Study.Lab3.Web.Features.Shelter.MiniPigs.DtoModels;
using Study.Lab3.Web.Features.Shelter.MiniPigs.Queries;
using Study.Lab3.Web.Features.University.Announcements.Commands;
using Study.Lab3.Web.Features.University.Announcements.DtoModels;
using Study.Lab3.Web.Features.University.Announcements.Queries;
using Study.Lab3.Web.Features.University.Assignments.Commands;
using Study.Lab3.Web.Features.University.Assignments.DtoModels;
using Study.Lab3.Web.Features.University.Assignments.Queries;
using Study.Lab3.Web.Features.University.ExamRegistrations.Commands;
using Study.Lab3.Web.Features.University.ExamRegistrations.DtoModels;
using Study.Lab3.Web.Features.University.ExamRegistrations.Queries;
using Study.Lab3.Web.Features.University.ExamResults.Commands;
using Study.Lab3.Web.Features.University.ExamResults.DtoModels;
using Study.Lab3.Web.Features.University.ExamResults.Queries;
using Study.Lab3.Web.Features.University.Exams.Commands;
using Study.Lab3.Web.Features.University.Exams.DtoModels;
using Study.Lab3.Web.Features.University.Exams.Queries;
using Study.Lab3.Web.Features.University.Grades.Commands;
using Study.Lab3.Web.Features.University.Grades.DtoModels;
using Study.Lab3.Web.Features.University.Grades.Queries;
using Study.Lab3.Web.Features.University.Groups.Commands;
using Study.Lab3.Web.Features.University.Groups.DtoModels;
using Study.Lab3.Web.Features.University.Groups.Queries;
using Study.Lab3.Web.Features.University.Materials.Commands;
using Study.Lab3.Web.Features.University.Materials.DtoModels;
using Study.Lab3.Web.Features.University.Materials.Queries;
using Study.Lab3.Web.Features.University.Pingpongclub.Commands;
using Study.Lab3.Web.Features.University.Pingpongclub.DtoModels;
using Study.Lab3.Web.Features.University.Pingpongclub.Queries;
using Study.Lab3.Web.Features.University.ProjectActivities.Commands;
using Study.Lab3.Web.Features.University.ProjectActivities.DtoModels;
using Study.Lab3.Web.Features.University.ProjectActivities.Queries;
using Study.Lab3.Web.Features.University.ScientificWork.Commands;
using Study.Lab3.Web.Features.University.ScientificWork.DtoModels;
using Study.Lab3.Web.Features.University.ScientificWork.Queries;
using Study.Lab3.Web.Features.University.Sportclub.Commands;
using Study.Lab3.Web.Features.University.Sportclub.DtoModels;
using Study.Lab3.Web.Features.University.Sportclub.Queries;
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
using Study.Lab3.Web.Features.University.TheAttendanceLog.Commands;
using Study.Lab3.Web.Features.University.TheAttendanceLog.DtoModels;
using Study.Lab3.Web.Features.University.TheAttendanceLog.Queries;
using Study.Lab3.Web.Features.University.TheProfcom.Commands;
using Study.Lab3.Web.Features.University.TheProfcom.DtoModels;
using Study.Lab3.Web.Features.University.TheProfcom.Queries;
using Study.Lab3.Web.Features.University.TheStudentNotes.Commands;
using Study.Lab3.Web.Features.University.TheStudentNotes.DtoModels;
using Study.Lab3.Web.Features.University.TheStudentNotes.Queries;

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

    #region Exam

    /// <summary>
    /// Создание экзамена
    /// </summary>
    [HttpPost(nameof(CreateExam), Name = nameof(CreateExam))]
    public async Task<ActionResult<Guid>> CreateExam(CreateExamCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Обновление экзамена
    /// </summary>
    [HttpPost(nameof(UpdateExam), Name = nameof(UpdateExam))]
    public async Task<ActionResult<Guid>> UpdateExam(UpdateExamCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление экзамена
    /// </summary>
    [HttpPost(nameof(DeleteExam), Name = nameof(DeleteExam))]
    public async Task<ActionResult> DeleteExam(DeleteExamCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение экзамена по идентификатору
    /// </summary>
    [HttpGet(nameof(GetExamByIsn), Name = nameof(GetExamByIsn))]
    public async Task<ActionResult<ExamDto>> GetExamByIsn([FromQuery] GetExamByIsnQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение экзамена с детальной информацией
    /// </summary>
    [HttpGet(nameof(GetExamWithDetails), Name = nameof(GetExamWithDetails))]
    public async Task<ActionResult<ExamWithDetailsDto>> GetExamWithDetails([FromQuery] GetExamWithDetailsQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение списка экзаменов
    /// </summary>
    [HttpGet(nameof(GetListExams), Name = nameof(GetListExams))]
    public async Task<ActionResult<ExamDto[]>> GetListExams([FromQuery] GetListExamsQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение экзаменов по предмету
    /// </summary>
    [HttpGet(nameof(GetExamsBySubject), Name = nameof(GetExamsBySubject))]
    public async Task<ActionResult<ExamDto[]>> GetExamsBySubject([FromQuery] GetExamsBySubjectQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region ExamRegistration

    /// <summary>
    /// Создание регистрации на экзамен
    /// </summary>
    [HttpPost(nameof(CreateExamRegistration), Name = nameof(CreateExamRegistration))]
    public async Task<ActionResult<Guid>> CreateExamRegistration(CreateExamRegistrationCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Обновление регистрации на экзамен
    /// </summary>
    [HttpPost(nameof(UpdateExamRegistration), Name = nameof(UpdateExamRegistration))]
    public async Task<ActionResult<Guid>> UpdateExamRegistration(UpdateExamRegistrationCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление регистрации на экзамен
    /// </summary>
    [HttpPost(nameof(DeleteExamRegistration), Name = nameof(DeleteExamRegistration))]
    public async Task<ActionResult> DeleteExamRegistration(DeleteExamRegistrationCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение регистрации на экзамен по идентификатору
    /// </summary>
    [HttpGet(nameof(GetExamRegistrationByIsn), Name = nameof(GetExamRegistrationByIsn))]
    public async Task<ActionResult<ExamRegistrationDto>> GetExamRegistrationByIsn([FromQuery] GetExamRegistrationByIsnQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение регистрации на экзамен с детальной информацией
    /// </summary>
    [HttpGet(nameof(GetExamRegistrationWithDetails), Name = nameof(GetExamRegistrationWithDetails))]
    public async Task<ActionResult<ExamRegistrationWithDetailsDto>> GetExamRegistrationWithDetails([FromQuery] GetExamRegistrationWithDetailsQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение списка регистраций на экзамены
    /// </summary>
    [HttpGet(nameof(GetListExamRegistrations), Name = nameof(GetListExamRegistrations))]
    public async Task<ActionResult<ExamRegistrationDto[]>> GetListExamRegistrations([FromQuery] GetListExamRegistrationsQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение регистраций по экзамену
    /// </summary>
    [HttpGet(nameof(GetExamRegistrationsByExam), Name = nameof(GetExamRegistrationsByExam))]
    public async Task<ActionResult<ExamRegistrationWithDetailsDto[]>> GetExamRegistrationsByExam([FromQuery] GetExamRegistrationsByExamQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение регистраций по студенту
    /// </summary>
    [HttpGet(nameof(GetExamRegistrationsByStudent), Name = nameof(GetExamRegistrationsByStudent))]
    public async Task<ActionResult<ExamRegistrationWithDetailsDto[]>> GetExamRegistrationsByStudent([FromQuery] GetExamRegistrationsByStudentQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region ExamResult

    /// <summary>
    /// Создание результата экзамена
    /// </summary>
    [HttpPost(nameof(CreateExamResult), Name = nameof(CreateExamResult))]
    public async Task<ActionResult<Guid>> CreateExamResult(CreateExamResultCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Обновление результата экзамена
    /// </summary>
    [HttpPost(nameof(UpdateExamResult), Name = nameof(UpdateExamResult))]
    public async Task<ActionResult<Guid>> UpdateExamResult(UpdateExamResultCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление результата экзамена
    /// </summary>
    [HttpPost(nameof(DeleteExamResult), Name = nameof(DeleteExamResult))]
    public async Task<ActionResult> DeleteExamResult(DeleteExamResultCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение результата экзамена по идентификатору
    /// </summary>
    [HttpGet(nameof(GetExamResultByIsn), Name = nameof(GetExamResultByIsn))]
    public async Task<ActionResult<ExamResultDto>> GetExamResultByIsn([FromQuery] GetExamResultByIsnQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение результата экзамена с детальной информацией
    /// </summary>
    [HttpGet(nameof(GetExamResultWithDetails), Name = nameof(GetExamResultWithDetails))]
    public async Task<ActionResult<ExamResultWithDetailsDto>> GetExamResultWithDetails([FromQuery] GetExamResultWithDetailsQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение списка результатов экзаменов
    /// </summary>
    [HttpGet(nameof(GetListExamResults), Name = nameof(GetListExamResults))]
    public async Task<ActionResult<ExamResultDto[]>> GetListExamResults([FromQuery] GetListExamResultsQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение результатов по экзамену
    /// </summary>
    [HttpGet(nameof(GetExamResultsByExam), Name = nameof(GetExamResultsByExam))]
    public async Task<ActionResult<ExamResultWithDetailsDto[]>> GetExamResultsByExam([FromQuery] GetExamResultsByExamQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение результатов по студенту
    /// </summary>
    [HttpGet(nameof(GetExamResultsByStudent), Name = nameof(GetExamResultsByStudent))]
    public async Task<ActionResult<ExamResultWithDetailsDto[]>> GetExamResultsByStudent([FromQuery] GetExamResultsByStudentQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region Book

    /// <summary>
    /// Создание книги
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор книги</returns>
    [HttpPost(nameof(CreateBook), Name = nameof(CreateBook))]
    public async Task<ActionResult<Guid>> CreateBook(CreateBookCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование данных книги
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор книги</returns>
    [HttpPost(nameof(UpdateBook), Name = nameof(UpdateBook))]
    public async Task<ActionResult<Guid>> UpdateBook(UpdateBookCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление книги
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPost(nameof(DeleteBook), Name = nameof(DeleteBook))]
    public async Task<ActionResult<Guid>> DeleteBook(DeleteBookCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение списка книг
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список групп</returns>
    [HttpGet(nameof(GetListBooks), Name = nameof(GetListBooks))]
    public async Task<ActionResult<BookItemDto[]>> GetListBooks([FromQuery] GetListBooksQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение данных книг
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные группы</returns>
    [HttpGet(nameof(GetBookByIsn), Name = nameof(GetBookByIsn))]
    public async Task<ActionResult<BookDto>> GetBookByIsn(GetBookByIsnQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение список книг с авторами
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список книг с авторами</returns>
    [HttpGet(nameof(GetListBooksWithAuthors), Name = nameof(GetListBooksWithAuthors))]
    public async Task<ActionResult<BookWithAuthorsItemDto[]>> GetListBooksWithAuthors(
        [FromQuery] GetListBooksWithAuthorsQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region ProfcomActivity

    /// <summary>
    /// Создание профкома
    /// </summary>
    [HttpPost(nameof(CreateProfcom), Name = nameof(CreateProfcom))]
    public async Task<ActionResult<Guid>> CreateProfcom([FromBody] CreateProfcomCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование профкома
    /// </summary>
    [HttpPost(nameof(UpdateProfcom), Name = nameof(UpdateProfcom))]
    public async Task<ActionResult<Guid>> UpdateProfcom([FromBody] UpdateProfcomCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление профкома
    /// </summary>
    [HttpPost(nameof(DeleteProfcom), Name = nameof(DeleteProfcom))]
    public async Task<ActionResult> DeleteProfcom([FromQuery] DeleteProfcomCommand command,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение научной деятельности по идентификатору
    /// </summary>
    [HttpGet(nameof(GetProfcomByIsn), Name = nameof(GetProfcomByIsn))]
    public async Task<ActionResult<ProfcomDto>> GetProfcomByIsn([FromQuery] GetProfcomByIsnQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение научной деятельности с детальной информацией
    /// </summary>
    [HttpGet(nameof(GetProfcomWithDetails), Name = nameof(GetProfcomWithDetails))]
    public async Task<ActionResult<ProfcomWithDetailsDto>> GetProfcomWithDetails([FromQuery] GetProfcomWithDetailsQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение списка научной деятельности
    /// </summary>
    [HttpGet(nameof(GetListProfcom), Name = nameof(GetListProfcom))]
    public async Task<ActionResult<ProfcomDto[]>> GetListProfcom([FromQuery] GetListProfcomQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region Author

    /// <summary>
    /// Создание автора
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор автора</returns>
    [HttpPost(nameof(CreateAuthor), Name = nameof(CreateAuthor))]
    public async Task<ActionResult<Guid>> CreateAuthor(CreateAuthorCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование данных автора
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор автора</returns>
    [HttpPost(nameof(UpdateAuthor), Name = nameof(UpdateAuthor))]
    public async Task<ActionResult<Guid>> UpdateAuthor(UpdateAuthorCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление автора
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPost(nameof(DeleteAuthor), Name = nameof(DeleteAuthor))]
    public async Task<ActionResult<Guid>> DeleteAuthor(DeleteAuthorCommand command,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение списка авторов
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список авторов</returns>
    [HttpGet(nameof(GetListAuthors), Name = nameof(GetListAuthors))]
    public async Task<ActionResult<AuthorItemDto[]>> GetListAuthors([FromQuery] GetListAuthorsQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение данных автора
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные автора</returns>
    [HttpGet(nameof(GetAuthorByIsn), Name = nameof(GetAuthorByIsn))]
    public async Task<ActionResult<AuthorDto>> GetAuthorByIsn(GetAuthorByIsnQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Добавить книгу с автором
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPost(nameof(AddBookAndAuthor), Name = nameof(AddBookAndAuthor))]
    public async Task<ActionResult> AddBookAndAuthor(AddBookAndAuthorCommand command,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Удалить книгу с автором
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPost(nameof(DeleteBookAndAuthor), Name = nameof(DeleteBookAndAuthor))]
    public async Task<ActionResult> DeleteBookAndAuthor(DeleteBookAndAuthorCommand command,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    #endregion

    #region AuthorBook

    /// <summary>
    /// Привязать книгу к автору
    /// </summary>
    [HttpPost(nameof(CreateAuthorBook), Name = nameof(CreateAuthorBook))]
    public async Task<ActionResult> CreateAuthorBook(CreateAuthorBookCommand command,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Отвязать книгу от автора
    /// </summary>
    [HttpPost(nameof(DeleteAuthorBook), Name = nameof(DeleteAuthorBook))]
    public async Task<ActionResult> DeleteAuthorBook(DeleteAuthorBookCommand command,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение списка книг автора
    /// </summary>
    [HttpGet(nameof(GetBooksByAuthor), Name = nameof(GetBooksByAuthor))]
    public async Task<ActionResult<AuthorBookWithDetailsDto[]>> GetBooksByAuthor(
        [FromQuery] GetBooksByAuthorQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение списка авторов книги
    /// </summary>
    [HttpGet(nameof(GetAuthorsByBook), Name = nameof(GetAuthorsByBook))]
    public async Task<ActionResult<AuthorBookWithDetailsDto[]>> GetAuthorsByBook(
        [FromQuery] GetAuthorsByBookQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region Sportclub
    /// <summary>
    /// Создание спортивного клуба
    /// </summary>
    [HttpPost(nameof(CreateSportclub), Name = nameof(CreateSportclub))]

    public async Task<ActionResult<Guid>> CreateSportclub([FromBody] CreateSportclubCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование спортивного клуба
    /// </summary>
    [HttpPost(nameof(UpdateSportclub), Name = nameof(UpdateSportclub))]
    public async Task<ActionResult<Guid>> UpdateSportclub([FromBody] UpdateSportclubCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление спортивного клуба
    /// </summary>
    [HttpPost(nameof(DeleteSportclub), Name = nameof(DeleteSportclub))]
    public async Task<ActionResult> DeleteSportclub([FromQuery] DeleteSportclubCommand command,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение соревновательной деятельности по идентификатору
    /// </summary>
    [HttpGet(nameof(GetSportclubByIsn), Name = nameof(GetSportclubByIsn))]
    public async Task<ActionResult<SportclubDto>> GetSportclubByIsn([FromQuery] GetSportclubByIsnQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение соревновательной деятельности с детальной информацией
    /// </summary>
    [HttpGet(nameof(GetSportclubWithDetails), Name = nameof(GetSportclubWithDetails))]
    public async Task<ActionResult<SportclubWithDetailsDto>> GetSportclubWithDetails([FromQuery] GetSportclubWithDetailsQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение списка соревновательной деятельности
    /// </summary>
    [HttpGet(nameof(GetListSportclub), Name = nameof(GetListSportclub))]
    public async Task<ActionResult<SportclubDto[]>> GetListSportclub([FromQuery] GetListSportclubQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region ShelterCustomer

    /// <summary>
    /// Получение покупателя по идентификатору
    /// </summary>
    [HttpGet(nameof(GetShelterCustomerById), Name = nameof(GetShelterCustomerById))]
    public async Task<ActionResult<ShelterCustomerDto>> GetShelterCustomerById([FromQuery] GetShelterCustomerByIdQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    /// <summary>
    /// Получение списка покупателей приюта
    /// </summary>
    [HttpGet(nameof(GetShelterListCustomers), Name = nameof(GetShelterListCustomers))]
    public async Task<ActionResult<ShelterCustomerDto[]>> GetShelterListCustomers([FromQuery] GetShelterListCustomersQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Создание покупателя
    /// </summary>
    [HttpPost(nameof(CreateShelterCustomer), Name = nameof(CreateShelterCustomer))]
    public async Task<ActionResult<Guid>> CreateShelterCustomer(CreateShelterCustomerCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление покупателя
    /// </summary>
    [HttpPost(nameof(DeleteShelterCustomer), Name = nameof(DeleteShelterCustomer))]
    public async Task<ActionResult> DeleteShelterCustomer(DeleteShelterCustomerCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Обновление покупателя
    /// </summary>
    [HttpPost(nameof(UpdateShelterCustomer), Name = nameof(UpdateShelterCustomer))]
    public async Task<ActionResult<Guid>> UpdateShelterCustomer(UpdateShelterCustomerCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region Adoption

    /// <summary>
    /// Создание усыновления
    /// </summary>
    [HttpPost(nameof(CreateAdoption), Name = nameof(CreateAdoption))]
    public async Task<ActionResult<Guid>> CreateAdoption(CreateAdoptionCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование усыновления
    /// </summary>
    [HttpPost(nameof(UpdateAdoption), Name = nameof(UpdateAdoption))]
    public async Task<ActionResult<Guid>> UpdateAdoption(UpdateAdoptionCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление усыновления
    /// </summary>
    [HttpPost(nameof(DeleteAdoption), Name = nameof(DeleteAdoption))]
    public async Task<ActionResult> DeleteAdoption(DeleteAdoptionCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    #endregion

    #region Cat
    // Получение списка котов
    [HttpGet(nameof(GetListCats), Name = nameof(GetListCats))]
    public async Task<ActionResult<CatDto[]>> GetListCats([FromQuery] GetListCatsQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    // Создание кота
    [HttpPost(nameof(CreateCat), Name = nameof(CreateCat))]
    public async Task<ActionResult<Guid>> CreateCat(CreateCatCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    // Обновление кота
    [HttpPost(nameof(UpdateCat), Name = nameof(UpdateCat))]
    public async Task<ActionResult<Guid>> UpdateCat(UpdateCatCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    // Удаление кота
    [HttpPost(nameof(DeleteCat), Name = nameof(DeleteCat))]
    public async Task<ActionResult> DeleteCat(DeleteCatCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение кота по идентификатору
    /// </summary>
    [HttpGet(nameof(GetCatById), Name = nameof(GetCatById))]
    public async Task<ActionResult<CatDto>> GetCatById([FromQuery] GetCatByIdQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        if (result == null)
            return NotFound();
        return Ok(result);
    }
    #endregion

    #region ProjectActivitiesActivity

    /// <summary>
    /// Создание проектной деятельности
    /// </summary>
    [HttpPost(nameof(CreateProjectActivities), Name = nameof(CreateProjectActivities))]
    public async Task<ActionResult<Guid>> CreateProjectActivities([FromBody] CreateProjectActivitiesCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование проектной деятельности
    /// </summary>
    [HttpPost(nameof(UpdateProjectActivities), Name = nameof(UpdateProjectActivities))]
    public async Task<ActionResult<Guid>> UpdateProjectActivities([FromBody] UpdateProjectActivitiesCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление проектной деятельности
    /// </summary>
    [HttpPost(nameof(DeleteProjectActivities), Name = nameof(DeleteProjectActivities))]
    public async Task<ActionResult> DeleteProjectActivities([FromQuery] DeleteProjectActivitiesCommand command,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение выступлений по идентификатору
    /// </summary>
    [HttpGet(nameof(GetProjectActivitiesByIsn), Name = nameof(GetProjectActivitiesByIsn))]
    public async Task<ActionResult<ProjectActivitiesDto>> GetProjectActivitiesByIsn([FromQuery] GetProjectActivitiesByIsnQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение выступлений с детальной информацией
    /// </summary>
    [HttpGet(nameof(GetProjectActivitiesWithDetails), Name = nameof(GetProjectActivitiesWithDetails))]
    public async Task<ActionResult<ProjectActivitiesWithDetailsDto>> GetProjectActivitiesWithDetails([FromQuery] GetProjectActivitiesWithDetailsQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение списка выступлений
    /// </summary>
    [HttpGet(nameof(GetListProjectActivities), Name = nameof(GetListProjectActivities))]
    public async Task<ActionResult<ProjectActivitiesDto[]>> GetListProjectActivities([FromQuery] GetListProjectActivitiesQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion


    #region Pingpongclub
    /// <summary>
    /// Создание спортивного клуба
    /// </summary>
    [HttpPost(nameof(CreatePingpongclub), Name = nameof(CreatePingpongclub))]

    public async Task<ActionResult<Guid>> CreatePingpongclub([FromBody] CreatePingpongclubCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование спортивного клуба
    /// </summary>
    [HttpPost(nameof(UpdatePingpongclub), Name = nameof(UpdatePingpongclub))]
    public async Task<ActionResult<Guid>> UpdatePingpongclub([FromBody] UpdatePingpongclubCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление спортивного клуба
    /// </summary>
    [HttpPost(nameof(DeletePingpongclub), Name = nameof(DeletePingpongclub))]
    public async Task<ActionResult> DeletePingpongclub([FromQuery] DeletePingpongclubCommand command,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение соревновательной деятельности по идентификатору
    /// </summary>
    [HttpGet(nameof(GetPingpongclubByIsn), Name = nameof(GetPingpongclubByIsn))]
    public async Task<ActionResult<PingpongclubDto>> GetPingpongclubByIsn([FromQuery] GetPingpongclubByIsnQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение соревновательной деятельности с детальной информацией
    /// </summary>
    [HttpGet(nameof(GetPingpongclubWithDetails), Name = nameof(GetPingpongclubWithDetails))]
    public async Task<ActionResult<PingpongclubWithDetailsDto>> GetPingpongclubWithDetails([FromQuery] GetPingpongclubWithDetailsQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение списка соревновательной деятельности
    /// </summary>
    [HttpGet(nameof(GetListPingpongclub), Name = nameof(GetListPingpongclub))]
    public async Task<ActionResult<PingpongclubDto[]>> GetListPingpongclub([FromQuery] GetListPingpongclubQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region AttendanceLog

    /// <summary>
    /// Создание посещения
    /// </summary>
    [HttpPost(nameof(CreateAttendanceLog), Name = nameof(CreateAttendanceLog))]
    public async Task<ActionResult<Guid>> CreateAttendanceLog([FromBody] CreateAttendanceLogCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование посещения
    /// </summary>
    [HttpPost(nameof(UpdateAttendanceLog), Name = nameof(UpdateAttendanceLog))]
    public async Task<ActionResult<Guid>> UpdateAttendanceLog([FromBody] UpdateAttendanceLogCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление посещения
    /// </summary>
    [HttpPost(nameof(DeleteAttendanceLog), Name = nameof(DeleteAttendanceLog))]
    public async Task<ActionResult> DeleteAttendanceLog([FromQuery] DeleteAttendanceLogCommand command,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение посещения по идентификатору
    /// </summary>
    [HttpGet(nameof(GetAttendanceLogByIsn), Name = nameof(GetAttendanceLogByIsn))]
    public async Task<ActionResult<AttendanceLogDto>> GetAttendanceLogByIsn([FromQuery] GetAttendanceLogByIsnQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение списка посещений
    /// </summary>
    [HttpGet(nameof(GetListAttendanceLog), Name = nameof(GetListAttendanceLog))]
    public async Task<ActionResult<AttendanceLogDto[]>> GetListAttendanceLog([FromQuery] GetListAttendanceLogQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region StudentNotes

    [HttpGet(nameof(GetListStudentNotes), Name = nameof(GetListStudentNotes))]
    public async Task<ActionResult<StudentNoteDto[]>> GetListStudentNotes(
            [FromQuery] GetListStudentNotesQuery query,
            CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Создать новую заметку
    /// </summary>
    [HttpPost(nameof(CreateStudentNote), Name = nameof(CreateStudentNote))]
    public async Task<ActionResult<Guid>> CreateStudentNote(
        CreateStudentNoteCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Обновить существующую заметку
    /// </summary>
    [HttpPost(nameof(UpdateStudentNote), Name = nameof(UpdateStudentNote))]
    public async Task<ActionResult<Guid>> UpdateStudentNote(
        UpdateStudentNoteCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удалить заметку
    /// </summary>
    [HttpPost(nameof(DeleteStudentNote), Name = nameof(DeleteStudentNote))]
    public async Task<ActionResult> DeleteStudentNote(
        DeleteStudentNoteCommand command,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получить заметку по ID студента (1:1 отношение)
    /// </summary>
    [HttpGet(nameof(GetStudentNoteByStudentId), Name = nameof(GetStudentNoteByStudentId))]
    public async Task<ActionResult<StudentNoteDto>> GetStudentNoteByStudentId(
        [FromQuery] GetStudentNoteByStudentIdQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return result != null ? Ok(result) : NotFound();
    }

    #endregion

    #region MiniPigAdoption

    /// <summary>
    /// Создание усыновления
    /// </summary>
    [HttpPost(nameof(CreateMiniPigAdoption), Name = nameof(CreateMiniPigAdoption))]
    public async Task<ActionResult<Guid>> CreateMiniPigAdoption(CreateMiniPigAdoptionCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование усыновления
    /// </summary>
    [HttpPost(nameof(UpdateMiniPigAdoption), Name = nameof(UpdateMiniPigAdoption))]
    public async Task<ActionResult<Guid>> UpdateMiniPigAdoption(UpdateMiniPigAdoptionCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление усыновления
    /// </summary>
    [HttpPost(nameof(DeleteMiniPigAdoption), Name = nameof(DeleteMiniPigAdoption))]
    public async Task<ActionResult> DeleteMiniPigAdoption(DeleteMiniPigAdoptionCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    #endregion

    #region MiniPig
    // Получение списка мини пигов
    [HttpGet(nameof(GetListMiniPigs), Name = nameof(GetListMiniPigs))]
    public async Task<ActionResult<MiniPigDto[]>> GetListMiniPigs([FromQuery] GetListMiniPigsQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    // Создание мини пига
    [HttpPost(nameof(CreateMiniPig), Name = nameof(CreateMiniPig))]
    public async Task<ActionResult<Guid>> CreateMiniPig(CreateMiniPigCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    // Обновление мини пига
    [HttpPost(nameof(UpdateMiniPig), Name = nameof(UpdateMiniPig))]
    public async Task<ActionResult<Guid>> UpdateMiniPig(UpdateMiniPigCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    // Удаление мини пига
    [HttpPost(nameof(DeleteMiniPig), Name = nameof(DeleteMiniPig))]
    public async Task<ActionResult> DeleteMiniPig(DeleteMiniPigCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение мини пига по идентификатору
    /// </summary>
    [HttpGet(nameof(GetMiniPigById), Name = nameof(GetMiniPigById))]
    public async Task<ActionResult<MiniPigDto>> GetMiniPigById([FromQuery] GetMiniPigByIdQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        if (result == null)
            return NotFound();
        return Ok(result);
    }
    #endregion

    #region ScientificWork

    /// <summary>
    /// Создание научной работы
    /// </summary>
    [HttpPost(nameof(CreateScientificWork), Name = nameof(CreateScientificWork))]
    public async Task<ActionResult<Guid>> CreateScientificWork(
        [FromBody] CreateScientificWorkCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование научной работы
    /// </summary>
    [HttpPost(nameof(UpdateScientificWork), Name = nameof(UpdateScientificWork))]
    public async Task<ActionResult<Guid>> UpdateScientificWork(
        [FromBody] UpdateScientificWorkCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление научной работы
    /// </summary>
    [HttpPost(nameof(DeleteScientificWork), Name = nameof(DeleteScientificWork))]
    public async Task<ActionResult> DeleteScientificWork(
        [FromQuery] DeleteScientificWorkCommand command,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение научной работы по идентификатору
    /// </summary>
    [HttpGet(nameof(GetScientificWorkByIsn), Name = nameof(GetScientificWorkByIsn))]
    public async Task<ActionResult<ScientificWorkDto>> GetScientificWorkByIsn(
        [FromQuery] GetScientificWorkByIsnQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение научной работы с детальной информацией
    /// </summary>
    [HttpGet(nameof(GetScientificWorkWithDetails), Name = nameof(GetScientificWorkWithDetails))]
    public async Task<ActionResult<ScientificWorkWithDetailsDto>> GetScientificWorkWithDetails(
        [FromQuery] GetScientificWorkWithDetailsQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение списка научных работ
    /// </summary>
    [HttpGet(nameof(GetListScientificWorks), Name = nameof(GetListScientificWorks))]
    public async Task<ActionResult<ScientificWorkDto[]>> GetListScientificWorks(
        [FromQuery] GetListScientificWorksQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение списка научных работ с пагинацией
    /// </summary>
    [HttpGet(nameof(GetPagedScientificWorks), Name = nameof(GetPagedScientificWorks))]
    public async Task<ActionResult<PagedResult<ScientificWorkDto>>> GetPagedScientificWorks(
        [FromQuery] GetPagedScientificWorksQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion
}