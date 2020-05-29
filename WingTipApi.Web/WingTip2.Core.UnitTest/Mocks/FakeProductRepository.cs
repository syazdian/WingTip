using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WingTipApi.Common;
using WingTipApi.DAL.Entities;
using WingTipApi.DAL.Repository;

namespace WingTip2.Core.UnitTest.Mocks
{
    class FakeProductRepository : IProductsRepository
    {
        public Task<List<Categories>> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDto>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> GetProductById(int ProductId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDto>> GetProductsByCategory(int CatId)
        {
            throw new NotImplementedException();
        }
    }
}
