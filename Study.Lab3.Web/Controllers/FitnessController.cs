using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Web.Features.Fitness.Member.Commands;
using Study.Lab3.Web.Features.Fitness.Member.DtoModels;
using Study.Lab3.Web.Features.Fitness.Member.Queries;
using Study.Lab3.Web.Features.Fitness.Trainers.Commands;
using Study.Lab3.Web.Features.Fitness.Trainers.DtoModels;
using Study.Lab3.Web.Features.Fitness.Trainers.Queries;
using Study.Lab3.Web.Features.Fitness.Equipment.Commands;
using Study.Lab3.Web.Features.Fitness.Equipment.DtoModels;
using Study.Lab3.Web.Features.Fitness.Equipment.Queries;

namespace Study.Lab3.Web.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class FitnessController : Controller
{
    private readonly IMediator _mediator;

    public FitnessController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region Member

    /// <summary>
    /// Создание участника
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор участника</returns>
    [HttpPost(nameof(CreateMember), Name = nameof(CreateMember))]
    public async Task<ActionResult<Guid>> CreateMember(CreateMemberCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование данных участника
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор участника</returns>
    [HttpPut(nameof(UpdateMember), Name = nameof(UpdateMember))]
    public async Task<ActionResult<Guid>> UpdateMember(UpdateMemberCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление участника
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpDelete(nameof(UpdateMember), Name = nameof(DeleteMember))]
    public async Task<ActionResult> DeleteMember(DeleteMemberCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение списка участников
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список участников</returns>
    [HttpGet(nameof(GetListMembers), Name = nameof(GetListMembers))]
    public async Task<ActionResult<MemberDto[]>> GetListMembers([FromQuery] GetListMembersQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение данных участника
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные участника</returns>
    [HttpGet(nameof(GetMemberByIsn), Name = nameof(GetMemberByIsn))]
    public async Task<ActionResult<MemberDto>> GetMemberByIsn(GetMemberByIsnQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region Trainer

    /// <summary>
    /// Создание тренера
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор тренера</returns>
    [HttpPost(nameof(CreateTrainer), Name = nameof(CreateTrainer))]
    public async Task<ActionResult<Guid>> CreateTrainer(CreateTrainerCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование данных тренера
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор тренера</returns>
    [HttpPut(nameof(UpdateTrainer), Name = nameof(UpdateTrainer))]
    public async Task<ActionResult<Guid>> UpdateTrainer(UpdateTrainerCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление тренера
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpDelete(nameof(UpdateTrainer), Name = nameof(DeleteTrainer))]
    public async Task<ActionResult> DeleteTrainer(DeleteTrainerCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение списка тренеров
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список тренеров</returns>
    [HttpGet(nameof(GetListTrainers), Name = nameof(GetListTrainers))]
    public async Task<ActionResult<TrainerDto[]>> GetListTrainers([FromQuery] GetListTrainersQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение данных тренера
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные тренера</returns>
    [HttpGet(nameof(GetTrainerByIsn), Name = nameof(GetTrainerByIsn))]
    public async Task<ActionResult<TrainerDto>> GetTrainerByIsn(GetTrainerByIsnQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region Equipment

    /// <summary>
    /// Создание оборудования
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор оборудования</returns>
    [HttpPost(nameof(CreateEquipment), Name = nameof(CreateEquipment))]
    public async Task<ActionResult<Guid>> CreateEquipment(CreateEquipmentCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование данных оборудования
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор оборудования</returns>
    [HttpPut(nameof(UpdateEquipment), Name = nameof(UpdateEquipment))]
    public async Task<ActionResult<Guid>> UpdateEquipment(UpdateEquipmentCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление оборудования
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpDelete(nameof(DeleteEquipment), Name = nameof(DeleteEquipment))]
    public async Task<ActionResult> DeleteEquipment(DeleteEquipmentCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение списка оборудования
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список оборудования</returns>
    [HttpGet(nameof(GetListEquipment), Name = nameof(GetListEquipment))]
    public async Task<ActionResult<EquipmentDto[]>> GetListEquipment([FromQuery] GetListEquipmentQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение данных оборудования
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные оборудования</returns>
    [HttpGet(nameof(GetEquipmentByIsn), Name = nameof(GetEquipmentByIsn))]
    public async Task<ActionResult<EquipmentDto>> GetEquipmentByIsn(GetEquipmentByIsnQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion
}
