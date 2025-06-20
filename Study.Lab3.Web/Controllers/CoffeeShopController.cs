using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Web.Features.CoffeeShop.Barista.Commands;
using Study.Lab3.Web.Features.CoffeeShop.Barista.DtoModels;
using Study.Lab3.Web.Features.CoffeeShop.Barista.Queries;
using Study.Lab3.Web.Features.CoffeeShop.Coffee.Commands;
using Study.Lab3.Web.Features.CoffeeShop.Coffee.DtoModels;
using Study.Lab3.Web.Features.CoffeeShop.Coffee.Queries;
using Study.Lab3.Web.Features.CoffeeShop.CoffeeShops.Commands;
using Study.Lab3.Web.Features.CoffeeShop.CoffeeShops.DtoModels;
using Study.Lab3.Web.Features.CoffeeShop.CoffeeShops.Queries;

namespace Study.Lab3.Web.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class CoffeeShopController : Controller
{
    private readonly IMediator _mediator;

    public CoffeeShopController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region CoffeeShop
    /// <summary>
    /// Создание кофейни
    /// </summary>
    [HttpPost(nameof(CreateCoffeeShop), Name = nameof(CreateCoffeeShop))]
    public async Task<ActionResult<Guid>> CreateCoffeeShop(CreateCoffeeShopCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование кофейни
    /// </summary>
    [HttpPost(nameof(UpdateCoffeeShop), Name = nameof(UpdateCoffeeShop))]
    public async Task<ActionResult<Guid>> UpdateCoffeeShop(UpdateCoffeeShopCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление кофейни
    /// </summary>
    [HttpPost(nameof(DeleteCoffeeShop), Name = nameof(DeleteCoffeeShop))]
    public async Task<ActionResult> DeleteCoffeeShop(DeleteCoffeeShopCommand command,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение списка кофеен
    /// </summary>
    [HttpGet(nameof(GetListCoffeeShop), Name = nameof(GetListCoffeeShop))]
    public async Task<ActionResult<CoffeeShopDto[]>> GetListCoffeeShop([FromQuery] GetListCoffeeShopQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение кофейни по идентификатору
    /// </summary>
    [HttpGet(nameof(GetCoffeeShopByIsn), Name = nameof(GetCoffeeShopByIsn))]
    public async Task<ActionResult<CoffeeShopDto>> GetCoffeeShopByIsn(GetCoffeeShopByIsnQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    #endregion
    
    #region Barista
    
    /// <summary>
    /// Создание бариста
    /// </summary>
    [HttpPost(nameof(CreateBarista), Name = nameof(CreateBarista))]
    public async Task<ActionResult<Guid>> CreateBarista(CreateBaristaCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование бариста
    /// </summary>
    [HttpPost(nameof(UpdateBarista), Name = nameof(UpdateBarista))]
    public async Task<ActionResult<Guid>> UpdateBarista(UpdateBaristaCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление бариста
    /// </summary>
    [HttpPost(nameof(DeleteBarista), Name = nameof(DeleteBarista))]
    public async Task<ActionResult> DeleteBarista(DeleteBaristaCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение списка бариста
    /// </summary>
    [HttpGet(nameof(GetListBarista), Name = nameof(GetListBarista))]
    public async Task<ActionResult<BaristaDto[]>> GetListBarista([FromQuery] GetListBaristaQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение бариста по идентификатору
    /// </summary>
    [HttpGet(nameof(GetBaristaByIsn), Name = nameof(GetBaristaByIsn))]
    public async Task<ActionResult<BaristaDto>> GetBaristaByIsn(GetBaristaByIsnQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    
    #endregion
    
    #region Coffee
    
    /// <summary>
    /// Создание кофе
    /// </summary>
    [HttpPost(nameof(CreateCoffee), Name = nameof(CreateCoffee))]
    public async Task<ActionResult<Guid>> CreateCoffee(CreateCoffeeCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование кофе
    /// </summary>
    [HttpPost(nameof(UpdateCoffee), Name = nameof(UpdateCoffee))]
    public async Task<ActionResult<Guid>> UpdateCoffee(UpdateCoffeeCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление кофе
    /// </summary>
    [HttpPost(nameof(DeleteCoffee), Name = nameof(DeleteCoffee))]
    public async Task<ActionResult> DeleteCoffee(DeleteCoffeeCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение списка кофе
    /// </summary>
    [HttpGet(nameof(GetListCoffee), Name = nameof(GetListCoffee))]
    public async Task<ActionResult<CoffeeDto[]>> GetListCoffee([FromQuery] GetListCoffeeQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение кофе по идентификатору
    /// </summary>
    [HttpGet(nameof(GetCoffeeByIsn), Name = nameof(GetCoffeeByIsn))]
    public async Task<ActionResult<CoffeeDto>> GetCoffeeByIsn(GetCoffeeByIsnQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    
    #endregion
}