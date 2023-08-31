using MasterEstoqueAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterEstoqueAPI.Domain.Infra
{
    public interface IMasterEstoqueAPIService
    {
        #region ..:: Supplier ::..
        public Supplier InsertSupplier(Supplier supplier);
        public Supplier UpdateSupplier(Supplier supplier);
        public void DeleteSupplier(int id);
        public List<Supplier> GetSupplier(int id);
        public List<Supplier> GetSuppliers();
        #endregion

        #region ..:: Product Group ::..
        public ProductGroup InsertProductGroup(ProductGroup productGroup);
        public ProductGroup UpdateProductGroup(ProductGroup productGroup);
        public void DeleteProductGroup(int id);
        public List<ProductGroup> GetProductGroup(int id);
        public List<ProductGroup> GetProductsGroup();
        #endregion

        #region ..:: Product ::..
        public Product InsertProduct(Product product);
        public Product UpdateProduct(Product product);
        public void DeleteProduct(int id);
        public List<Product> GetProduct(int id);
        public List<Product> GetProducts();
        #endregion

        #region ..:: Product Count ::..
        public ProductCount InsertProductCount(ProductCount productCount);
        public List<ProductCount> GetProductCount(int id);
        public List<ProductCount> GetProductsCount();
        #endregion
    }
}
