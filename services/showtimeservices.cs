using Microsoft.EntityFrameworkCore;
using Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.services
{
    public class showtimeservices : Ishowtimeservices
    {
        private ApplicationDbcontext _context;

        private Iseatsservices _seatsservices;
        public showtimeservices(ApplicationDbcontext context, Iseatsservices seatsservices)
        {
            _context = context;
            _seatsservices = seatsservices;
        }

        public showtime GetShowtimes(int id)
        {
            return _context.showtime.SingleOrDefault(showtimes => showtimes.id == id);
        }

        public showtimeseats GetShowtimeseats(int id)
        {
            return _context.showtimeseats.SingleOrDefault(x => x.showtime_id == id);
        }

        public void listshowtimes()
        {
            var showtime = _context.showtime.OrderBy(s => s.date).ToList();
            foreach (var item in showtime)
            {
                var rhalls = _context.servedhalls.SingleOrDefault(x => x.Id == item.show_hall_id);
                var hall = _context.hall.SingleOrDefault(h => h.id == rhalls.hall_id);
                var movie = _context.movies.SingleOrDefault(x => x.Id == rhalls.movie_id);

                if (item.is_active == true)
                {
                    Console.WriteLine($"showtime_id: {item.id} movie :{movie.Name}  movie type :{movie.category} at hall: {hall.id} at time : {item.date}");
                }


            }
        }

        public bool displayUpcomingreservations(showtime showtimes)
        {
            bool found = false;
            if (showtimes.date > DateTime.Now)
            {
                found = true;

            }
            else
            {
                found = false;

            }
            return found;
        }

        public void Display(List<reservations> reservations, showtime showtimes)
        {
            foreach (var s in reservations)
            {
                if (showtimes.date >= DateTime.Now)
                    Console.WriteLine($"user id :{s.user_id} has a reservation :{s.id} at date :{s.reservedate} with seats {s.reservedseat}");
            }
        }


        public void AddShowTime(int movieId, int hallId, DateTime date)
        {

            var movie = _context.movies.FirstOrDefault(m => m.Id == movieId);
            var hall = _context.hall.FirstOrDefault(h => h.id == hallId);

            if (movie == null)
            {
                Console.WriteLine("Invalid movie.");
                return;
            }
            if (hall == null)
            {
                Console.WriteLine("this hall will be Added");
                _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT hall ON");

                hall = hallManagerFactory.create(hallId);
                _context.hall.Add(hall);
                _context.SaveChanges();
                _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT hall OFF");

            }




            var servedHall = servedhallManagerFactory.create(hall.id, movie.Id);
            

            _context.servedhalls.Add(servedHall);
            _context.SaveChanges();

            var showtime = showtimeManagerFactory.create(date, servedHall.Id);
       


            _context.showtime.Add(showtime);
            _context.SaveChanges();

            Console.WriteLine("ShowTime added Successufully");



        }

        public void RemoveShowTime(string id)
        {

            var seat_id = _seatsservices.splittingString(id);
            bool check = false;
            foreach (var se in seat_id)
            {
                int.TryParse(se, out int parsedSeatId);
                var show = GetShowtimes(parsedSeatId);
                _context.showtime.Remove(show);
            }


            _context.SaveChanges();

            Console.WriteLine("Removed");
        }

        public void AddSeatsForShowtime(int id)
        {
            var show = GetShowtimes(id);

            if (show != null)
            {
                int seatnum = 10;
                for (int i = 1; i <= seatnum; i++)
                {
                    var seat = showtimeseatsManagerFactory.create(i, id);


                    _context.showtimeseats.Add(seat);
                }
                Console.WriteLine("Seats Added Successufully");
            }
            else
            {
                Console.WriteLine("this show time not found");
            }
            _context.SaveChanges();


        }

    }
}
