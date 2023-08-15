using Furniture.Api.Authorization;
using Furniture.Application.Dtos;
using Furniture.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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

            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetOrders()
        {
            var userId = Convert.ToInt32(FurnitureAuthenticationHandler.GetCurrentUser(_httpContextAccessor).UserId);

            var orders = await _orderService.GetOrders(userId);

            return Ok(orders);
        }

        [HttpGet]
        [Route("detail")]
        public async Task<IActionResult> GetDetail(int orderId)
        {
            var orderDetail = await _orderService.GetOrderDetail(orderId);

            return Ok(orderDetail);
        }

    }
}