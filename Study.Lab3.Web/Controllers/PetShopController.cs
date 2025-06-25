using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Web.Features.PetShop.PetFoods.Commands;
using Study.Lab3.Web.Features.PetShop.PetFoods.DtoModels;
using Study.Lab3.Web.Features.PetShop.PetFoods.Queries;
using Study.Lab3.Web.Features.PetShop.Pets.Commands;
using Study.Lab3.Web.Features.PetShop.Pets.DtoModels;
using Study.Lab3.Web.Features.PetShop.Pets.Queries;
using Study.Lab3.Web.Features.PetShop.PetToys.Commands;
using Study.Lab3.Web.Features.PetShop.PetToys.DtoModels;
using Study.Lab3.Web.Features.PetShop.PetToys.Queries;

namespace Study.Lab3.Web.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class PetShopController : Controller
{
    private readonly IMediator _mediator;

    public PetShopController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region Pet

    /// <summary>
    /// Создание животного
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор животного</returns>
    [HttpPost(nameof(CreatePet), Name = nameof(CreatePet))]
    public async Task<ActionResult<Guid>> CreatePet(CreatePetCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование данных животного
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор животного</returns>
    [HttpPost(nameof(UpdatePet), Name = nameof(UpdatePet))]
    public async Task<ActionResult<Guid>> UpdatePet(UpdatePetCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление животного
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPost(nameof(DeletePet), Name = nameof(DeletePet))]
    public async Task<ActionResult> DeletePet(DeletePetCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение списка животных
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список животных</returns>
    [HttpGet(nameof(GetListPets), Name = nameof(GetListPets))]
    public async Task<ActionResult<PetDto[]>> GetListPets([FromQuery] GetListPetsQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение данных животного
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные животного</returns>
    [HttpGet(nameof(GetPetByIsn), Name = nameof(GetPetByIsn))]
    public async Task<ActionResult<PetDto>> GetPetByIsn(GetPetByIsnQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region PetFood

    /// <summary>
    /// Создание корма
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор корма</returns>
    [HttpPost(nameof(CreatePetFood), Name = nameof(CreatePetFood))]
    public async Task<ActionResult<Guid>> CreatePetFood(CreatePetFoodCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование данных корма
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор корма</returns>
    [HttpPost(nameof(UpdatePetFood), Name = nameof(UpdatePetFood))]
    public async Task<ActionResult<Guid>> UpdatePetFood(UpdatePetFoodCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление корма
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPost(nameof(DeletePetFood), Name = nameof(DeletePetFood))]
    public async Task<ActionResult> DeletePetFood(DeletePetFoodCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение списка кормов
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список кормов</returns>
    [HttpGet(nameof(GetListPetFoods), Name = nameof(GetListPetFoods))]
    public async Task<ActionResult<PetFoodDto[]>> GetListPetFoods([FromQuery] GetListPetFoodsQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение данных корма
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные корма</returns>
    [HttpGet(nameof(GetPetFoodByIsn), Name = nameof(GetPetFoodByIsn))]
    public async Task<ActionResult<PetFoodDto>> GetPetFoodByIsn(GetPetFoodByIsnQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region PetToy

    /// <summary>
    /// Создание игрушки
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор игрушки</returns>
    [HttpPost(nameof(CreatePetToy), Name = nameof(CreatePetToy))]
    public async Task<ActionResult<Guid>> CreatePetToy(CreatePetToyCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование данных игрушки
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор игрушки</returns>
    [HttpPost(nameof(UpdatePetToy), Name = nameof(UpdatePetToy))]
    public async Task<ActionResult<Guid>> UpdatePetToy(UpdatePetToyCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление игрушки
    /// </summary>
    /// <param name="command">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPost(nameof(DeletePetToy), Name = nameof(DeletePetToy))]
    public async Task<ActionResult> DeletePetToy(DeletePetToyCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение списка игрушек
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список игрушек</returns>
    [HttpGet(nameof(GetListPetToys), Name = nameof(GetListPetToys))]
    public async Task<ActionResult<PetToyDto[]>> GetListPetToys([FromQuery] GetListPetToysQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение данных игрушки
    /// </summary>
    /// <param name="query">Dto запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные игрушки</returns>
    [HttpGet(nameof(GetPetToyByIsn), Name = nameof(GetPetToyByIsn))]
    public async Task<ActionResult<PetToyDto>> GetPetToyByIsn(GetPetToyByIsnQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion
}