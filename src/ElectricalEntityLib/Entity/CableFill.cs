using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ElectricalEntityLib.Entity
{
    [Index(nameof(CableId), nameof(RacewayId), IsUnique = true)]
    public class CableFill
    {
        public int Id { get; set; }
        [Required]
        public int CableId { get; set; }
        public Cable? Cable { get; set; }
        [Required]
        public int RacewayId { get; set; }
        public Raceway? Raceway { get; set; }
        public string? FillCategory { get; set; }
        public string? NecRule { get; set; }
        public double PercentFill { get; set; }
    }
}
