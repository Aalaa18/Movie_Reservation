using Movie.Models;

namespace Movie.services.interfaces
{
    public interface Ireservationservice
    {
        void CancelReservation(string name);
        void CancelReservationsForRemovedUser(string name);
        void cancel_reseved_seats(string name);
        List<reservations> GetReservations(users user);
        void make_reservation(string name, int x);
        void show_reservation(string name);
    }
}