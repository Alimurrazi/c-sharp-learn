using System;
using System.Collections.Generic;
using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services;
using Supermarket.API.Resources;
using Supermarket.API.Extensions;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using AngleSharp.Text;

namespace Supermarket.API.Controllers
{
    [Route("/api")]
    public class SupserShopController : Controller
    {

        readonly ISuperShopService _superShopService;
        public SupserShopController(ISuperShopService superShopService){
            _superShopService = superShopService;
        }

        [HttpGet("supershop/{SuperShopId}/category/{CategoryId}")]
        public async Task<IHtmlDocument> ScrapCategory(int SuperShopId, int CategoryId){

            // _superShopService.ScrapeItems(SuperShopId, CategoryId);
            var element = await _superShopService.ScrapeItems(SuperShopId, CategoryId);
          //  return Ok(element);
            return element;
        }      
    }
}