using AutoMapper;
using ToolAPI.DataLayer.Entities;
using ToolsAPi.Core.Models;
using ToolsAPi.Core.Requests;

namespace ToolsAPI.BusinessLayer.Mappers
{
    public class OrderMapper: Profile
    {
        public OrderMapper()
        {
            CreateMap<Order, OrderViewModel>();
            CreateMap<SaveOrderRequest, Order>();
        }
    }
}
