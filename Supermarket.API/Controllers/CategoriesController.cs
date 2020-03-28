using System;
using System.Collections.Generic;
using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services;
using Supermarket.API.Resources;
using Supermarket.API.Extensions;

namespace Supermarket.API.Controllers
{
    [Route("/api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryService categoryService, IMapper mapper){
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryResource>> GetAllSync(){
            var categories = await _categoryService.ListAsync();

            var resources = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);
            return resources;
        }

        public async Task<IActionResult> PostAsync([FromBody] SaveCategoryResource resource){
          if(!ModelState.IsValid){
              return BadRequest(ModelState.GetErrorMessages());
          }
        }
    }
}