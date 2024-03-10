using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Movies4u.Data;

namespace Movies4u.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Movies4u.Data.Movies>? Movies { get; set; }
        public DbSet<Movies4u.Data.Genre>? Genre { get; set; }
        public DbSet<Movies4u.Data.MoviesandGenres>? MoviesandGenres { get; set; }
    }
}