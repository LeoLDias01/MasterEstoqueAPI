using MasterEstoqueAPI.Data.Repository;
using MasterEstoqueAPI.Domain.Infra;
using MasterEstoqueAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Slapper.AutoMapper;

namespace MasterEstoqueAPI.Business.Services
{
    public class MasterEstoqueAPIService : IMasterEstoqueAPIService
    {
        private readonly IMasterEstoqueAPIRepository _repository;

        #region ..:: Constructor ::..
        public MasterEstoqueAPIService(IMasterEstoqueAPIRepository repository)
        {
            _repository = repository;
        }
        #endregion

        #region ..:: Supplier ::..
        public Supplier InsertSupplier(Supplier supplier)
        {
            supplier.Id = _repository.InsertSupplier(supplier);
            return supplier;
        }
        public Supplier UpdateSupplier(Supplier supplier)
        {
            supplier.Id = _repository.UpdateSupplier(supplier);
            return supplier;
        }
        public void DeleteSupplier(int id)
        {
            _repository.DeleteSupplier(id);
        }
        public List<Supplier> GetSupplier(int id)
        {
            return _repository.GetSupplier(id);
        }
        public List<Supplier> GetSuppliers()
        {
            return _repository.GetSuppliers();
        }
        #endregion

        #region ..:: Product Group ::..
        public ProductGroup InsertProductGroup(ProductGroup productGroup)
        {
            productGroup.Id = _repository.InsertProductGroup(productGroup);
            return productGroup;
        }
        public ProductGroup UpdateProductGroup(ProductGroup productGroup)
        {
            productGroup.Id = _repository.UpdateProductGroup(productGroup);
            return productGroup;
        }
        public void DeleteProductGroup(int id)
        {
            _repository.DeleteProductGroup(id);
        }
        public List<ProductGroup> GetProductGroup(int id)
        {
            return _repository.GetProductGroup(id);
        }
        public List<ProductGroup> GetProductsGroup()
        {
            return _repository.GetProductsGroup();
        }
        #endregion

        #region ..:: Product ::..
        public Product InsertProduct(Product product)
        {
            product.Id = _repository.InsertProduct(product);
            return product;
        }
        public Product UpdateProduct(Product product)
        {
            product.Id = _repository.UpdateProduct(product);
            return product;
        }
        public void DeleteProduct(int id)
        {
            _repository.DeleteProduct(id);
        }
        public List<Product> GetProduct(int id)
        {
            return _repository.GetProduct(id);
        }
        public List<Product> GetProducts()
        {
            return _repository.GetProducts();
        }
        #endregion

        #region ..:: Product Count ::..
        public ProductCount InsertProductCount(ProductCount productCount)
        {
            productCount.Id = _repository.InsertProductCount(productCount);
            return productCount;
        }
        public List<ProductCount> GetProductCount(int id)
        {
            return _repository.GetProductCount(id);
        }
        public List<ProductCount> GetProductsCount()
        {
            return _repository.GetProductsCount();
        }
        #endregion
    }
}
