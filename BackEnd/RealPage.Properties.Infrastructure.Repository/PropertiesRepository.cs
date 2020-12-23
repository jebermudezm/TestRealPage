using Microsoft.EntityFrameworkCore;
using RealPage.Properties.Domain.Entity;
using RealPage.Properties.Infrastructure.Interface;
using RealPage.Properties.Infrastructure.Interface.Base;
using RealPage.Properties.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RealPage.Properties.Infrastructure.Repository
{
    public class PropertiesRepository : Repository<Property>, IPropertiesRepository
    {
               
        public PropertiesRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Property>> GetByState(string state)
        {
            return await _dbContext.Properties.Where(p => p.State == state).ToListAsync();
        }
    }
}
