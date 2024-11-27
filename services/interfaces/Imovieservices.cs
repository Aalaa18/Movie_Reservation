using Movie.Models;

namespace Movie.services.interfaces
{
    public interface Imovieservices
    {
        void AddMovie(string name, string Category, string Description);
        void displaymovie();
        List<movie> Getmovies();
        void RemoveMovie(string name);
    }
}