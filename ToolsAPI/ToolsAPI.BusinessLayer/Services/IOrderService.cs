using ToolsAPi.Core.Models;
using ToolsAPi.Core.Requests;

namespace ToolsAPI.BusinessLayer.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderViewModel>> GetOrdersAsync();
        Task<OrderViewModel> SaveAsync(SaveOrderRequest order);
    }
}