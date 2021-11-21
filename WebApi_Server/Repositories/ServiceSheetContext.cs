using Microsoft.EntityFrameworkCore;
using WebApi_Common.Models;

namespace WebApi_Server.Repositories
{
    public class ServiceSheetContext :DbContext
    {
        public DbSet<ServiceSheet> ServiceSheets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\mssqllocaldb;Database=ServerDb;Integrated Security=True;");
        }
    }
}
