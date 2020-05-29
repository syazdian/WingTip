using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WingTipApi.Common;
using WingTipApi.DAL.Entities;
using System.Data.SqlClient;

namespace WingTipApi.DAL.Repository
{
    //TODO: Better Exception Handling should be done...

    public class ProductRepository : IProductsRepository
    {
        private readonly string _conString;

        public ProductRepository(string conString)
        {
            _conString = conString;

        }
        public async Task<List<Categories>> GetAllCategories()
        {
            try
            {
                var sql = "select * From [Categories]";
                using (var connection = new SqlConnection(_conString))
                {
                    connection.Open();
                    var res = await connection.QueryAsync<Categories>(sql);
                    return res.ToList();
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<List<ProductDto>> GetAllProducts()
        {
            try
            {
                var sql = "select [ProductID] ,[ProductName],Products.Description,[ImagePath],[UnitPrice], Categories.CategoryName AS Category " +
                    " From Products INNER JOIN Categories ON Categories.CategoryID = Products.CategoryID";
                using (var connection = new SqlConnection(_conString))
                {
                    connection.Open();
                    var res = await connection.QueryAsync<ProductDto>(sql);
                    return res.ToList();
                }
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public async Task<ProductDto> GetProductById(int ProductId)
        {
            try
            {
                var sql = "select [ProductID] ,[ProductName],Products.Description,[ImagePath],[UnitPrice], Categories.CategoryName AS Category " +
                    " From Products INNER JOIN Categories ON Categories.CategoryID = Products.CategoryID"
                +"  where Products.ProductID =  @Id;";

                using (var connection = new SqlConnection(_conString))
                {
                    connection.Open();
                    var res = await connection.QueryAsync<ProductDto>(sql, new { Id = ProductId });
                    return res.FirstOrDefault();
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<List<ProductDto>> GetProductsByCategory(int CatId)
        {
            try
            {
                var sql = "select [ProductID] ,[ProductName],Products.Description,[ImagePath],[UnitPrice], Categories.CategoryName AS Category " +
                    " From Products INNER JOIN Categories ON Categories.CategoryID = Products.CategoryID"
                + "  where Categories.CategoryID =  @Id;";

                using (var connection = new SqlConnection(_conString))
                {
                    connection.Open();
                    var res = await connection.QueryAsync<ProductDto>(sql, new { Id = CatId });
                    return res.ToList();
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
