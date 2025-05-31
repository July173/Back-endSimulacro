using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Context;
using Entity.Model;

namespace Business.Implements
{
    public class AuditBusiness
    {
        private readonly AuditDbContext _auditDb;

        public AuditBusiness(AuditDbContext auditDb)
        {
            _auditDb = auditDb;
        }

        public async Task RegistrarCambioAsync(string usuario, string accion, string detalles)
        {
            var log = new ChangeLog
            {
                UserName = usuario,
                Action = accion,
                NewValues = detalles,
                CreateAt = DateTime.UtcNow,
                Active = "true"
            };

            _auditDb.ChangeLogs.Add(log);
            await _auditDb.SaveChangesAsync();
        }
    }

}
