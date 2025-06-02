using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Web.Features.HospitalStore.Order.Commands;
using Study.Lab3.Web.Features.HospitalStore.Order.DtoModels;
using Study.Lab3.Web.Features.HospitalStore.Order.Queries;
using Study.Lab3.Web.Features.HospitalStore.Patient.Commands;
using Study.Lab3.Web.Features.HospitalStore.Patient.DtoModels;
using Study.Lab3.Web.Features.HospitalStore.Patient.Queries;
using Study.Lab3.Web.Features.HospitalStore.Product.Commands;
using Study.Lab3.Web.Features.HospitalStore.Product.DtoModels;
using Study.Lab3.Web.Features.HospitalStore.Product.Queries;

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

    #region Patients

    [HttpPost("patients")]
    public async Task<ActionResult<Guid>> CreatePatient([FromBody] CreatePatientCommand command, CancellationToken cancellationToken)
    {
        var id = await _mediator.Send(command, cancellationToken);
        return Ok(id);
    }

    [HttpPut("patients")]
    public async Task<ActionResult<Guid>> UpdatePatient([FromBody] UpdatePatientCommand command, CancellationToken cancellationToken)
    {
        var id = await _mediator.Send(command, cancellationToken);
        return Ok(id);
    }

    [HttpDelete("patients")]
    public async Task<ActionResult> DeletePatient([FromBody] DeletePatientCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    [HttpGet("patients/{id}")]
    public async Task<ActionResult<PatientDto>> GetPatientById([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetPatientByIsnQuery(id), cancellationToken);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpGet("patients")]
    public async Task<ActionResult<PatientDto[]>> GetListPatients(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetListPatientQuery(), cancellationToken);
        return Ok(result);
    }

    #endregion

    #region Products

    [HttpPost("products")]
    public async Task<ActionResult<Guid>> CreateProduct([FromBody] CreateProductCommand command, CancellationToken cancellationToken)
    {
        var id = await _mediator.Send(command, cancellationToken);
        return Ok(id);
    }

    [HttpPut("products")]
    public async Task<ActionResult<Guid>> UpdateProduct([FromBody] UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var id = await _mediator.Send(command, cancellationToken);
        return Ok(id);
    }

    [HttpDelete("products")]
    public async Task<ActionResult> DeleteProduct([FromBody] DeleteProductCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    [HttpGet("products/{id}")]
    public async Task<ActionResult<ProductDto>> GetProductById([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetProductByIsnQuery(id), cancellationToken);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpGet("products")]
    public async Task<ActionResult<ProductDto[]>> GetListProducts(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetListProductQuery(), cancellationToken);
        return Ok(result);
    }

    #endregion
}
