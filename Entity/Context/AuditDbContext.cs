using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace Entity.Context
{
    
        public class AuditDbContext : DbContext
        {
            public AuditDbContext(DbContextOptions<AuditDbContext> options) : base(options) { }
            public DbSet<ChangeLog> ChangeLogs { get; set; }
        }
    
}
