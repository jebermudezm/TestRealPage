using RealPage.Properties.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealPage.Properties.Domain.Interface
{
    public interface IPropertiesDomain
    {
        Task<bool> Add(Property property);
        Task<bool> Update(Property property);
        Task<bool> Delete(int propertyId);
        Task<Property> Get(int propertyId);
        Task<IEnumerable<Property>> GetAll();
        Task<IEnumerable<Property>> GetByState(string state);
    }
}
