using DAL.AMenistop.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.AMenistop
{
    internal class AMenistopContext : DbContext
    {
        public AMenistopContext()
        {

        }

        internal DbSet<StoreItem> StoreItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StoreItem>().ToTable("StoreItem");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\;Database=AMenistop;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}