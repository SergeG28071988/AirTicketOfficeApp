using System.Data.Entity;

namespace AirTicketOffice
{
    public class AppContext : DbContext
    {
        public AppContext() : base("DefaultConnection") { }
        public DbSet<User> Users { get; set; }
    }
}
