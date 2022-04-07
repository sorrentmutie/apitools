using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolAPI.DataLayer.Entities;

namespace ToolAPI.DataLayer.Configurations
{
    public class OrderConfiguration : BaseEntityConfiguration<Order> {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            base.Configure(builder);
            builder.ToTable("Ordini");
            builder.Property(x => x.Date).HasColumnName("ORD_TD");
            builder.Property(x => x.Status).HasConversion<string>();
            builder.Property(x => x.Price).HasPrecision(14, 2);
        }
    }
}
