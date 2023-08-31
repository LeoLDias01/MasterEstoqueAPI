using MasterEstoqueAPI.Domain.Models;
using System.Data;

namespace MasterEstoqueAPI.Domain.Infra
{
    public interface IMasterEstoqueAPIRepository
    {
        void DeleteProductGroup(int id);
        void DeleteSupplier(int id);
        List<ProductGroup> GetProductGroup(int id);
        List<ProductGroup> GetProductsGroup();
        List<Supplier> GetSupplier(int id);
        List<Supplier> GetSuppliers();
        int InsertProductGroup(ProductGroup productGroup);
        int InsertSupplier(Supplier supplier);
        int UpdateProductGroup(ProductGroup productGroup);
        int UpdateSupplier(Supplier supplier);
        List<Product> GetProducts();
        List<Product> GetProduct(int id);
        int InsertProduct(Product product);
        int UpdateProduct(Product product);
        void DeleteProduct(int id);
        List<ProductCount> GetProductsCount();
        List<ProductCount> GetProductCount(int id);
        int InsertProductCount(ProductCount productCount);
    }
}