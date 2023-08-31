using MasterEstoqueAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterEstoqueAPI.Business.Validators
{
    public class ProductGroupValidation
    {
        public bool InsertValidation(ProductGroup productGroup)
        {
            if (productGroup.Description != null) return true;
            else return false;
        }
        public bool AlterValidation(ProductGroup productGroup)
        {
            if (productGroup.Description != null && productGroup.Id > 0) return true;
            else return false;
        }
    }
}
