using Microsoft.AspNetCore.Mvc;
using ToolsAPi.Core.Requests;
using ToolsAPI.BusinessLayer.Services;

namespace ToolsAPI.Controllers;

public class OrdersController : MyControllerBase
{
    private readonly IOrderService orderService;
    private readonly ILogger logger;

    public OrdersController(IOrderService orderService, ILogger<StartupBase> logger)
    {
        this.orderService = orderService;
        this.logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        // throw new ApplicationException("Errore Gravissimo");
        logger.LogCritical("Aiuto");
        return Ok(await orderService.GetOrdersAsync());

    }

    [HttpPost]
    public async Task<IActionResult> PostNewOrder([FromBody] SaveOrderRequest order)
    {
        var savedOrder = await orderService.SaveAsync(order);
        return Ok(savedOrder);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutOrder([FromBody] SaveOrderRequest order, int id)
    {
        var savedOrder = await orderService.SaveAsync(order);
        return NoContent();
    }
}
