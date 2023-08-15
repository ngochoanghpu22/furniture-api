using Furniture.Application.Dtos;
using Furniture.Application.Models.Claim;
using Furniture.Application.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furniture.Application.Interfaces
{
    public interface IOrderService
    {
        Task<ApiResult<bool>> CreateOrder(List<PurchaseOrderDto> dto, ClaimModel claim);

        Task<ApiResult<List<OrderDto>>> GetOrders(ClaimModel claim);

        Task<ApiResult<OrderDetailDto>> GetOrderDetail(int orderId);
    }
}
