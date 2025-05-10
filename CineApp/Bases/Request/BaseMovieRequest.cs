namespace CineApp.Bases.Request
{
    public class BaseMovieRequest
    {
        public int Id { get; set; }
        public string? TextFilter { get; set; } = null;
        public string? StartDate { get; set; } = null;
        public string? EndDate { get; set; } = null;
    }
}
