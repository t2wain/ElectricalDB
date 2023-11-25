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
    public class BranchEntityTypeConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            //builder
            //    .HasOne(b => b.StartNode)
            //    .WithOne()
            //    .HasForeignKey<Branch>(b => b.StartNodeId);

            //builder
            //    .HasOne(b => b.EndNode)
            //    .WithOne()
            //    .HasForeignKey<Branch>(b => b.EndNodeId);

            //builder
            //    .HasMany(b => b.Nodes)
            //    .WithOne()
            //    .HasForeignKey(n => n.BranchId);

            builder
                .Property(b => b.BranchType)
                .HasConversion<string>();

        }
    }
}
