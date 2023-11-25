using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectricalEntityLib.Entity
{
    [Index(nameof(Name), IsUnique = true)]
    public class Branch
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public RacewayEnum BranchType { get; set; }
        public int? StartNodeId { get; set; }
        public Node? StartNode { get; set; }
        public int? EndNodeId { get; set; }
        public Node? EndNode { get; set; }
        public IEnumerable<RacewaySegSystem>? SegSystems { get; set; }
        public IEnumerable<Node>? Nodes { get; set; }

    }
}
