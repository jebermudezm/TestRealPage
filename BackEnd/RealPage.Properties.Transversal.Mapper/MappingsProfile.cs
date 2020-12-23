using System;
using AutoMapper;
using RealPage.Properties.Domain.Entity;
using RealPage.Properties.Application.DTO;

namespace RealPage.Properties.Transversal.Mapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<Property, PropertyDto>().ReverseMap();
            CreateMap<User, UsersDto>().ReverseMap();
        }
    }
}
