using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ElectricalEntityLib.Entity
{
    [Index(nameof(Name), IsUnique = true)]
    public class Raceway
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public double Length { get; set; }
        public RacewayEnum RacewayType { get; set; }
        public int FromNodeId { get; set; }
        public Node? FromNode { get; set; }
        public int ToNodeId { get; set; }
        public Node? ToNode { get; set; }
        public int? TraySpecId { get; set; }
        public TraySpec? TraySpec { get; set; }
        public int? BranchId { get; set; }
        public Branch? Branch { get; set; }
        public IEnumerable<RacewaySegSystem>? SegSystems { get; set; }
        public string? NecRule { get; set; }
        public double PercentFill { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsRoutingBlocked { get; set; }
    }
}
