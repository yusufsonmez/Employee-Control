using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CompanyEmployees.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(): base("DefaultConnection")
        {

        }


        public static void Seed(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Name = "Ali",
                    Surname = "Yılmaz"
                }
            );
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Name = "Veli", Surname = "Yalçın" },
                new Employee { Name = "Ezgi", Surname = "Kaya" },
                new Employee { Name = "Aslı", Surname = "Kara" }
            );
        }
        

        public DbSet<Employee> Employees { get; set; }

    }
}