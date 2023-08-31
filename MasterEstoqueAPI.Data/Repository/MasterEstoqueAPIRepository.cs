using Dapper;
using MasterEstoqueAPI.Domain.Infra;
using MasterEstoqueAPI.Domain.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterEstoqueAPI.Data.Repository
{
    public class MasterEstoqueAPIRepository : IMasterEstoqueAPIRepository
    {
        #region ..:: Instances and Variables ::..
        private readonly IDbContext _dbContext;
        #endregion

        #region ..:: Constructor ::..
        public MasterEstoqueAPIRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region ..:: Suppliers ::..
        public List<Supplier> GetSuppliers()
        {
            using (var conn = _dbContext.GetConnection())
            {
                return conn.Query($@"SELECT [ID_SUPPLIER], [NAME], [CNPJ], [IE] 
                                     FROM SUPPLIER
                                     WHERE [ACTIVE] = 1")
                .Select(x => new Supplier
                {
                    Id = x.ID_SUPPLIER,
                    Name = x.NAME,
                    CNPJ = x.CNPJ,
                    Ie = x.IE
                }).ToList();
            }
        }
        public List<Supplier> GetSupplier(int id)
        {
            using (var conn = _dbContext.GetConnection())
            {
                return conn.Query($@"SELECT [ID_SUPPLIER], [NAME], [CNPJ], [IE] 
                                     FROM SUPPLIER 
                                     WHERE ID_SUPPLIER = @ID_SUPPLIER",
                param: new { ID_SUPPLIER = id }, commandType: CommandType.Text)
                .Select(x => new Supplier
                {
                    Id = x.ID_SUPPLIER,
                    Name = x.NAME,
                    CNPJ = x.CNPJ,
                    Ie = x.IE
                }).ToList();
            }
        }
        public int InsertSupplier(Supplier supplier)
        {
            using (var conn = _dbContext.GetConnection())
            {
                return conn.QuerySingle<int>($@"INSERT INTO SUPPLIER([NAME], [CNPJ], [IE])
                                                OUTPUT INSERTED.ID_SUPPLIER
                                                VALUES(@NAME, @CNPJ, @IE)",
                param: new { NAME = supplier.Name, CNPJ = supplier.CNPJ, IE = supplier.Ie }, commandType: CommandType.Text);
            }
        }
        public int UpdateSupplier(Supplier supplier)
        {
            using (var conn = _dbContext.GetConnection())
            {
                return conn.QuerySingle<int>($@"UPDATE SUPPLIER
                                                SET [NAME] = @NAME, [CNPJ] = @CNPJ, [IE]=  @IE
                                                OUTPUT INSERTED.ID_SUPPLIER
                                                WHERE [ID_SUPPLIER] = @ID_SUPPLIER",
                param: new { NAME = supplier.Name, CNPJ = supplier.CNPJ, IE = supplier.Ie, ID_SUPPLIER = supplier.Id }, commandType: CommandType.Text);
            }
        }
        public void DeleteSupplier(int id)
        {
            using (var conn = _dbContext.GetConnection())
            {
                conn.Query($@"UPDATE SUPPLIER
                              SET [ACTIVE] = 0
                              WHERE [ID_SUPPLIER] = @ID_SUPPLIER",
                param: new { ID_SUPPLIER = id }, commandType: CommandType.Text);
            }
        }
        #endregion

        #region ..:: ProductsGroup ::..
        public List<ProductGroup> GetProductsGroup()
        {
            using (var conn = _dbContext.GetConnection())
            {
                return conn.Query($@"SELECT [ID_PRODUCT_GROUP], [DESCRIPTION]
                                     FROM PRODUCT_GROUP
                                     WHERE [ACTIVE] = 1")
                .Select(x => new ProductGroup
                {
                    Id = x.ID_PRODUCT_GROUP,
                    Description = x.DESCRIPTION
                }).ToList();
            }
        }
        public List<ProductGroup> GetProductGroup(int id)
        {
            using (var conn = _dbContext.GetConnection())
            {
                return conn.Query($@"SELECT [ID_PRODUCT_GROUP], [DESCRIPTION]
                                     FROM PRODUCT_GROUP
                                     WHERE ID_PRODUCT_GROUP = @ID_PRODUCT_GROUP",
                param: new { ID_PRODUCT_GROUP = id }, commandType: CommandType.Text)
                .Select(x => new ProductGroup
                {
                    Id = x.ID_PRODUCT_GROUP,
                    Description = x.DESCRIPTION
                }).ToList();
            }
        }
        public int InsertProductGroup(ProductGroup productGroup)
        {
            using (var conn = _dbContext.GetConnection())
            {
                return conn.QuerySingle<int>($@"INSERT INTO PRODUCT_GROUP([DESCRIPTION])
                                                OUTPUT INSERTED.[ID_PRODUCT_GROUP]
                                                VALUES(@DESCRIPTION)",
                param: new { DESCRIPTION = productGroup.Description }, commandType: CommandType.Text);
            }
        }
        public int UpdateProductGroup(ProductGroup productGroup)
        {
            using (var conn = _dbContext.GetConnection())
            {
                return conn.QuerySingle<int>($@"UPDATE PRODUCT_GROUP
                                                SET [DESCRIPTION] = @DESCRIPTION
                                                OUTPUT INSERTED.ID_PRODUCT_GROUP
                                                WHERE [ID_PRODUCT_GROUP] = @ID_PRODUCT_GROUP",
                param: new { DESCRIPTION = productGroup.Description, ID_PRODUCT_GROUP = productGroup.Id }, commandType: CommandType.Text);
            }
        }
        public void DeleteProductGroup(int id)
        {
            using (var conn = _dbContext.GetConnection())
            {
                conn.Query($@"UPDATE PRODUCT_GROUP
                              SET [ACTIVE] = 0
                              WHERE [ID_PRODUCT_GROUP] = @ID_PRODUCT_GROUP",
                param: new { ID_PRODUCT_GROUP = id }, commandType: CommandType.Text);
            }
        }
        #endregion

        #region ..:: Products ::..
        public List<Product> GetProducts()
        {
            using (var conn = _dbContext.GetConnection())
            {
                return conn.Query($@"SELECT PDT.[ID_PRODUCT] AS PRODUCT_ID
									, PDT.[DESCRIPTION] AS PRODUCT
									, PDT.[QUANTITY] AS QUANTITY
									, PDT.[ID_PRODUCT_GROUP] AS GROUP_ID
									, PDG.[DESCRIPTION] AS GROUP
									, PDT.[ID_SUPPLIER] AS SUPPLIER_ID
									, SUP.[NAME] AS SUPPLIER
                                     FROM PRODUCT PDT WITH(NOLOCK)
									 INNER JOIN SUPPLIER SUP WITH(NOLOCK) ON SUP.[ID_SUPPLIER] = PDT.[ID_SUPPLIER]
									 INNER JOIN PRODUCT_GROUP PDG WITH(NOLOCK) ON PDG.[ID_PRODUCT_GROUP] = PDT.[ID_PRODUCT_GROUP]
                                     WHERE PDG.[ACTIVE] = 1")
                .Select(x => new Product
                {
                    Id = x.PRODUCT_ID,
                    Description = x.PRODUCT,
                    Quantity = x.QUANTITY,
                    GroupId = x.GROUP_ID,
                    Group = x.GROUP,
                    SupplierId = x.SUPPLIER_ID,
                    Supplier = x.SUPPLIER
                }).ToList();
            }
        }
        public List<Product> GetProduct(int id)
        {
            using (var conn = _dbContext.GetConnection())
            {
                return conn.Query($@"SELECT PDT.[ID_PRODUCT] AS PRODUCT_ID
									, PDT.[DESCRIPTION] AS PRODUCT
									, PDT.[QUANTITY] AS QUANTITY
									, PDT.[ID_PRODUCT_GROUP] AS GROUP_ID
									, PDG.[DESCRIPTION] AS GROUP
									, PDT.[ID_SUPPLIER] AS SUPPLIER_ID
									, SUP.[NAME] AS SUPPLIER
                                     FROM PRODUCT PDT WITH(NOLOCK)
									 INNER JOIN SUPPLIER SUP WITH(NOLOCK) ON SUP.[ID_SUPPLIER] = PDT.[ID_SUPPLIER]
									 INNER JOIN PRODUCT_GROUP PDG WITH(NOLOCK) ON PDG.[ID_PRODUCT_GROUP] = PDT.[ID_PRODUCT_GROUP]
                                     WHERE PDT.[ID_PRODUCT] = @ID_PRODUCT",
                param: new { ID_PRODUCT = id }, commandType: CommandType.Text)
                .Select(x => new Product
                {
                    Id = x.PRODUCT_ID,
                    Description = x.PRODUCT,
                    Quantity = x.QUANTITY,
                    GroupId = x.GROUP_ID,
                    Group = x.GROUP,
                    SupplierId = x.SUPPLIER_ID,
                    Supplier = x.SUPPLIER
                }).ToList();
            }
        }
        public int InsertProduct(Product product)
        {
            using (var conn = _dbContext.GetConnection())
            {
                return conn.QuerySingle<int>($@"INSERT INTO PRODUCT(  [DESCRIPTION]
                                                                    , [QUANTITY]
                                                                    , [ID_PRODUCT_GROUP]
                                                                    , [ID_SUPPLIER])

                                                OUTPUT INSERTED.[ID_PRODUCT]

                                                VALUES(@DESCRIPTION, @QUANTITY, @ID_PRODUCT_GROUP, @ID_SUPPLIER)",
                param: new {  
                              DESCRIPTION = product.Description
                            , QUANTITY = product.Quantity
                            , ID_PRODUCT_GROUP = product.GroupId
                            , ID_SUPPLIER = product.SupplierId
                           }, commandType: CommandType.Text);
            }
        }
        public int UpdateProduct(Product product)
        {
            using (var conn = _dbContext.GetConnection())
            {
                return conn.QuerySingle<int>($@"UPDATE PRODUCT
                                                SET   [DESCRIPTION]      = @DESCRIPTION
                                                    , [QUANTITY]         = @QUANTITY
                                                    , [ID_PRODUCT_GROUP] = @ID_PRODUCT_GROUP
                                                    , [ID_SUPPLIER]      = @ID_SUPPLIER
                                                OUTPUT INSERTED.ID_PRODUCT
                                                WHERE [ID_PRODUCT] = @ID_PRODUCT",
                param: new
                {
                      ID_PRODUCT = product.Id
                    , DESCRIPTION = product.Description
                    , QUANTITY = product.Quantity
                    , ID_PRODUCT_GROUP = product.GroupId
                    , ID_SUPPLIER = product.SupplierId
                }, commandType: CommandType.Text);
            }
        }
        public void DeleteProduct(int id)
        {
            using (var conn = _dbContext.GetConnection())
            {
                conn.Query($@"UPDATE PRODUCT
                              SET [ACTIVE] = 0
                              WHERE [ID_PRODUCT] = @ID_PRODUCT",
                param: new { ID_PRODUCT = id }, commandType: CommandType.Text);
            }
        }
        #endregion

        #region ..:: Products Count::..
        public List<ProductCount> GetProductsCount()
        {
            using (var conn = _dbContext.GetConnection())
            {
                return conn.Query($@"SELECT DISTINCT   CNT.[ID_PRODUCT_COUNT]
                                                     , CNT.[DESCRIPTION]
                                                     , CNT.[QUANTITY]
                                                     , CNT.[ID_PRODUCT] AS  PRODUCT_ID
                                                     , PDT.[DESCRIPTION] AS PRODUCT
                                                     , CNT.[DATE] AS DATE_OF_COUNT
                                     FROM PRODUCT_COUNT CNT WITH(NOLOCK)
									 INNER JOIN PRODUCT PDT WITH(NOLOCK) ON PDT.[ID_PRODUCT] = CNT.[ID_PRODUCT]
									 WHERE PDG.[ACTIVE] = 1")
                .Select(x => new ProductCount
                {
                    Id = x.ID_PRODUCT_COUNT,
                    Description = x.DESCRIPTION,
                    Quantity = x.QUANTITY,
                    ProductId = x.PRODUCT_ID,
                    ProductDescription = x.PRODUCT,
                    DateOfCount = x.DATE_OF_COUNT
                }).ToList();
            }
        }
        public List<ProductCount> GetProductCount(int id)
        {
            using (var conn = _dbContext.GetConnection())
            {
                return conn.Query($@"SELECT DISTINCT   CNT.[ID_PRODUCT_COUNT]
                                                     , CNT.[DESCRIPTION]
                                                     , CNT.[QUANTITY]
                                                     , CNT.[ID_PRODUCT] AS  PRODUCT_ID
                                                     , PDT.[DESCRIPTION] AS PRODUCT
                                                     , CNT.[DATE] AS DATE_OF_COUNT
                                     FROM PRODUCT_COUNT CNT WITH(NOLOCK)
									 INNER JOIN PRODUCT PDT WITH(NOLOCK) ON PDT.[ID_PRODUCT] = CNT.[ID_PRODUCT]
									 WHERE CNT.[ID_PRODUCT_COUNT] = @ID_PRODUCT_COUNT",
                param: new { ID_PRODUCT_COUNT = id }, commandType: CommandType.Text)
                .Select(x => new ProductCount
                {
                    Id = x.ID_PRODUCT_COUNT,
                    Description = x.DESCRIPTION,
                    Quantity = x.QUANTITY,
                    ProductId = x.PRODUCT_ID,
                    ProductDescription = x.PRODUCT,
                    DateOfCount = x.DATE_OF_COUNT
                }).ToList();
            }
        }
        public int InsertProductCount(ProductCount productCount)
        {
            using (var conn = _dbContext.GetConnection())
            {
                return conn.QuerySingle<int>($@"PRC_COUNTING_CREATE @DESCRIPTION, @QUANTITY, @ID_PRODUCT, @DATE",
                param: new
                {
                    DESCRIPTION = productCount.Description
                  , QUANTITY = productCount.Quantity
                  , ID_PRODUCT = productCount.ProductId
                  , DATE = productCount.DateOfCount
                }, commandType: CommandType.Text);
            }
        }

        #endregion
    }
}
