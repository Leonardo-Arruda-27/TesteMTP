using Microsoft.EntityFrameworkCore;
using TesteMTP.Models;

namespace TesteMTP.Data
{
    public class ConnectionContext : DbContext
    {
        public ConnectionContext(DbContextOptions<ConnectionContext> options) : base(options)
        {
        }

        public DbSet<Models.Task> Task { get; set; }

    }
}
