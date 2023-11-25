using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ElectricalEntityLib.Entity
{
    [Index(nameof(Name), IsUnique = true)]
    public class TraySpec
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public double Width { get; set; }
        public double Depth { get; set; }
        public string BottomType { get; set; } = null!;

    }
}
