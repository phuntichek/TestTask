using System;
using TestTask.Service;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace TestTask.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<DateCurrencyExchange> DateCurrencyExchanges { get; set; }

        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
