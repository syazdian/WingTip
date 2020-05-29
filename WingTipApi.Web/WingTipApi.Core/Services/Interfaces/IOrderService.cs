using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WingTipApi.Common;
using WingTipApi.Common.DTOs;

namespace WingTipApi.Core.Services
{
    public interface IOrderService
    {
        Task<bool> UpdateProductInCart(ShoppingCartInsertDto shoppingCartInsertDto);
        Task<List<ShoppingCartProductRow>> GetShoppingCart(string CartId);
        Task<bool> RegisterOrder(OrderInsertDto regOrder);



    }
}
