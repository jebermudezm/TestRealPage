﻿using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using RealPage.Properties.Transversal.Mapper;

namespace RealPage.Properties.Services.WebApi.Modules.Mapper
{
    public static class MapperExtensions
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingsProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            
            return services;
        }
    }
}
