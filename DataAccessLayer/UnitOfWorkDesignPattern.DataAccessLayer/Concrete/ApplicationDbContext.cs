using Microsoft.EntityFrameworkCore;
using UnitOfWorkDesignPattern.EntityLayer.Concrete;

namespace UnitOfWorkDesignPattern.DataAccessLayer.Concrete
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Process> Processes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Data for Customers
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerID = 1, CustomerName = "Murat", CustomerBalance = 1000 },
                new Customer { CustomerID = 2, CustomerName = "Numan", CustomerBalance = 2000 },
                new Customer { CustomerID = 3, CustomerName = "Ayşe", CustomerBalance = 1500 },
                new Customer { CustomerID = 4, CustomerName = "Kadir", CustomerBalance = 2500 },
                new Customer { CustomerID = 5, CustomerName = "Fatma", CustomerBalance = 3000 }
            );

            // Seed Data for Processes
            modelBuilder.Entity<Process>().HasData(
                new Process { ProcessID = 1, Sender = 1, Receiver = 2, Amount = 500 },
                new Process { ProcessID = 2, Sender = 2, Receiver = 3, Amount = 700 },
                new Process { ProcessID = 3, Sender = 3, Receiver = 4, Amount = 600 },
                new Process { ProcessID = 4, Sender = 4, Receiver = 5, Amount = 900 },
                new Process { ProcessID = 5, Sender = 5, Receiver = 1, Amount = 1200 }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
