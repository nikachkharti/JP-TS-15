using EmployeeManagement.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }


        //Data seed...
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                    new Employee() { Id = 1, FirstName = "Nodari", LastName = "Eqvtimishvili" },
                    new Employee() { Id = 2, FirstName = "Guka", LastName = "Shinjikashvili" },
                    new Employee() { Id = 3, FirstName = "Aleksandre", LastName = "Iosava" },
                    new Employee() { Id = 4, FirstName = "Tako", LastName = "Makhatadze" },
                    new Employee() { Id = 5, FirstName = "Nika", LastName = "Kuprashvili" }
                );

            modelBuilder.Entity<Company>().HasData(
                    new Company() { Id = 1, Title = "Microsoft", CreateDate = new DateTime(year: 1974, month: 4, day: 4) },
                    new Company() { Id = 2, Title = "Apple", CreateDate = new DateTime(year: 1976, month: 4, day: 1) },
                    new Company() { Id = 3, Title = "Sony", CreateDate = new DateTime(year: 1946, month: 5, day: 7) }
                );
        }

    }
}
