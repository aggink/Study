using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Web.Features.Restaurants.Restaurants.Queries;
using Study.Lab3.Web.Features.Restaurants.Menus.Commands;
using Study.Lab3.Web.Features.Restaurants.Menus.Queries;
using Study.Lab3.Web.Features.Restaurants.MenuItems.Commands;
using Study.Lab3.Web.Features.Restaurants.MenuItems.Queries;
using Study.Lab3.Web.Features.Restaurants.Orders.Commands;
using Study.Lab3.Web.Features.Restaurants.Orders.Queries;
using Study.Lab3.Web.Features.Restaurants.OrderItems.Commands;
using Study.Lab3.Web.Features.Restaurants.OrderItems.Queries;
using Study.Lab3.Web.Features.Restaurants.MenuItems.DtoModels;
using Study.Lab3.Web.Features.Restaurants.Menus.DtoModels;
using Study.Lab3.Web.Features.Restaurants.OrderItems.DtoModels;
using Study.Lab3.Web.Features.Restaurants.Orders.DtoModels;
using Study.Lab3.Web.Features.Restaurants.Restaurants.Commands;
using Study.Lab3.Web.Features.Restaurants.Restaurants.DtoModels;

namespace Study.Lab3.Web.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class RestaurantController : Controller
{
    private readonly IMediator _mediator;

    public RestaurantController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region Restaurant

