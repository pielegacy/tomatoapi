using Microsoft.EntityFrameworkCore;

namespace TomatoAPI
{
    public class TomatoDb : DbContext
    {
        // Reference our tomato table using this
        public DbSet<Tomato> Tomatos { get; set; }  
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./Tomatos.db");
        }
    }
}
