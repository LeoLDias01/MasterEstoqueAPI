using MasterEstoqueAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterEstoqueAPI.Business.Validators
{
    public class SupplierValidation
    {
        public bool InsertValidation(Supplier supplier) 
        {
            if (supplier.Name != null && supplier.CNPJ != null && supplier.Ie != null) return true;
            else return false;
        }
        public bool AlterValidation(Supplier supplier)
        {
            if (supplier.Name != null && supplier.CNPJ != null && supplier.Ie != null && supplier.Id > 0) return true;
            else return false;
        }
    }
}
