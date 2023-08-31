using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterEstoqueAPI.Domain.Models
{
    public struct ProductCount
    {
        public int? Id { get; set; }
        public string? Description { get; set; }
        public int? Quantity { get; set; }
        public int? ProductId { get; set; }
        public string? ProductDescription { get; set; }
        public DateTime? DateOfCount { get; set; }
    }
}
