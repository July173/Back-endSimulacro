﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Context;

namespace Data.Interfaces
{
    public interface IDbContextFactory
    {
        ApplicationDbContext CreateMainContext();
        AuditDbContext CreateAuditContext();
    }
}
