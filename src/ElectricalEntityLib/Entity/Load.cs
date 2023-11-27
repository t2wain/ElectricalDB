using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ElectricalEntityLib.Entity
{
    [Index(nameof(Name), IsUnique = true)]
    public class Load
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public double? Size { get; set; }
        [Required]
        public int? SizeUnit { get; set; }
        [Required]
        public int? LoadType { get; set; }
        public double? Voltage { get; set; }
        public int? Phase { get; set; }
        public double? FLA { get; set; }
        public double? FLAPF { get; set; }
        public double? LRA { get; set; }
        public double? LRAPF { get; set; }
        public int? LibraryId { get; set; }
        public LookUp? Library { get; set; }

    }
}
