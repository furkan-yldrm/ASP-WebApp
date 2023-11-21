using Microsoft.EntityFrameworkCore;

namespace ASP_WebApp.Models
{
    public class Context:DbContext 
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-BFK55O4; database=Employee; integrated security=true;");
        }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }
        
    }
}