    /// <summary>
    /// Создание ресторана
    /// </summary>
    [HttpPost(nameof(CreateRestaurant), Name = nameof(CreateRestaurant))]
    public async Task<ActionResult<Guid>> CreateRestaurant(CreateRestaurantCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование ресторана
    /// </summary>
    [HttpPost(nameof(UpdateRestaurant), Name = nameof(UpdateRestaurant))]
    public async Task<ActionResult<Guid>> UpdateRestaurant(UpdateRestaurantCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление ресторана
    /// </summary>
    [HttpPost(nameof(DeleteRestaurant), Name = nameof(DeleteRestaurant))]
    public async Task<ActionResult> DeleteRestaurant(DeleteRestaurantCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение списка ресторанов
    /// </summary>
    [HttpGet(nameof(GetListRestaurants), Name = nameof(GetListRestaurants))]
    public async Task<ActionResult<RestaurantDto[]>> GetListRestaurants([FromQuery] GetListRestaurantsQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение ресторана по идентификатору
    /// </summary>
    [HttpGet(nameof(GetRestaurantByIsn), Name = nameof(GetRestaurantByIsn))]
    public async Task<ActionResult<RestaurantDto>> GetRestaurantByIsn(GetRestaurantByIsnQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region Menu

    /// <summary>
    /// Создание меню
    /// </summary>
    [HttpPost(nameof(CreateMenu), Name = nameof(CreateMenu))]
    public async Task<ActionResult<Guid>> CreateMenu(CreateMenuCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование меню
    /// </summary>
    [HttpPost(nameof(UpdateMenu), Name = nameof(UpdateMenu))]
    public async Task<ActionResult<Guid>> UpdateMenu(UpdateMenuCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление меню
    /// </summary>
    [HttpPost(nameof(DeleteMenu), Name = nameof(DeleteMenu))]
    public async Task<ActionResult> DeleteMenu(DeleteMenuCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение меню по идентификатору
    /// </summary>
    [HttpGet(nameof(GetMenuByIsn), Name = nameof(GetMenuByIsn))]
    public async Task<ActionResult<MenuDto>> GetMenuByIsn(GetMenuByIsnQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение меню по ресторану
    /// </summary>
    [HttpGet(nameof(GetMenusByRestaurant), Name = nameof(GetMenusByRestaurant))]
    public async Task<ActionResult<MenuDto[]>> GetMenusByRestaurant([FromQuery] GetMenusByRestaurantQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region MenuItem

    /// <summary>
    /// Создание позиции меню
    /// </summary>
    [HttpPost(nameof(CreateMenuItem), Name = nameof(CreateMenuItem))]
    public async Task<ActionResult<Guid>> CreateMenuItem(CreateMenuItemCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Редактирование позиции меню
    /// </summary>
    [HttpPost(nameof(UpdateMenuItem), Name = nameof(UpdateMenuItem))]
    public async Task<ActionResult<Guid>> UpdateMenuItem(UpdateMenuItemCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление позиции меню
    /// </summary>
    [HttpPost(nameof(DeleteMenuItem), Name = nameof(DeleteMenuItem))]
    public async Task<ActionResult> DeleteMenuItem(DeleteMenuItemCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение позиции меню по идентификатору
    /// </summary>
    [HttpGet(nameof(GetMenuItemByIsn), Name = nameof(GetMenuItemByIsn))]
    public async Task<ActionResult<MenuItemDto>> GetMenuItemByIsn(GetMenuItemByIsnQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение позиций меню
    /// </summary>
    [HttpGet(nameof(GetMenuItems), Name = nameof(GetMenuItems))]
    public async Task<ActionResult<MenuItemDto[]>> GetMenuItems([FromQuery] GetMenuItemsQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение позиций меню по категории
    /// </summary>
    [HttpGet(nameof(GetMenuItemsByCategory), Name = nameof(GetMenuItemsByCategory))]
    public async Task<ActionResult<MenuItemDto[]>> GetMenuItemsByCategory([FromQuery] GetMenuItemsByCategoryQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region RestaurantOrder

    /// <summary>
    /// Создание заказа
    /// </summary>
    [HttpPost(nameof(CreateOrder), Name = nameof(CreateOrder))]
    public async Task<ActionResult<Guid>> CreateOrder(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Обновление заказа
    /// </summary>
    [HttpPost(nameof(UpdateOrder), Name = nameof(UpdateOrder))]
    public async Task<ActionResult<Guid>> UpdateOrder(UpdateOrderCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Обновление статуса заказа
    /// </summary>
    [HttpPost(nameof(UpdateOrderStatus), Name = nameof(UpdateOrderStatus))]
    public async Task<ActionResult> UpdateOrderStatus(UpdateOrderStatusCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Удаление заказа
    /// </summary>
    [HttpPost(nameof(DeleteOrder), Name = nameof(DeleteOrder))]
    public async Task<ActionResult> DeleteOrder(DeleteOrderCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение заказа по идентификатору
    /// </summary>
    [HttpGet(nameof(GetOrderByIsn), Name = nameof(GetOrderByIsn))]
    public async Task<ActionResult<RestaurantOrderDto>> GetOrderByIsn(GetOrderByIsnQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение заказов ресторана
    /// </summary>
    [HttpGet(nameof(GetOrdersByRestaurant), Name = nameof(GetOrdersByRestaurant))]
    public async Task<ActionResult<RestaurantOrderDto[]>> GetOrdersByRestaurant([FromQuery] GetOrdersByRestaurantQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение заказов по статусу
    /// </summary>
    [HttpGet(nameof(GetOrdersByStatus), Name = nameof(GetOrdersByStatus))]
    public async Task<ActionResult<RestaurantOrderDto[]>> GetOrdersByStatus([FromQuery] GetOrdersByStatusQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region OrderItem

    /// <summary>
    /// Добавление позиции в заказ
    /// </summary>
    [HttpPost(nameof(AddOrderItem), Name = nameof(AddOrderItem))]
    public async Task<ActionResult<Guid>> AddOrderItem(CreateOrderItemCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Обновление позиции заказа
    /// </summary>
    [HttpPost(nameof(UpdateOrderItem), Name = nameof(UpdateOrderItem))]
    public async Task<ActionResult<Guid>> UpdateOrderItem(UpdateOrderItemCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление позиции заказа
    /// </summary>
    [HttpPost(nameof(DeleteOrderItem), Name = nameof(DeleteOrderItem))]
    public async Task<ActionResult> DeleteOrderItem(DeleteOrderItemCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение позиции заказа по идентификатору
    /// </summary>
    [HttpGet(nameof(GetOrderItemByIsn), Name = nameof(GetOrderItemByIsn))]
    public async Task<ActionResult<OrderItemDto>> GetOrderItemByIsn(GetOrderItemByIsnQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение позиций заказа
    /// </summary>
    [HttpGet(nameof(GetOrderItems), Name = nameof(GetOrderItems))]
    public async Task<ActionResult<OrderItemDto[]>> GetOrderItems([FromQuery] GetOrderItemsQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion
}