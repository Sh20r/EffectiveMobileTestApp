using EffectiveMobileTestApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EffectiveMobileTestApp
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<DeliveryOrder> DeliveryOrders { get; set; }
        public DbSet<LogEntrys> Logs { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) 
            : base(options) { }
    }
}
