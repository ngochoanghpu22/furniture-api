using Furniture.Api.Authorization;
using Furniture.Application.Dtos;
using Furniture.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furniture.Api.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService,
                              IHttpContextAccessor httpContextAccessor)
        {
            _orderService = orderService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateOrder(List<PurchaseOrderDto> dto)
        {
            var claim = FurnitureAuthenticationHandler.GetCurrentUser(_httpContextAccessor);

            var result = await _orderService.CreateOrder(dto, claim);

            return Ok(result);
        }

    }
}