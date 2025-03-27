using Microsoft.EntityFrameworkCore;
using Regulator.API.Models;

namespace Regulator.API.Data
{
    public class RegulatorContext : DbContext
    {
        public RegulatorContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=app.db");
            }
        }
        DbSet<OperationLog> OperationLogs { get; set; }
    }
}
