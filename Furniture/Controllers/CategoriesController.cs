using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Furniture.Application.Interfaces;

namespace Furniture.Api.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryService.GetCategories();

            return Ok(categories);
        }

    }
}