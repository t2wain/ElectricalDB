using System.ComponentModel.DataAnnotations;

namespace ElectricalEntityLib.Entity
{
    public class LookUp
    {
        public int Id { get; set; }
        [Required]
        public string Value { get; set; } = null!;
        public double Value2 { get; set; }
        public int? ParentId { get; set; }
        public IEnumerable<LookUp>? Children { get; set; }
    }
}
