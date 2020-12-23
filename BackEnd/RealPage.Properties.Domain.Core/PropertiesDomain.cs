using System;
using RealPage.Properties.Domain.Entity;
using RealPage.Properties.Domain.Interface;
using RealPage.Properties.Infrastructure.Interface;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace RealPage.Properties.Domain.Core
{
    public class PropertiesDomain : IPropertiesDomain
    {
        private readonly IPropertiesRepository _propertiesRepository;
        public PropertiesDomain(IPropertiesRepository propertiesRepository)
        {
            _propertiesRepository = propertiesRepository;
        }

        public async Task<bool> Add(Property property)
        {
            try
            {
                await _propertiesRepository.AddAsync(property);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Update(Property property)
        {
            try
            {
                await _propertiesRepository.UpdateAsync(property);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int propertyId)
        {
            try
            {
                var prop = _propertiesRepository.GetByIdAsync(propertyId);
                await _propertiesRepository.DeleteAsync(prop.Result);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Property> Get(int propertyId)
        {
            return await _propertiesRepository.GetByIdAsync(propertyId);
        }

        public async Task<IEnumerable<Property>> GetAll()
        {
            return await _propertiesRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Property>> GetByState(string state)
        {
            return await _propertiesRepository.GetByState(state);
        }
    }
}
