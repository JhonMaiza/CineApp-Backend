using CineApp.Data;
using CineApp.Model;
using CineApp.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CineApp.Repository
{
    public class CinemaRepository: ICinemaRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<CinemaMovie> _entity;

        public CinemaRepository(AppDbContext context)
        {
            _context = context;
            _entity = _context.Set<CinemaMovie>();
        }

        public async Task<int> GetActiveMovieCountByCinemaNameAsync(string name)
        {
            var now = DateTime.Now;
            return await _entity
                .Where(cm =>
                    cm.Cinema.Name.ToLower() == name.ToLower() &&
                    cm.ReleaseDate <= now &&
                    cm.EndDate >= now)
                .CountAsync();
        }
    }
}
