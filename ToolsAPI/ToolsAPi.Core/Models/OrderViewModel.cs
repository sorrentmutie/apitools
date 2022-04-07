using System;
using System.Collections.Generic;
using System.Text;
using ToolsAPi.Core.Enums;

namespace ToolsAPi.Core.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public OrderStatus Status { get; set; }
    }
}
