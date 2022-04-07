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
    public class PersonConfiguration : BaseEntityConfiguration<Person>
    {
        public override void Configure(EntityTypeBuilder<Person> builder)
        {
            base.Configure(builder);
            builder.ToTable("Persone");
            //builder.HasKey(x => x.Id);
            //builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Name).HasColumnName("COLNAME");
            // builder.Property(x => x.Rating).HasPrecision(14, 2);
            // builder.Property(x => x.CreationDate).HasPrecision(3)

           // builder.HasKey(x => new { x.Id, x.Anno});
        }
    }
}
