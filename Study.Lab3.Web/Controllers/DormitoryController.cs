using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Web.Features.Dormitory.Buildings.Commands;
using Study.Lab3.Web.Features.Dormitory.Buildings.DtoModels;
using Study.Lab3.Web.Features.Dormitory.Buildings.Queries;
using Study.Lab3.Web.Features.Dormitory.Rooms.DtoModels;
using Study.Lab3.Web.Features.Dormitory.Residents.DtoModels;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Dormitory;
using Microsoft.EntityFrameworkCore;

namespace Study.Lab3.Web.Controllers;

/// <summary>
/// Контроллер для управления общежитиями
/// </summary>
[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class DormitoryController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly DataContext _dataContext;

    public DormitoryController(IMediator mediator, DataContext dataContext)
    {
        _mediator = mediator;
        _dataContext = dataContext;
    }

    #region Buildings

    /// <summary>
    /// Создать новое здание общежития
    /// </summary>
    /// <param name="command">Команда для создания здания</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    /// <returns>Идентификатор созданного здания</returns>
    [HttpPost("buildings")]
    public async Task<ActionResult<int>> CreateBuilding([FromBody] CreateBuildingCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var id = await _mediator.Send(command, cancellationToken);
            return Ok(id);
        }
        catch (Exception ex)
        {
            return BadRequest($"Ошибка при создании здания: {ex.Message}");
        }
    }

    /// <summary>
    /// Обновить существующее здание общежития
    /// </summary>
    /// <param name="id">Идентификатор здания</param>
    /// <param name="building">Данные для обновления</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    /// <returns>Результат выполнения</returns>
    [HttpPut("buildings/{id}")]
    public async Task<ActionResult> UpdateBuilding([FromRoute] int id, [FromBody] UpdateDormitoryBuildingDto building, CancellationToken cancellationToken)
    {
        var command = new UpdateBuildingCommand { Id = id, Building = building };
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Удалить здание общежития
    /// </summary>
    /// <param name="id">Идентификатор здания</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    /// <returns>Результат выполнения</returns>
    [HttpDelete("buildings/{id}")]
    public async Task<ActionResult> DeleteBuilding([FromRoute] int id, CancellationToken cancellationToken)
    {
        var command = new DeleteBuildingCommand { Id = id };
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получить здание общежития по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор здания</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    /// <returns>Информация о здании</returns>
    [HttpGet("buildings/{id}")]
    public async Task<ActionResult<DormitoryBuildingDto>> GetBuildingById([FromRoute] int id, CancellationToken cancellationToken)
    {
        var query = new GetBuildingByIdQuery { Id = id };
        var result = await _mediator.Send(query, cancellationToken);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    /// <summary>
    /// Получить список всех зданий общежитий
    /// </summary>
    /// <param name="cancellationToken">Токен отмены операции</param>
    /// <returns>Список зданий</returns>
    [HttpGet("buildings")]
    public async Task<ActionResult<DormitoryBuildingDto[]>> GetListBuildings(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetListBuildingsQuery(), cancellationToken);
        return Ok(result);
    }

    #endregion

    #region Rooms

    /// <summary>
    /// Создать новую комнату
    /// </summary>
    [HttpPost("rooms")]
    public async Task<ActionResult<int>> CreateRoom([FromBody] CreateDormitoryRoomDto roomDto, CancellationToken cancellationToken)
    {
        // Проверка валидации модели
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var room = new DormitoryRoom
            {
                RoomNumber = roomDto.RoomNumber,
                Floor = roomDto.Floor,
                Area = roomDto.Area,
                MaxOccupants = roomDto.MaxOccupants,
                CurrentOccupants = 0,
                MonthlyRent = roomDto.MonthlyRent,
                HasBalcony = roomDto.HasBalcony,
                HasPrivateBathroom = roomDto.HasPrivateBathroom,
                Description = roomDto.Description,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _dataContext.DormitoryRooms.AddAsync(room, cancellationToken);
            await _dataContext.SaveChangesAsync(cancellationToken);
            return Ok(room.Id);
        }
        catch (Exception ex)
        {
            return BadRequest($"Ошибка при создании комнаты: {ex.Message}");
        }
    }

    /// <summary>
    /// Получить список комнат
    /// </summary>
    [HttpGet("rooms")]
    public async Task<ActionResult<DormitoryRoomDto[]>> GetRooms(CancellationToken cancellationToken)
    {
        var rooms = await _dataContext.DormitoryRooms
            .AsNoTracking()
            .Select(x => new DormitoryRoomDto
            {
                Id = x.Id,
                RoomNumber = x.RoomNumber,
                Floor = x.Floor,
                Area = x.Area,
                MaxOccupants = x.MaxOccupants,
                CurrentOccupants = x.CurrentOccupants,
                MonthlyRent = x.MonthlyRent,
                HasBalcony = x.HasBalcony,
                HasPrivateBathroom = x.HasPrivateBathroom,
                Description = x.Description,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt
            })
            .ToArrayAsync(cancellationToken);

        return Ok(rooms);
    }

    /// <summary>
    /// Получить комнату по ID
    /// </summary>
    [HttpGet("rooms/{id}")]
    public async Task<ActionResult<DormitoryRoomDto>> GetRoomById([FromRoute] int id, CancellationToken cancellationToken)
    {
        var room = await _dataContext.DormitoryRooms
            .AsNoTracking()
            .Where(x => x.Id == id)
            .Select(x => new DormitoryRoomDto
            {
                Id = x.Id,
                RoomNumber = x.RoomNumber,
                Floor = x.Floor,
                Area = x.Area,
                MaxOccupants = x.MaxOccupants,
                CurrentOccupants = x.CurrentOccupants,
                MonthlyRent = x.MonthlyRent,
                HasBalcony = x.HasBalcony,
                HasPrivateBathroom = x.HasPrivateBathroom,
                Description = x.Description,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt
            })
            .FirstOrDefaultAsync(cancellationToken);

        return room == null ? NotFound() : Ok(room);
    }

    /// <summary>
    /// Удалить комнату
    /// </summary>
    [HttpDelete("rooms/{id}")]
    public async Task<ActionResult> DeleteRoom([FromRoute] int id, CancellationToken cancellationToken)
    {
        var room = await _dataContext.DormitoryRooms.FindAsync(id, cancellationToken);
        if (room == null) return NotFound();

        _dataContext.DormitoryRooms.Remove(room);
        await _dataContext.SaveChangesAsync(cancellationToken);
        return Ok();
    }

    #endregion

    #region Residents

    /// <summary>
    /// Создать нового жильца
    /// </summary>
    [HttpPost("residents")]
    public async Task<ActionResult<int>> CreateResident([FromBody] CreateDormitoryResidentDto residentDto, CancellationToken cancellationToken)
    {
        // Проверка валидации модели
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var resident = new DormitoryResident
            {
                FirstName = residentDto.FirstName,
                LastName = residentDto.LastName,
                MiddleName = residentDto.MiddleName,
                StudentId = residentDto.StudentId,
                StudentGroup = residentDto.StudentGroup,
                DateOfBirth = residentDto.DateOfBirth,
                PhoneNumber = residentDto.PhoneNumber,
                Email = residentDto.Email,
                CheckInDate = residentDto.CheckInDate,
                PlannedCheckOutDate = residentDto.PlannedCheckOutDate,
                Notes = residentDto.Notes,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _dataContext.DormitoryResidents.AddAsync(resident, cancellationToken);
            await _dataContext.SaveChangesAsync(cancellationToken);
            return Ok(resident.Id);
        }
        catch (Exception ex)
        {
            return BadRequest($"Ошибка при создании жильца: {ex.Message}");
        }
    }

    /// <summary>
    /// Получить список жильцов
    /// </summary>
    [HttpGet("residents")]
    public async Task<ActionResult<DormitoryResidentDto[]>> GetResidents(CancellationToken cancellationToken)
    {
        var residents = await _dataContext.DormitoryResidents
            .AsNoTracking()
            .Select(x => new DormitoryResidentDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                MiddleName = x.MiddleName,
                StudentId = x.StudentId,
                StudentGroup = x.StudentGroup,
                DateOfBirth = x.DateOfBirth,
                PhoneNumber = x.PhoneNumber,
                Email = x.Email,
                CheckInDate = x.CheckInDate,
                PlannedCheckOutDate = x.PlannedCheckOutDate,
                ActualCheckOutDate = x.ActualCheckOutDate,
                Notes = x.Notes,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt
            })
            .ToArrayAsync(cancellationToken);

        return Ok(residents);
    }

    /// <summary>
    /// Получить жильца по ID
    /// </summary>
    [HttpGet("residents/{id}")]
    public async Task<ActionResult<DormitoryResidentDto>> GetResidentById([FromRoute] int id, CancellationToken cancellationToken)
    {
        var resident = await _dataContext.DormitoryResidents
            .AsNoTracking()
            .Where(x => x.Id == id)
            .Select(x => new DormitoryResidentDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                MiddleName = x.MiddleName,
                StudentId = x.StudentId,
                StudentGroup = x.StudentGroup,
                DateOfBirth = x.DateOfBirth,
                PhoneNumber = x.PhoneNumber,
                Email = x.Email,
                CheckInDate = x.CheckInDate,
                PlannedCheckOutDate = x.PlannedCheckOutDate,
                ActualCheckOutDate = x.ActualCheckOutDate,
                Notes = x.Notes,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt
            })
            .FirstOrDefaultAsync(cancellationToken);

        return resident == null ? NotFound() : Ok(resident);
    }

    /// <summary>
    /// Удалить жильца
    /// </summary>
    [HttpDelete("residents/{id}")]
    public async Task<ActionResult> DeleteResident([FromRoute] int id, CancellationToken cancellationToken)
    {
        var resident = await _dataContext.DormitoryResidents.FindAsync(id, cancellationToken);
        if (resident == null) return NotFound();

        _dataContext.DormitoryResidents.Remove(resident);
        await _dataContext.SaveChangesAsync(cancellationToken);
        return Ok();
    }

    #endregion
}
