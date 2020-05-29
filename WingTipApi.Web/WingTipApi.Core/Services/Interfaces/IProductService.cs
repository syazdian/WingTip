using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WingTipApi.Common;
using WingTipApi.DAL.Entities;

namespace WingTipApi.Core.Services
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllProducts();
        Task<List<Categories>> GetAllCategories();
        Task<ProductDto> GetProduct(int id);
        Task<List<ProductDto>> GetByCategory(int id);
        List<ProductDto> GetBySearch(string q);

        int Add(int a, int b);
    }
}
