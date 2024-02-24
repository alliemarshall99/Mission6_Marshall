using Microsoft.EntityFrameworkCore;

namespace Mission6_Marshall.Models
{
    public class FilmDbContext : DbContext
    {
        public FilmDbContext(DbContextOptions<FilmDbContext> options) : base(options) { }

        public DbSet<Film> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
