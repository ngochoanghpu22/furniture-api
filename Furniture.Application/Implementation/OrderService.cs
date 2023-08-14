using AutoMapper;
using Furniture.Application.Dtos;
using Furniture.Application.Interfaces;
using Furniture.Application.Models.Claim;
using Furniture.Application.Models.Common;
using Furniture.Data.Entities;

using PCMS.Infrastructure.UoW;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Furniture.Utilities.Enums;

namespace Furniture.Application.Implementation
{
    public class OrderService: IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResult<bool>> CreateOrder(List<PurchaseOrderDto> dto, ClaimModel claim)
        {
            var orderDetailEnties = new List<OrderDetail>();
            foreach (var dtoItem in dto)
            {
                orderDetailEnties.Add(new OrderDetail 
                { 
                    ProductId = dtoItem.ProductId,
                    Quantity = dtoItem.Quantity,
                    CreatedDate = DateTime.UtcNow,
                    CreatedBy = claim.Email
                });
            };

            var oderEntity = new Order()
            {
                UserId = Convert.ToInt32(claim.UserId),
                Status = OrderStatus.Pending.ToString(),
                CreatedDate = DateTime.UtcNow,
                CreatedBy = claim.Email,
                OrderDetails = orderDetailEnties
            };

            await _unitOfWork.OrderRepository.AddAsync(oderEntity);
            await _unitOfWork.Commit();

            return new ApiSuccessResult<bool>(true);
        }
    }
}
