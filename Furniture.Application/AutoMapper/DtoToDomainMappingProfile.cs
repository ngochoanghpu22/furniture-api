using AutoMapper;
using Furniture.Application.Dtos;
using Furniture.Application.Models.User;
using Furniture.Data.Entities;

namespace Furniture.Application.AutoMapper
{
    public class DtoToDomainMappingProfile : Profile
    {
        public DtoToDomainMappingProfile()
        {
            CreateMap<RegisterRequest, User>();
        }
    }
}
