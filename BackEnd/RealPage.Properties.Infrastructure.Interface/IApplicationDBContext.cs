using Microsoft.EntityFrameworkCore;
using RealPage.Properties.Domain.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace RealPage.Properties.Infrastructure.Interface
{
    public interface IApplicationDBContext
    {
        DbSet<Property> Properties { get; set; }
        DbSet<User> Users { get; set; }

    }
}
