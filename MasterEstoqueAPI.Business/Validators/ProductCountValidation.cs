using MasterEstoqueAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterEstoqueAPI.Business.Validators
{
    public class ProductCountValidation
    {
        public bool InsertValidation(ProductCount productCount)
        {
            if (productCount.Description != null 
                && productCount.ProductId > 0
                && productCount.Quantity != null
                && productCount.DateOfCount != null) return true;
            else return false;
        }
    }
}
