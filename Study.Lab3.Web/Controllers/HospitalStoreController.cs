using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Web.Features.HospitalStore.Order.Commands;
using Study.Lab3.Web.Features.HospitalStore.Order.DtoModels;
using Study.Lab3.Web.Features.HospitalStore.Order.Queries;

namespace Study.Lab3.Web.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class HospitalStoreController : ControllerBase
{
    private readonly IMediator _mediator;

    public HospitalStoreController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region Orders

    /// <summary>
    /// Создать новый заказ
    /// </summary>
    /// <param name="command">Команда для создания заказа</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    /// <returns>Идентификатор созданного заказа</returns>
    [HttpPost("orders")]
    public async Task<ActionResult<Guid>> CreateOrder([FromBody] CreateOrderCommand command, CancellationToken cancellationToken)
    {
        var id = await _mediator.Send(command, cancellationToken);
        return Ok(id);
    }

    /// <summary>
    /// Обновить существующий заказ
    /// </summary>
    /// <param name="command">Команда для обновления заказа</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    /// <returns>Идентификатор обновлённого заказа</returns>
    [HttpPut("orders")]
    public async Task<ActionResult<Guid>> UpdateOrder([FromBody] UpdateOrderCommand command, CancellationToken cancellationToken)
    {
        var id = await _mediator.Send(command, cancellationToken);
        return Ok(id);
    }

    /// <summary>
    /// Удалить заказ
    /// </summary>
    /// <param name="command">Команда для удаления заказа</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    /// <returns>Результат выполнения</returns>
    [HttpDelete("orders")]
    public async Task<ActionResult> DeleteOrder([FromBody] DeleteOrderCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получить заказ по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор заказа</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    /// <returns>Информация о заказе</returns>
    [HttpGet("orders/{id}")]
    public async Task<ActionResult<OrderDto>> GetOrderById([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var query = new GetOrderByIsnQuery(id);
        var result = await _mediator.Send(query, cancellationToken);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    /// <summary>
    /// Получить список всех заказов
    /// </summary>
    /// <param name="cancellationToken">Токен отмены операции</param>
    /// <returns>Список заказов</returns>
    [HttpGet("orders")]
    public async Task<ActionResult<OrderDto[]>> GetListOrders(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetListOrderQuery(), cancellationToken);
        return Ok(result);
    }

    #endregion
}
