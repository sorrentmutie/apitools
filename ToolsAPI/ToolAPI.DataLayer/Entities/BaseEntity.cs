using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolAPI.DataLayer.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastModificationDate { get;set; }
        public DateTime? DeleteDate { get; set; }
    }
}
