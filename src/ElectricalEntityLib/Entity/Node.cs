using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ElectricalEntityLib.Entity
{
    [Index(nameof(Name), IsUnique = true)]
    public class Node
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public int? BranchId { get; set; }
        public NodeEnum NodeType { get; set; }
        public int? NextNodeId { get; set; }
        public Node? NextNode { get; set; }
        public double? LengthToNextNode { get; set; }
        public double? XCoord { get; set; }
        public double? YCoord { get; set; }
        public double? ZCoord { get; set; }
    }
}
