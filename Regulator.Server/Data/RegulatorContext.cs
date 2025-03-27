using Microsoft.EntityFrameworkCore;
using Regulator.Server.Models;

namespace Regulator.Server.Data
{
    public class RegulatorContext : DbContext
    {
        public DbSet<OperationsLog> OperationsLogs { get; set; }
        public RegulatorContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=db.db");
        }
    }
}
