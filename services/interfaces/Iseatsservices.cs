using Movie.Models;

namespace Movie.services.interfaces
{
    public interface Iseatsservices
    {
        List<showtimeseats> GetSeats(int showtime_id);
        List<string> splittingString(string type);
    }
}