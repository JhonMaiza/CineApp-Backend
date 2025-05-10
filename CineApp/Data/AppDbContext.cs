using CineApp.Model;
using Microsoft.EntityFrameworkCore;

namespace CineApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cinema> Cinema { get; set; }
        public DbSet<CinemaMovie> CinemaMovies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Movie table
            modelBuilder.Entity<Movie>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<Movie>()
                .HasQueryFilter(m => !m.IsDeleted);

            modelBuilder.Entity<Movie>()
                .Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Movie>()
                .Property(m => m.Duration)
                .IsRequired();

            // Cinema Table
            modelBuilder.Entity<Cinema>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Cinema>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Cinema>()
                .Property(c => c.State)
                .IsRequired();

            // CinemaMovie Table
            modelBuilder.Entity<CinemaMovie>()
                .HasKey(cm => cm.Id);
            
            modelBuilder.Entity<CinemaMovie>()
                .HasQueryFilter(cm => !cm.Movie.IsDeleted);

            modelBuilder.Entity<CinemaMovie>()
                .HasOne(cm => cm.Movie)
                .WithMany(m => m.CinemaMovies)
                .HasForeignKey(cm => cm.MovieId);

            modelBuilder.Entity<CinemaMovie>()
                .HasOne(cm => cm.Cinema)
                .WithMany(c => c.CinemaMovies)
                .HasForeignKey(cm => cm.CinemaId);

            modelBuilder.Entity<CinemaMovie>()
                .Property(ps => ps.ReleaseDate)
                .IsRequired();

            modelBuilder.Entity<CinemaMovie>()
                .Property(ps => ps.EndDate)
                .IsRequired();
        }
    }
}
