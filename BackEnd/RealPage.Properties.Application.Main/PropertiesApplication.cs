using System;
using AutoMapper;
using RealPage.Properties.Application.DTO;
using RealPage.Properties.Application.Interface;
using RealPage.Properties.Domain.Entity;
using RealPage.Properties.Domain.Interface;
using RealPage.Properties.Transversal.Common;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace RealPage.Properties.Application.Main
{
    public class PropertiesApplication : IPropertiesApplication
    {
        private readonly IPropertiesDomain _propertiesDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<PropertiesApplication> _logger;
        public PropertiesApplication(IPropertiesDomain propertiesDomain, IMapper mapper, IAppLogger<PropertiesApplication> logger)
        {
            _propertiesDomain = propertiesDomain;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<bool>> Add(PropertyDto propertyDto)
        {
            var response = new Response<bool>();
            try
            {
                var property = _mapper.Map<Property>(propertyDto);
                response.Data = await _propertiesDomain.Add(property);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful registration!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<bool>> Update(PropertyDto propertyDto)
        {
            var response = new Response<bool>();
            try
            {
                var property = _mapper.Map<Property>(propertyDto);
                response.Data = await _propertiesDomain.Update(property);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful update!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<bool>> Delete(int propertyId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _propertiesDomain.Delete(propertyId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful removal!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<PropertyDto>> Get(int propertyId)
        {
            var response = new Response<PropertyDto>();
            try
            {
                var property = await _propertiesDomain.Get(propertyId);
                response.Data = _mapper.Map<PropertyDto>(property);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful consultation!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<IEnumerable<PropertyDto>>> GetAll()
        {
            var response = new Response<IEnumerable<PropertyDto>>();
            try
            {
                var property = await _propertiesDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<PropertyDto>>(property);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful consultation!!!";
                    _logger.LogInformation("Successful consultation!!!");
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError(e.Message);
            }
            return response;
        }

        public async Task<Response<IEnumerable<PropertyDto>>> GetByState(string state)
        {
            var response = new Response<IEnumerable<PropertyDto>>();
            try
            {
                var property = await _propertiesDomain.GetByState(state);
                response.Data = _mapper.Map<IEnumerable<PropertyDto>>(property);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful consultation!!!";
                    _logger.LogInformation("Successful consultation!!!");
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError(e.Message);
            }
            return response;
        }

    }
}
