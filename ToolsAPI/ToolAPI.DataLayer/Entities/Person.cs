using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolAPI.DataLayer.Entities
{
    public class Person: BaseEntity
    {
        public string Name { get; set; }
        public string Country { get; set; }
        // public int Anno { get; set; }
        // public double Rating { get; set; }
    }
}
