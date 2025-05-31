using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Interfaces;
using Entity.Context;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Implements.BaseData
{
    public class DbContextFactory : IDbContextFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public DbContextFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ApplicationDbContext CreateMainContext()
        {
            return _serviceProvider.GetRequiredService<ApplicationDbContext>();
        }

        public AuditDbContext CreateAuditContext()
        {
            return _serviceProvider.GetRequiredService<AuditDbContext>();
        }
    }
}
