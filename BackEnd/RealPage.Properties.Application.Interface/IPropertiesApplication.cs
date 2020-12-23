using RealPage.Properties.Application.DTO;
using RealPage.Properties.Transversal.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealPage.Properties.Application.Interface
{
    public interface IPropertiesApplication
    {     
        Task<Response<bool>> Add(PropertyDto propertyDto);
        Task<Response<bool>> Update(PropertyDto propertyDto);
        Task<Response<bool>> Delete(int propertyId);
        Task<Response<PropertyDto>> Get(int propertyId);
        Task<Response<IEnumerable<PropertyDto>>> GetAll();
        Task<Response<IEnumerable<PropertyDto>>> GetByState(string state);
    }
}
