using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WingTipApi.Common.DTOs;
using WingTipApi.DAL.Entities;
using WingTipApi.DAL.Repository;

namespace WingTipApi.Core.Services
{
    //TODO: Better Exception Handling should be done...

    public class OrderService : IOrderService
    {
        IOrderRepository _orderrepository;
        public OrderService(IOrderRepository orderrepository)
        {
            _orderrepository = orderrepository;
        }

        public async Task<bool> UpdateProductInCart(ShoppingCartInsertDto shoppingCartInsertDto)
        {
            try
            {
                return await _orderrepository.UpdateProductInCart(shoppingCartInsertDto);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<ShoppingCartProductRow>> GetShoppingCart(string CartId)
        {
            try
            {
                return await _orderrepository.GetShoppingCart(CartId);
              

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> RegisterOrder(OrderInsertDto regOrder)
        {
            try
            {
                return await _orderrepository.RegisterCart(regOrder);


            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
