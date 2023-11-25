using ElectricalEntityLib.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalEntityLib.Config
{
    public class NodeEntityTypeConfiguration : IEntityTypeConfiguration<Node>
    {
        public void Configure(EntityTypeBuilder<Node> builder)
        {
            builder
                .Property(n => n.NodeType)
                .HasConversion<string>();

            //builder.HasKey(n => n.Id);

            //builder
            //    .Property(n => n.Name)
            //    .IsRequired();

            //builder
            //    .HasIndex(c => c.Name)
            //    .IsUnique();
        }
    }
}
