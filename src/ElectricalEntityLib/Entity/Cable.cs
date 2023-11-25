using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ElectricalEntityLib.Entity
{
    [Index(nameof(Name), IsUnique = true)]
    public class Cable
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public ServiceEnum ServiceType { get; set; }
        public int? CableSpecId { get; set; }
        public CableSpec? CableSpec { get; set; }
        public int? FromNodeId { get; set; }
        public Node? FromNode { get; set; }
        public int? ToNodeId { get; set; }
        public Node? ToNode { get; set; }
        public int? SegSystemId { get; set; }
        public SegSystem? SegSystem { get; set; }
        public int RoutingStatus { get; set; }

        public int? RouteId { get; set; }
        public Route? Route { get; set; }
        public int? RouteSpecId { get; set; }
        public RouteSpec? RouteSpec { get; set; }
    }
}
