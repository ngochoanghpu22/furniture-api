using AutoMapper;
using Furniture.Application.Dtos;
using Furniture.Application.Interfaces;
using Furniture.Application.Models.Common;
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
        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResult<List<CategoryDto>>> GetCategories()
        {
            var categories = await _unitOfWork.CategoryRepository.FindAll(c => c.Status == CategoryStatus.Active.ToString())
                                                                 .Select(c => new CategoryDto
                                                                 {
                                                                     Id = c.Id,
                                                                     Name = c.Name,
                                                                     Image = c.Image
                                                                 }).ToListAsync();

            return new ApiSuccessResult<List<CategoryDto>>(categories);
        }
    }
}
