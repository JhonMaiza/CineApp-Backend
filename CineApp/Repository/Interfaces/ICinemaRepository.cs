namespace CineApp.Repository.Interfaces
{
    public interface ICinemaRepository
    {
        Task<int> GetActiveMovieCountByCinemaNameAsync(string name);
    }
}
