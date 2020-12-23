using RealPage.Properties.Domain.Entity;
using RealPage.Properties.Infrastructure.Interface.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealPage.Properties.Infrastructure.Interface
{
    public interface IPropertiesRepository : IRepository<Property>
    {
        Task<List<Property>> GetByState(string state);
    }
}
