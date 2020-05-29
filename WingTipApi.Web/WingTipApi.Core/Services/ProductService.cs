using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WingTipApi.Common;
using WingTipApi.DAL.Entities;
using WingTipApi.DAL.Repository;

namespace WingTipApi.Core.Services
{
   public class ProductService : IProductService
    {
        //TODO: Better Exception Handling should be done...
        IProductsRepository _productRepository;
        public ProductService(IProductsRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductDto>> GetAllProducts()
        {

            try
            {
                return await _productRepository.GetAllProducts();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<List<ProductDto>> GetByCategory(int id)
        {
            try
            {
                return await _productRepository.GetProductsByCategory(id);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public List<ProductDto> GetBySearch(string q)
        {
            try
            {
                if (string.IsNullOrEmpty(q) || q.Length <= 2)
                {
                    throw new Exception("Search phrase should be more than 2 characters.");
                }
                List<ProductDto> prodList = _productRepository.GetAllProducts().Result;

                List<ProductDto> res = prodList.FindAll(x =>
               (x.ProductName.ToLower().Contains(q.ToLower())
               || x.Description.ToLower().Contains(q.ToLower())));

                return res;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<ProductDto> GetProduct(int id)
        {
            try
            {
                return await _productRepository.GetProductById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public async Task<List<Categories>> GetAllCategories()
        {
            try
            {
                return await _productRepository.GetAllCategories();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int Add(int a, int b)
        {
            return a + b;
        }
       
    }
}
