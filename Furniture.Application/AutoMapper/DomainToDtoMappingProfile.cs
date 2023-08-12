using AutoMapper;
using Furniture.Application.Dtos;
using Furniture.Data.Entities;

namespace Furniture.Application.AutoMapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<User, UserDto>();                
        }
    }
}
