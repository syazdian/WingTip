using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WingTipApi.Core.Services;



namespace WingTipApi.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        //TODO: Better Exception Handling should be done...
        IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await _productService.GetAllProducts();
            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _productService.GetProduct(id);
            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);

        }

        [HttpGet("Category")]
        public async Task<IActionResult> GetCategories()
        {
            var res = await _productService.GetAllCategories();
            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);

        }

        [HttpGet("GetByCategory/{id}")]
        public async Task<IActionResult> GetByCategory(int id)
        {
            var res = await _productService.GetByCategory(id);
            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);

        }

        [HttpGet("search/{q}")]
        public async Task<IActionResult> GetBySearch(string q)
        {
            var res =  _productService.GetBySearch(q);
            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }

       
    }
}
