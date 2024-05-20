using Microsoft.EntityFrameworkCore;
namespace LabaCRUD.Pages.Models
{
    public class ClientContext:DbContext
    {
        public ClientContext(DbContextOptions<ClientContext> options) : base(options) { }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Client> Clients { get; set;}
        
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Order> Orders { get; set; }

    }
}
