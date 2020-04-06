using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Supermarket.API.Resources;
using Supermarket.API.Domain.Services;
using Supermarket.API.Services;
namespace Supermarket.API.Controllers
{
    [Route("/api/[controller]")]
    public class AddToCartController : Controller
    {
        private readonly IAddToCartService _addToCartService;
        public AddToCartController(IAddToCartService addToCartService){
            this._addToCartService = addToCartService;
        }

        [HttpPost]
        public async Task<IActionResult> CartProductAsync([FromBody] AddToCartResource[] resource){
            var price = await _addToCartService.CalculateProductPrice(resource);
            return Ok(price);
        }
    }

}