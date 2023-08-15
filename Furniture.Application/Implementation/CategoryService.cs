using AutoMapper;
using Furniture.Application.Dtos;
using Furniture.Application.Interfaces;
using Furniture.Application.Models.Common;
using Furniture.Utilities.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PCMS.Infrastructure.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Furniture.Utilities.Enums;

namespace Furniture.Application.Implementation
{
    public class CategoryService: ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private ICacheService _cacheService { get; }

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, ICacheService cacheService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cacheService = cacheService;
        }

        public async Task<ApiResult<List<CategoryDto>>> GetCategories()
        {
            var categories = _cacheService.GetCache<List<CategoryDto>>(CommonConstants.CategoryCacheKey);
            if (categories == null || !categories.Any())
            {
                categories = await _unitOfWork.CategoryRepository.FindAll(c => c.Status == CategoryStatus.Active.ToString())
                                                                 .Select(c => new CategoryDto
                                                                 {
                                                                     Id = c.Id,
                                                                     Name = c.Name,
                                                                     Image = c.Image
                                                                 }).ToListAsync();

                _cacheService.AddCache(CommonConstants.CategoryCacheKey, categories);
            }

            return new ApiSuccessResult<List<CategoryDto>>(categories);
        }
    }
}
