using Microsoft.VisualStudio.TestTools.UnitTesting;
using WingTipApi.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using WingTipApi.DAL.Repository;
using WingTipApi.Common.DTOs;

namespace WingTipApi.Core.Services.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
      //TODO: MORE UNIT TESTINGS COULD BE ADDED FOR DIFFERENT CONDITIONS
      //At here I have used Moq framework for mocking the Repository layer

        [TestMethod()]
        public void UpdateProductInCart_WhenCalled_InsertInCartTable()
        {
            var mockOrderRepository = new Mock<IOrderRepository>();
            var register = new OrderService(mockOrderRepository.Object);

            var insertDto = new ShoppingCartInsertDto();
           var res = register.UpdateProductInCart(insertDto);

            mockOrderRepository.Verify(s => s.UpdateProductInCart(insertDto));
        }

        

        [TestMethod()]
        public void RegisterOrder_WhenCalled_RegisterCart()
        {
            var mockOrderRepository = new Mock<IOrderRepository>();
            var register = new OrderService(mockOrderRepository.Object);

            var insertDto = new OrderInsertDto();
             register.RegisterOrder(insertDto);

            mockOrderRepository.Verify(s => s.RegisterCart(insertDto));
        }
    }
}