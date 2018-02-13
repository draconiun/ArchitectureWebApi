using Calidda.Application.Interfaces;
using Calidda.Domain.Common;
using Calidda.Domain.Employees;
using Calidda.Persistance.Employees;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calidda.Persistance
{
    public class DatabaseService : DbContext, IDatabaseService
    {
        public IDbSet<Employee> Employees { get; set; }
        public DatabaseService() : base("Calidda")
        {
            //using (var context = new DatabaseService())
            //{
            //    context.Database.CreateIfNotExists();
            //}
            //Database.SetInitializer(new DatabaseInitializer());
        }
        public async Task<int> SaveAsync()
        {
            int result = await SaveChangesAsync();
            return result;
        }
        public void Save()
        {
            SaveChanges();
        }
        public void Update(IEntity entity)
        {
            var entry = this.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.Set<IEntity>().Attach(entity);
                entry = this.Entry(entity);
            }
            entry.State = EntityState.Modified;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            

        }
    }
}
