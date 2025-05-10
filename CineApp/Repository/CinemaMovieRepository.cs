using CineApp.Data;
using CineApp.Model;
using CineApp.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CineApp.Repository
{
    public class CinemaMovieRepository: ICinemaMovieRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<CinemaMovie> _entity;

        public CinemaMovieRepository(AppDbContext context)
        {
            _context = context;
            _entity = _context.Set<CinemaMovie>();
        }

        public async Task<bool> ExistsAsync(int movieId, int cinemaId, DateTime releaseDate)
        {
            return await _entity.AnyAsync(x =>
                x.MovieId == movieId &&
                x.CinemaId == cinemaId &&
                x.ReleaseDate == releaseDate);
        }

        public async Task<bool> AddAsync(CinemaMovie entity)
        {
            await _entity.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Movie>> GetMoviesByReleaseDateAsync(DateTime date)
        {
            return await _entity
                .Where(cm => cm.ReleaseDate.Date == date.Date)
                .Select(cm => cm.Movie)
                .Distinct()
                .ToListAsync();
        }
    }
}
