﻿using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

using Entity.Model;
using Entity.Model.Base;

using System.Data;
using Dapper;

using System.Linq.Expressions;


namespace Entity.Context
{
    public class ApplicationDbContext : DbContext
    {

        protected readonly IConfiguration _configuration;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        //Dbset SETS
        public DbSet<User> Users { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<RolUser> RolUsers { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<FormModule> FormModules { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolFormPermission> RolFormPermissions { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Neighborhood> Neighborhoods { get; set; }
        public DbSet<Provider> Providers { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la relación muchos-a-muchos
            modelBuilder.Entity<RolUser>()
                .HasKey(ru => new { ru.UserId, ru.RolId }); // Clave compuesta

            modelBuilder.Entity<RolUser>()
                .HasOne(ru => ru.User)
                .WithMany(u => u.RolUsers)
                .HasForeignKey(ru => ru.UserId);

            modelBuilder.Entity<RolUser>()
                .HasOne(ru => ru.Rol)
                .WithMany(r => r.RolUsers)
                .HasForeignKey(ru => ru.RolId);

            // Relación uno-a-muchos: Country-Department
            modelBuilder.Entity<Department>()
                .HasOne(d => d.Country)
                .WithMany(c => c.Departments)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación uno-a-muchos: Department-City
            modelBuilder.Entity<City>()
                .HasOne(c => c.Department)
                .WithMany(d => d.Cities)
                .HasForeignKey(c => c.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación uno-a-muchos: City-Neighborhood
            modelBuilder.Entity<Neighborhood>()
                .HasOne(n => n.City)
                .WithMany(c => c.Neighborhoods)
                .HasForeignKey(n => n.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            
            // Relación uno-a-uno: User-Person
            modelBuilder.Entity<User>()
                .HasOne(u => u.Person)
                .WithOne(p => p.User)
                .HasForeignKey<User>(u => u.PersonId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación uno-a-uno: User-Employee
            modelBuilder.Entity<User>()
                .HasOne(u => u.Employee)
                .WithOne(e => e.User)
                .HasForeignKey<Employee>(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación uno-a-uno: User-Provider
            modelBuilder.Entity<User>()
                .HasOne(u => u.Provider)
                .WithOne(p => p.User)
                .HasForeignKey<Provider>(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación uno-a-muchos: User-Neighborhood
            modelBuilder.Entity<User>()
                .HasOne(u => u.Neighborhood)
                .WithMany()
                .HasForeignKey(u => u.NeighborhoodId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación uno-a-muchos: Form-FormModule
            modelBuilder.Entity<FormModule>()
                .HasOne(fm => fm.Form)
                .WithMany(f => f.FormModule)
                .HasForeignKey(fm => fm.FormId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación uno-a-muchos: Module-FormModule
            modelBuilder.Entity<FormModule>()
                .HasOne(fm => fm.Module)
                .WithMany(m => m.FormModule)
                .HasForeignKey(fm => fm.ModuleId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación uno-a-muchos: Permission-RolFormPermission
            modelBuilder.Entity<RolFormPermission>()
                .HasOne(rfp => rfp.Permission)
                .WithMany()
                .HasForeignKey(rfp => rfp.PermissionId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación uno-a-muchos: Rol-RolFormPermission
            modelBuilder.Entity<RolFormPermission>()
                .HasOne(rfp => rfp.Rol)
                .WithMany()
                .HasForeignKey(rfp => rfp.RolId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación uno-a-muchos: Form-RolFormPermission
            modelBuilder.Entity<RolFormPermission>()
                .HasOne(rfp => rfp.Form)
                .WithMany()
                .HasForeignKey(rfp => rfp.FormId)
                .OnDelete(DeleteBehavior.Restrict);



            // Configuración para todas las entidades que heredan de BaseEntity
            foreach (var entityType in modelBuilder.Model.GetEntityTypes()
                .Where(t => t.ClrType.IsSubclassOf(typeof(BaseModel))))
            {
              
                    
                modelBuilder.Entity(entityType.ClrType)
                    .Property("DeleteAt")
                    .IsRequired(false);
                    
                
            }

            // Configuración para entidades que heredan de GenericModel
            foreach (var entityType in modelBuilder.Model.GetEntityTypes()
                .Where(t => t.ClrType != null && t.ClrType.IsSubclassOf(typeof(GenericModel))))
            {
                modelBuilder.Entity(entityType.ClrType)
                    .Property("Name")
                    .IsRequired()
                    .HasMaxLength(100);

                modelBuilder.Entity(entityType.ClrType)
                    .Property("Description")
                    .HasMaxLength(500);
            }
        }

        
        /// <summary>
        /// Configura opciones adicionales del contexto, como el registro de datos sensibles.
        /// </summary>
        /// <param name="optionsBuilder">Constructor de opciones de configuración del contexto.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            // Otras configuraciones adicionales pueden ir aquí
        }

        /// <summary>
        /// Configura convenciones de tipos de datos, estableciendo la precisión por defecto de los valores decimales.
        /// </summary>
        /// <param name="configurationBuilder">Constructor de configuración de modelos.</param>
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<decimal>().HavePrecision(18, 2);
        }

        /// <summary>
        /// Guarda los cambios en la base de datos, asegurando la auditoría antes de persistir los datos.
        /// </summary>
        /// <returns>Número de filas afectadas.</returns>
        public override int SaveChanges()
        {
            EnsureAudit();
            return base.SaveChanges();
        }

        /// <summary>
        /// Guarda los cambios en la base de datos de manera asíncrona, asegurando la auditoría antes de la persistencia.
        /// </summary>
        /// <param name="acceptAllChangesOnSuccess">Indica si se deben aceptar todos los cambios en caso de éxito.</param>
        /// <param name="cancellationToken">Token de cancelación para abortar la operación.</param>
        /// <returns>Número de filas afectadas de forma asíncrona.</returns>
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            EnsureAudit();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        /// <summary>
        /// Ejecuta una consulta SQL utilizando Dapper y devuelve una colección de resultados de tipo genérico.
        /// </summary>
        /// <typeparam name="T">Tipo de los datos de retorno.</typeparam>
        /// <param name="text">Consulta SQL a ejecutar.</param>
        /// <param name="parameters">Parámetros opcionales de la consulta.</param>
        /// <param name="timeout">Tiempo de espera opcional para la consulta.</param>
        /// <param name="type">Tipo opcional de comando SQL.</param>
        /// <returns>Una colección de objetos del tipo especificado.</returns>
        public async Task<IEnumerable<T>> QueryAsync<T>(string text, object? parameters = null, int? timeout = null, CommandType? type = null)
        {
           using var command = new DapperEFCoreCommand(this, text, parameters ?? new { }, timeout, type, CancellationToken.None);
           var connection = this.Database.GetDbConnection();
           return await connection.QueryAsync<T>(command.Definition);
        }

        /// <summary>
        /// Ejecuta una consulta SQL utilizando Dapper y devuelve un solo resultado o el valor predeterminado si no hay resultados.
        /// </summary>
        /// <typeparam name="T">Tipo de los datos de retorno.</typeparam>
        /// <param name="text">Consulta SQL a ejecutar.</param>
        /// <param name="parameters">Parámetros opcionales de la consulta.</param>
        /// <param name="timeout">Tiempo de espera opcional para la consulta.</param>
        /// <param name="type">Tipo opcional de comando SQL.</param>
        /// <returns>Un objeto del tipo especificado o su valor predeterminado.</returns>
        public async Task<T?> QueryFirstOrDefaultAsync<T>(string text, object? parameters = null, int? timeout = null, CommandType? type = null)
        {
           using var command = new DapperEFCoreCommand(this, text, parameters ?? new { }, timeout, type, CancellationToken.None);
           var connection = this.Database.GetDbConnection();
           return await connection.QueryFirstOrDefaultAsync<T>(command.Definition);
        }        
        
        /// <summary>
        /// Obtiene un IQueryable para usar en consultas LINQ que incluye filtro de status activo.
        /// </summary>
        /// <typeparam name="T">Tipo de entidad para la consulta.</typeparam>
        /// <returns>IQueryable filtrado para estrategias LINQ.</returns>
        public IQueryable<T> GetActiveSet<T>() where T : class
        {
            var query = Set<T>().AsQueryable();
            
            // Filtramos por Status aplicando expresiones genéricas si la entidad tiene la propiedad Status
            var parameter = Expression.Parameter(typeof(T), "e");
            
            if (typeof(T).GetProperty("Status") != null)
            {
                try {
                    // Construimos una expresión lambda para filtrar por Status = true
                    var property = Expression.Property(parameter, "Status");
                    var value = Expression.Constant(true);
                    var equal = Expression.Equal(property, value);
                    var lambda = Expression.Lambda<Func<T, bool>>(equal, parameter);
                    
                    // Aplicamos el filtro
                    query = query.Where(lambda);
                }
                catch {
                    // Si hay algún error, devolvemos el query sin filtrar
                }
            }
            
            return query;
        }
        /// <summary>
        /// Método auxiliar para obtener el valor de una propiedad de un objeto mediante reflexión.
        /// </summary>
        /// <param name="obj">Objeto del que se obtendrá el valor.</param>
        /// <param name="propertyName">Nombre de la propiedad.</param>
        /// <returns>Valor de la propiedad.</returns>
        private static bool GetPropertyValue(object obj, string propertyName)
        {
            var property = obj.GetType().GetProperty(propertyName);
            if (property == null)
            {
                return false;
            }
            return property.GetValue(obj, null) is bool value ? value : false;
        }
        
        /// <summary>
        /// Ejecuta una consulta con paginación utilizando LINQ.
        /// </summary>
        /// <typeparam name="T">Tipo de los datos de retorno.</typeparam>
        /// <param name="query">Consulta IQueryable base.</param>
        /// <param name="page">Número de página (comienza en 1).</param>
        /// <param name="pageSize">Tamaño de la página.</param>
        /// <returns>Colección paginada de elementos.</returns>
        public IQueryable<T> GetPaged<T>(IQueryable<T> query, int page, int pageSize) where T : class
        {
            if (page <= 0) page = 1;
            if (pageSize <= 0) pageSize = 10;
            
            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }
         
        /// <summary>
        /// Ejecuta una consulta LINQ y devuelve los resultados como una colección asíncrona.
        /// </summary>
        /// <typeparam name="T">Tipo de los datos de retorno.</typeparam>
        /// <param name="query">Consulta IQueryable a ejecutar.</param>
        /// <returns>Colección asíncrona de resultados.</returns>
        public async Task<List<T>> ToListAsyncSafe<T>(IQueryable<T> query)
        {
            if (query == null)
                return new List<T>();
                
            return await EntityFrameworkQueryableExtensions.ToListAsync(query);
        }

        /// <summary>
        /// Método interno para garantizar la auditoría de los cambios en las entidades.
        /// </summary>
        private void EnsureAudit()
        {
            ChangeTracker.DetectChanges();
            
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is GenericModel);

            var currentDateTime = DateTime.UtcNow;

            foreach (var entry in entries)
            {
                if (entry.Entity is GenericModel entity)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entity.Active = true;
                            break;
                        //case EntityState.Modified:
                        //    entity.UpdatedAt = currentDateTime;
                        //    break;
                        case EntityState.Deleted:
                            // Convertimos el borrado en un borrado lógico
                            entry.State = EntityState.Modified;
                            entity.DeleteAt = currentDateTime;
                            entity.Active = false;
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Estructura para ejecutar comandos SQL con Dapper en Entity Framework Core.
        /// </summary>
        public readonly struct DapperEFCoreCommand : IDisposable
        {
        /// <summary>
            /// Constructor del comando Dapper.
            /// </summary>
            /// <param name="context">Contexto de la base de datos.</param>
            /// <param name="text">Consulta SQL.</param>
            /// <param name="parameters">Parámetros opcionales.</param>
            /// <param name="timeout">Tiempo de espera opcional.</param>
            /// <param name="type">Tipo de comando SQL opcional.</param>
            /// <param name="ct">Token de cancelación.</param>
            public DapperEFCoreCommand(DbContext context, string text, object parameters, int? timeout, CommandType? type, CancellationToken ct)
            {
                var transaction = context.Database.CurrentTransaction?.GetDbTransaction();
                var commandType = type ?? CommandType.Text;
                var commandTimeout = timeout ?? context.Database.GetCommandTimeout() ?? 30;

                Definition = new CommandDefinition(
                    text,
                    parameters,
                    transaction,
                    commandTimeout,
                    commandType,
                    cancellationToken: ct
                );
            }

        //    /// <summary>
        //    /// Define los parámetros del comando SQL.
        //    /// </summary>
           public CommandDefinition Definition { get; }

        //    /// <summary>
        //    /// Método para liberar los recursos.
        //    /// </summary>
           public void Dispose()
           {
           }
        }
    }
}
