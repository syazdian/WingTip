using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WingTipApi.Common;
using WingTipApi.DAL.Entities;

namespace WingTipApi.DAL.Repository
{
    public interface IProductsRepository
    {
        #region GET METHODS
        Task<List<ProductDto>> GetAllProducts();//RETURNS ALL THE Products
        Task<List<ProductDto>> GetProductsByCategory(int CatId);
        Task<ProductDto> GetProductById(int ProductId);
        Task<List<Categories>> GetAllCategories();
        #endregion

    }
}
