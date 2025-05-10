using CineApp.Data;
using CineApp.Model;
using CineApp.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CineApp.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Movie> _entity;

        public MovieRepository(AppDbContext context)
        {
            _context = context;
            _entity = _context.Set<Movie>();
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await _entity.ToListAsync();
        }

        public async Task<Movie?> GetByIdAsync(int id)
        {
            return await _entity.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Movie>> GetByNameAsync(string name)
        {
            return await _entity
                .FromSqlRaw("EXECUTE spGetMovieByName {0}", name)
                .IgnoreQueryFilters()
                .ToListAsync();
        }

        public async Task<bool> AddAsync(Movie movie)
        {
            await _entity.AddAsync(movie);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(Movie movie)
        {
            _entity.Update(movie);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var movie = await GetByIdAsync(id);
            if (movie == null)
                return false;

            movie.IsDeleted = true;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
