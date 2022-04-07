using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsAPi.Core.Enums;

namespace ToolAPI.DataLayer.Entities
{
    public class Order : BaseEntity
    {
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public OrderStatus Status { get; set; }
    }
}
