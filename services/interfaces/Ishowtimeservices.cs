using Movie.Models;

namespace Movie.services.interfaces
{
    public interface Ishowtimeservices
    {
        void AddSeatsForShowtime(int id);
        void AddShowTime(int movieId, int hallId, DateTime date);
        void Display(List<reservations> reservations, showtime showtimes);
        bool displayUpcomingreservations(showtime showtimes);
        showtime GetShowtimes(int id);
        showtimeseats GetShowtimeseats(int id);
        void listshowtimes();
        void RemoveShowTime(string id);
    }
}