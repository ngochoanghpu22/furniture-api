using Furniture.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Furniture.Api.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        
        [HttpGet]
        [Route("get-by-categoryId")]
        public async Task<IActionResult> GetProducts(int categoryId)
        {
            var categories = await _productService.GetProducts(categoryId);

            return Ok(categories);
        }

        [HttpGet]
        [Route("get-by-id")]
        public async Task<IActionResult> GetProductDetail(int productId)
        {
            var categories = await _productService.GetProductDetail(productId);

            return Ok(categories);
        }

    }
}