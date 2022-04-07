using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolAPI.DataLayer;
using ToolAPI.DataLayer.Entities;
using ToolsAPi.Core.Models;
using ToolsAPi.Core.Requests;

namespace ToolsAPI.BusinessLayer.Services
{
    public class OrderService : IOrderService
    {
        private readonly IDataContext dataContext;
        private readonly IMapper mapper;

        public OrderService(IDataContext dataContext, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<OrderViewModel>> GetOrdersAsync()
        {
            var query = dataContext.GetData<Order>();
            var orders = await query.
                ProjectTo<OrderViewModel>(mapper.ConfigurationProvider).
                ToListAsync();
            return orders;
        }


        public async Task<OrderViewModel> SaveAsync(SaveOrderRequest order)
        {
            var orderDb = order.Id > 0 ?
                await dataContext.GetData<Order>()
                .FirstOrDefaultAsync(o => o.Id == order.Id) : null;
            
            if(orderDb == null)
            {
                orderDb = mapper.Map<Order>(order);
                orderDb.CreationDate = DateTime.Now;
                orderDb.Date = DateTime.Now;
                orderDb.Status = ToolsAPi.Core.Enums.OrderStatus.New;
                dataContext.Insert(orderDb);
            } else
            {
                mapper.Map(order, orderDb);
                orderDb.LastModificationDate = DateTime.Now;
            }
            await dataContext.SaveAsync();
            var savedOrder = mapper.Map<OrderViewModel>(orderDb);
            return savedOrder;
        }

    }
}
