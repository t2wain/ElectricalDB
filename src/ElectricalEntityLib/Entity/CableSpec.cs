using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ElectricalEntityLib.Entity
{
    [Index(nameof(Name), nameof(CableLibraryId), IsUnique = true)]
    public class CableSpec
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public ServiceEnum ServiceType { get; set; }
        public string? Description { get; set; }
        public double? OutsideDiameter { get; set; }
        public double? Weight { get; set; }
        public int? ConductorSizeId { get; set; }
        public LookUp? ConductorSize { get; set; }
        public double InsulationVoltage { get; set; }
        public bool IsSingleConductor { get; set; }
        public double RUnitLength { get; set; }
        public double XUnitLength { get; set; }
        public double Ampacity { get; set; }
        public int? CableLibraryId { get; set; }
        public LookUp? CableLibrary { get; set; }
    }
}
