using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterEstoqueAPI.Domain.Models
{
    public struct Product
    {
        public int? Id { get; set; }
        public string? Description { get; set; }
        public int? Quantity { get; set; }
        public int? GroupId { get; set; }
        public string? Group { get; set; }
        public int? SupplierId { get; set; }
        public string? Supplier { get; set; }
    }
}
