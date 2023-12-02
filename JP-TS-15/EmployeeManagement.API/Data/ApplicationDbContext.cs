using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

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
        }

    }
}
