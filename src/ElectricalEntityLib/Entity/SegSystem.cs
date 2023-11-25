using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ElectricalEntityLib.Entity
{
    [Index(nameof(Name), IsUnique = true)]
    public class SegSystem
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;

    }
}
