using Microsoft.EntityFrameworkCore;

namespace DailyMiracle.Standard
{
    public class DatabaseContext : DbContext
    {
        public DbSet<MiracleDay> MiracleDays { get; set; }

        private readonly string _databasePath;

        public DatabaseContext(string databasePath)
        {
            _databasePath = databasePath;

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }
    }
}
