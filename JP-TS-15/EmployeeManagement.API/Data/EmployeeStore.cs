namespace EmployeeManagement.API.Data
{
    public static class EmployeeStore
    {
        public static List<Employee> Employees { get; set; } = new()
        {
            new Employee() { Id = 1, FirstName = "Nodari", LastName = "Eqvtimishvili" },
            new Employee() { Id = 2, FirstName = "Guka", LastName = "Shinjikashvili" },
            new Employee() { Id = 3, FirstName = "Aleksandre", LastName = "Iosava" },
            new Employee() { Id = 4, FirstName = "Tako", LastName = "Makhatadze" },
            new Employee() { Id = 5, FirstName = "Nika", LastName = "Kuprashvili" }
        };
    }
}


