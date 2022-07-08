using academymanagement.Domain.Entities;
using academymanagement.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace academymanagement.Infra.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("academymanagement");

            var typesToRegister = AppDomain
                                  .CurrentDomain
                                  .GetAssemblies()
                                  .SelectMany(x => x.GetTypes())
                                  .Where(x => typeof(IEntityConfiguration)
                                  .IsAssignableFrom(x) && !x.IsAbstract)
                                  .ToList();

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }
        }

        //public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        //public DbSet<EmployeeAddress> EmployeeAddresses { get; set; }
        //public DbSet<Billing> Billings { get; set; }
        //public DbSet<Customer> Customers { get; set; }
        //public DbSet<Employee> Employees { get; set; }
        //public DbSet<Plan> Plans { get; set; }
        //public DbSet<Position> Positions { get; set; }
        //public DbSet<Schedule> Schedules { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
