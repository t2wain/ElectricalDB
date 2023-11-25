using ElectricalEntityLib.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectricalEntityLib.Config
{
    public class CableEntityTypeConfiguration : IEntityTypeConfiguration<Cable>
    {
        public void Configure(EntityTypeBuilder<Cable> builder)
        {
            builder
                .Property(c => c.ServiceType)
                .HasConversion<string>();

            builder
                .HasMany<Route>()
                .WithOne(rt => rt.Cable)
                .HasForeignKey(rt => rt.CableId);

            builder
                .HasOne(c => c.Route)
                .WithOne(rt => rt.Cable)
                .HasForeignKey<Cable>(c => c.RouteId);

        }
    }
}
