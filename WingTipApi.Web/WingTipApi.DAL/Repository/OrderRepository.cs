using Dapper;
using System.Transactions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WingTipApi.Common.DTOs;
using WingTipApi.DAL.Entities;

namespace WingTipApi.DAL.Repository
{
    //TODO: Better Exception Handling should be done...

    public class OrderRepository : IOrderRepository
    {
        private readonly string _conString;

        public OrderRepository(string conString)
        {
            _conString = conString;
        }

        public async Task<List<ShoppingCartProductRow>> GetShoppingCart(string CartID)
        {
            try
            {
                var sql = $"SELECT CartItems.ProductId,Products.ProductName, [Quantity] , Products.UnitPrice AS UnitPrice " +
                             $" FROM CartItems INNER JOIN Products ON Products.ProductID = CartItems.ProductId where cartid = @cartId";

                using (var connection = new SqlConnection(_conString))
                {
                    connection.Open();
                    var res = await connection.QueryAsync<ShoppingCartProductRow>(sql, new { cartId = CartID });
                    return res.ToList();
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<bool> UpdateProductInCart(ShoppingCartInsertDto product)
        {
            try
            {
                using (var connection = new SqlConnection(_conString))
                {
                    var sql = $"SELECT * FROM CartItems WHERE CartItems.CartId = '{product.CartId}' AND CartItems.ProductId = {product.ProductId};";
                    connection.Open();
                    List<CartItems> item = connection.QueryAsync<CartItems>(sql).Result.ToList();
                    if (item == null || item.Count == 0)
                    {
                        Guid obj = Guid.NewGuid();

                        sql = "INSERT INTO CartItems (ItemId, CartId, Quantity, DateCreated, ProductId) VALUES (@ItemId, @CartId, @Quantity, @DateCreated, @ProductId);";
                        var affectedRows = await connection.ExecuteAsync(sql, new
                        {
                            ItemId = obj.ToString(),
                            CartId = product.CartId,
                            Quantity = 1,
                            DateCreated = DateTime.Now,
                            ProductId = product.ProductId
                        });
                        return affectedRows > 0 ? true : false;
                    }
                    else
                    {
                        sql = "UPDATE CartItems SET  Quantity = @Quantity WHERE ItemId = @ItemId;";
                        var count = item.FirstOrDefault().Quantity + 1;
                        var affectedRows = await connection.ExecuteAsync(sql, new
                        {
                            Quantity = count,
                            ItemId = item.FirstOrDefault().ItemId
                        });
                        return affectedRows > 0 ? true : false;
                    }


                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }


        public async Task<bool> RegisterCart(OrderInsertDto order)
        {
            //TODO: LENGTH OF PARAMETERS SHOULD BE CHECKED
            try
            {
                #region GET CURRENT SHOPPING CART
                var currentCart = GetShoppingCart(order.CartId).Result;
                decimal totalCost = 0;
                foreach (var item in currentCart)
                {
                    totalCost += item.Quantity * item.UnitPrice;
                }
                #endregion


                using (var connection = new SqlConnection(_conString))
                {

                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            #region INSTER IN ORDERS TABLE
                            var sql = "INSERT INTO [Orders] ([OrderDate],[Username],[FirstName],[LastName],[Address],[City],[State],[PostalCode] " +
                             ",[Country] ,[Phone] ,[Email],[Total],[HasBeenShipped]) " +
                             $" VALUES ('{DateTime.Now}' , '{order.Username}' , '{order.FirstName}' , '{order.LastName}' , '{order.Address}' , '{order.City}' " +
                             $" , '{order.State}' , '{order.PostalCode}' , '{order.Country}' , '{order.Phone}' , '{order.Email}', '{totalCost}', 'false') " +
                             " SELECT CAST(SCOPE_IDENTITY() as int);";
                            var OrderId = connection.QuerySingleOrDefault<int>(sql, transaction: transaction);
                            #endregion

                            #region INSERT IN ORDER DETAILS
                            string firstPartInsert = "INSERT INTO [OrderDetails]([OrderId],[Username] ,[ProductId] ,[Quantity],[UnitPrice])  VALUES";
                            StringBuilder sqlInsert = new StringBuilder(firstPartInsert);
                            foreach (var itemInCart in currentCart)
                            {
                                sqlInsert.Append($"('{OrderId}' , '{order.Username}' , '{itemInCart.ProductId}' , '{itemInCart.Quantity}' , '{itemInCart.UnitPrice}') ,");
                            }

                            sqlInsert.Length--;
                            connection.QuerySingleOrDefault<int>(sqlInsert.ToString(), transaction: transaction);
                            #endregion

                            transaction.Commit();
                        }
                        catch (Exception e)
                        {
                            transaction.Rollback();
                            throw e;
                        }


                    }
                }
                return true;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
