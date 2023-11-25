using ElectricalEntityLib.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectricalEntityLib.Config
{
    public class CableSpecEntityTypeConfiguration : IEntityTypeConfiguration<CableSpec>
    {
        public void Configure(EntityTypeBuilder<CableSpec> builder)
        {
            builder
                .Property(cs => cs.ServiceType)
                .HasConversion<string>();

            builder
                .Property(cs => cs.IsSingleConductor)
                .HasConversion<int>();

            //builder.HasKey(cs => cs.Id);

            //builder
            //    .Property(cs => cs.Name)
            //    .IsRequired();

            //builder
            //    .HasIndex(c => c.Name)
            //    .IsUnique();

        }
    }
}
