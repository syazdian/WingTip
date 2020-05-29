using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WingTipApi.Common.DTOs;
using WingTipApi.DAL.Entities;

namespace WingTipApi.DAL.Repository
{
   public interface IOrderRepository
    {
        #region PUT METHODS
        Task<bool> UpdateProductInCart(ShoppingCartInsertDto product); // UPDATE/Insert product to shopping cart
        Task<bool> RegisterCart(OrderInsertDto order); 
        #endregion

        Task<List<ShoppingCartProductRow>> GetShoppingCart(string CartID);




    }
}
