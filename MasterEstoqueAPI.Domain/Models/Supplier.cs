using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterEstoqueAPI.Domain.Models
{
    public struct Supplier
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? CNPJ { get; set; }
        public string? Ie { get; set; }
    }
}
