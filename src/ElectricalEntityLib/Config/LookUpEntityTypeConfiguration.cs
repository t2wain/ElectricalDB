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
    public class LookUpEntityTypeConfiguration : IEntityTypeConfiguration<LookUp>
    {
        public void Configure(EntityTypeBuilder<LookUp> builder)
        {
            builder
                .HasMany(lu => lu.Children)
                .WithOne()
                .HasForeignKey(lu => lu.ParentId);
        }
    }
}
