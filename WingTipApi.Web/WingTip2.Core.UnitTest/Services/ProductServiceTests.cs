using Microsoft.VisualStudio.TestTools.UnitTesting;
using WingTipApi.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using WingTipApi.DAL.Repository;
using WingTipApi.Common;
using System.Threading.Tasks;

namespace WingTipApi.Core.Services.Tests
{
    [TestClass()]
    public class ProductServiceTests
    {
        //TODO: MORE UNIT TESTINGS COULD BE ADDED FOR DIFFERENT CONDITIONS
        [DataRow("")]
        [DataRow(null)]
        [DataRow(" ")]
        [DataRow("A")]
        [TestMethod()]
        public void GetBySearchTest(string q)
        {
            var mockProductRepository = new Mock<IProductsRepository>();
            var product = new ProductService(mockProductRepository.Object);
            Assert.ThrowsException<Exception>(() => product.GetBySearch(q));
        }


    }
}