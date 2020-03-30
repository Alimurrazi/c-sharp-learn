using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Supermarket.API.Resources;

namespace Supermarket.API.Controllers
{
    [Route("/api/[controller]")]
    public class AddToCartController : Controller
    {
        public AddToCartController(){

        }

        [HttpPost]
        public async Task<IActionResult> CartProductAsync([FromBody] AddToCartResource[] resource){
            return Ok(resource);
        }
    }

}