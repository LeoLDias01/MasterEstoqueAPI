using MasterEstoqueAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterEstoqueAPI.Business.Validators
{
    public class ProductValidation
    {
        public bool InsertValidation(Product product)
        {
            if (product.Description != null && product.Description.Length > 1
                && product.Quantity != null
                && product.GroupId > 0
                && product.SupplierId > 0) return true;
            else return false;
        }
        public bool AlterValidation(Product product)
        {
            if (product.Description != null && product.Description.Length > 1
                && product.Quantity != null
                && product.GroupId > 0
                && product.SupplierId > 0
                && product.Id > 0) return true;
            else return false;
        }
    }
}
