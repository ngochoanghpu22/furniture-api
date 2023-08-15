using AutoMapper;
using Furniture.Application.Dtos;
using Furniture.Application.Interfaces;
using Furniture.Application.Models.Common;
using Microsoft.EntityFrameworkCore;
using PCMS.Infrastructure.UoW;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Furniture.Utilities.Enums;

namespace Furniture.Application.Implementation
{
    public class ProductService: IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResult<List<ProductDto>>> GetProducts(int categoryId)
        {
            var products = await _unitOfWork.ProductRepository.FindAll(p => p.CategoryId == categoryId && p.Status == ProductStatus.Active.ToString())
                                                              .Select(p => new ProductDto
                                                              {
                                                                  Id = p.Id,
                                                                  Name = p.Name,
                                                                  ThumbnailImage = p.ThumbnailImage,
                                                                  OriginalImage = p.OriginalImage,
                                                                  Price = p.Price,
                                                                  QuantityInStock = p.QuantityInStock,
                                                                  Description = p.Description
                                                              }).ToListAsync();

            return new ApiSuccessResult<List<ProductDto>>(products);
        }

        public async Task<ApiResult<ProductDto>> GetProductDetail(int productId)
        {
            var products = await _unitOfWork.ProductRepository.FindAll(p => p.Id == productId && p.Status == ProductStatus.Active.ToString())
                                                              .Select(p => new ProductDto
                                                              {
                                                                  Id = p.Id,
                                                                  Name = p.Name,
                                                                  ThumbnailImage = p.ThumbnailImage,
                                                                  OriginalImage = p.OriginalImage,
                                                                  Price = p.Price,
                                                                  QuantityInStock = p.QuantityInStock,
                                                                  Description = p.Description
                                                              }).FirstOrDefaultAsync();

            return new ApiSuccessResult<ProductDto>(products);
        }
    }
}
