using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfraSQLite
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=ABC.db");
        }

        public DbSet<Student> Students { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //从当前程序集加载所有的：  IEntityTypeConfiguration
            //但是这样会把其他DbContext的也加载进来，建表。。。
            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        }

        public async Task<bool> SaveEntitiesAsync()
        {
            // Dispatch Domain Events collection. 
            // Choices:
            // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including  
            // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
            // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions. 
            // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers. 
            //---》》await _mediator.PublishDomainEventsAsync(this);//.ConfigureAwait(false);//Equinox的配置.

            // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
            // performed through the DbContext will be committed

            bool success = await SaveChangesAsync() > 0;

            return success;
        }
    }
}
