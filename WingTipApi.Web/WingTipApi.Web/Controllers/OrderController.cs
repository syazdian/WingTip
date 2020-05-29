using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WingTipApi.Common.DTOs;
using WingTipApi.Core.Services;



namespace WingTipApi.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        //TODO: Better Exception Handling should be done...
        IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{cartId}")]
        public async Task<IActionResult> Get(string cartId)
        {
            var res = await _orderService.GetShoppingCart(cartId);
            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }

        [HttpPost("product")]
        public async Task<IActionResult> Post( ShoppingCartInsertDto cartInsertDto)
        {

           var res = await _orderService.UpdateProductInCart(cartInsertDto);
            if (res == false)
            {
                return Problem();
            }

            return Ok(res);
        }

        [HttpPost("register")]
        public async Task<IActionResult> PostRegister(OrderInsertDto cartInsertDto)
        {

            var res = await _orderService.RegisterOrder(cartInsertDto);

            if (res == false)
            {
                return Problem();
            }

            return Ok(res);
        }

     
    }
}
