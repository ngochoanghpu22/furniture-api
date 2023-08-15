using AutoMapper;
using Furniture.Application.Dtos;
using Furniture.Application.Interfaces;
using Furniture.Application.Models.Claim;
using Furniture.Application.Models.Common;
using Furniture.Data.Entities;
using Furniture.Utilities.Constants;
using Microsoft.EntityFrameworkCore;
using PCMS.Infrastructure.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Furniture.Utilities.Enums;

namespace Furniture.Application.Implementation
{
    public class OrderService: IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResult<bool>> CreateOrder(List<PurchaseOrderDto> dto, ClaimModel claim)
        {
            var validate = await  ValidateOrder(dto);

            if (!validate.IsSuccessed)
            {
                return validate;
            }

            var orderDetailEnties = new List<OrderDetail>();
            foreach (var dtoItem in dto)
            {
                orderDetailEnties.Add(new OrderDetail 
                { 
                    ProductId = dtoItem.ProductId,
                    Quantity = dtoItem.Quantity,
                    CreatedBy = claim.Email
                });
            };

            var oderEntity = new Order()
            {
                UserId = Convert.ToInt32(claim.UserId),
                Status = OrderStatus.Pending.ToString(),
                CreatedBy = claim.Email,
                OrderDetails = orderDetailEnties
            };

            await _unitOfWork.OrderRepository.AddAsync(oderEntity);
            await _unitOfWork.Commit();

            return new ApiSuccessResult<bool>(true);
        }

        public async Task<ApiResult<List<OrderDto>>> GetOrders(ClaimModel claim)
        {
            // User has role is Admin can view all of orders even if order was created by other user
            var userId = Convert.ToInt32(claim.UserId);
            var orders = await _unitOfWork.OrderRepository.FindAll(o => claim.Role == RoleConstants.AdminRoleName || o.UserId == userId)
                                                          .OrderByDescending(o => o.CreatedDate)
                                                          .Select(o => new OrderDto
                                                          {
                                                              Id = o.Id,
                                                              Status = o.Status,
                                                              CreatedBy = o.CreatedBy,
                                                              CreatedDate = o.CreatedDate.ToString(CommonConstants.DateTimeFormat)
                                                          }).ToListAsync();

            return new ApiSuccessResult<List<OrderDto>>(orders);
        }

        public async Task<ApiResult<OrderDetailDto>> GetOrderDetail(int orderId)
        {
            var orderEntity = _unitOfWork.OrderRepository.FindAll(o => o.Id == orderId);
            var orderDetailEntity = _unitOfWork.OrderDetailRepository.FindAll(o => o.OrderId == orderId);
            var userEntity = _unitOfWork.UserRepository.FindAll();
            var productEntity = _unitOfWork.ProductRepository.FindAll();

            var query = (
                          from o in orderEntity
                          join u in userEntity
                          on o.UserId equals u.Id
                          join od in orderDetailEntity
                          on o.Id equals od.OrderId
                          join p in productEntity
                          on od.ProductId equals p.Id
                          select new OrderDetailDto
                          {
                               Id = o.Id,
                               Email = u.Email,
                               Name = u.Name,
                               Phone = u.Phone,
                               Products = new List<ProductDto>()
                               {
                                   new ProductDto
                                   {
                                       Id = p.Id,
                                       Name = p.Name,
                                       Price = p.Price,
                                       ThumbnailImage = p.ThumbnailImage,
                                       QuantityInStock = p.QuantityInStock,
                                       QuantityOrder = od.Quantity
                                   }
                               }
                          }).AsEnumerable();

            var oderDetail = (from o in query
                              group o by o.Id into g
                              let firstGroup = g.FirstOrDefault()
                              select new OrderDetailDto
                              {
                                  Id = g.Key,
                                  Email = firstGroup.Email,
                                  Name = firstGroup.Name,
                                  Phone = firstGroup.Phone,
                                  Products = g.SelectMany(r => r.Products).ToList()
                              }).FirstOrDefault();

            return await Task.Run(() => new ApiSuccessResult<OrderDetailDto>(oderDetail));
        }

        private async Task<ApiResult<bool>> ValidateOrder(List<PurchaseOrderDto> purchaseDto)
        {
            var productIds = purchaseDto.Select(p => p.ProductId).ToList();
            var products = await _unitOfWork.ProductRepository.FindAll(p => productIds.Contains(p.Id) && p.Status == ProductStatus.Active.ToString())
                                                              .Select(p => new ProductDto
                                                              {
                                                                  Id = p.Id,
                                                                  Name = p.Name,
                                                                  QuantityInStock = p.QuantityInStock
                                                              }).ToListAsync();

            foreach (var item in purchaseDto)
            {
                var currentProduct = products.FirstOrDefault(p => p.Id == item.ProductId);
                if (currentProduct != null)
                {
                    if (item.Quantity > currentProduct.QuantityInStock)
                    {
                        var errorMessage = $"Product '{currentProduct.Name}' are not enough quantity due to quantity in stock is: {currentProduct.QuantityInStock}";
                        return new ApiErrorResult<bool>(errorMessage);
                    }
                }
            }

            return new ApiSuccessResult<bool>(true);
        }
    }
}
