using Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Movie.services
{
    public class reservationservice : Ireservationservice
    {
        private ApplicationDbcontext _context;
        private Iseatsservices _seatsservices;
        private Iuserservices _userservices;
        private Ishowtimeservices _showtimes;

        public reservationservice(ApplicationDbcontext context, Iseatsservices seatsservices, Iuserservices userservices, Ishowtimeservices showtimes)
        {
            _context = context;
            _seatsservices = seatsservices;
            _userservices = userservices;
            _showtimes = showtimes;
        }

        public List<reservations> GetReservations(users user)
        {
            return _context.reservations.Where(x => x.user_id == user.Id).ToList();
        }

        public void make_reservation(string name, int x)
        {
            var user = _userservices.GetUsers(name);
            var showtimeseats = _seatsservices.GetSeats(x);
            var show = _showtimes.GetShowtimes(x);
            if (show.is_active == true)
            {
                foreach (var seat in showtimeseats)
                {
                    if (seat.istaken == false)
                    {
                        Console.WriteLine($" seat number {seat.seat_id} is free");
                    }
                }


                var seatcheck = showtimeseats.Count(i => i.istaken == false && i.showtime_id == x);
                if (seatcheck != 0)
                {
                    Console.WriteLine("please enter the seat id if you want to book more than one seat seprate them by comma");
                    var s = Console.ReadLine();
                    var seat_id = _seatsservices.splittingString(s);
                    bool check = false;
                    foreach (var se in seat_id)
                    {
                        int.TryParse(se, out int parsedSeatId);
                        if (showtimeseats.Any(s => s.seat_id == parsedSeatId && s.istaken == false))
                        {

                            var takenseats = showtimeseats.SingleOrDefault(s => s.seat_id == parsedSeatId);
                            takenseats.istaken = true;
                            check = true;
                        }
                        else
                        {
                            Console.WriteLine("Enter a valid seat number");


                        }
                    }

                    if (check)
                    {
                        var reservations = reservationManagerFactory.create(user.Id, DateTime.Now, s, x);
                        _context.reservations.Add(reservations);
                        Console.WriteLine("Booked successfully");


                    }
                }

                else
                {
                    Console.WriteLine("there's no avaliable seats for this show time");

                    show.is_active = false;

                }
            }
            else
            {
                Console.WriteLine("enter a valid showtime id");
            }

            _context.SaveChanges();



        }

        public void show_reservation(string name)
        {
            var user = _userservices.GetUsers(name);
            var res = GetReservations(user);
            foreach (var us in res)
            {

                Console.WriteLine($"{user.Name} made a reservation  at time: {us.reservedate} with seats {us.reservedseat}");
            }
            if(res.Count==0)
            {
                Console.WriteLine("there's noreservations Done Yet");
            }


        }

        public void cancel_reseved_seats(string name)
        {
            var finduser = _context.users.SingleOrDefault(x => x.Name == name);
            var rese = GetReservations(finduser);

            foreach (var r in rese)
            {
                var seats = _seatsservices.splittingString(r.reservedseat);
                foreach (var se in seats)
                {
                    int.TryParse(se, out int parsedSeatId);
                    var showseat = _context.showtimeseats.SingleOrDefault(s => s.seat_id == parsedSeatId && r.showtime_id == s.showtime_id);
                    showseat.istaken = false;


                }
            }

        }

        public void CancelReservation(string name)
        {
            var user = _userservices.GetUsers(name);
            var rese = GetReservations(user);
            //List<string> selected;
            if (rese.Count != 0)
            {
                foreach (var s in rese)
                {
                    var show = _showtimes.GetShowtimes(s.showtime_id);
                    bool v = _showtimes.displayUpcomingreservations(show);

                    if (v)
                    {
                        _showtimes.Display(rese, show);
                        Console.WriteLine("enter the reservation id you want to cancel it");
                        var ch = Console.ReadLine();
                        var selected = _seatsservices.splittingString(ch);
                        foreach (var i in selected)
                        {

                            cancel_reseved_seats(name);
                            _context.reservations.Remove(s);

                        }
                        Console.WriteLine("cancelled");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("No  reservations made  for  upcoming  showtime.");
                    }
                }
            }
            else
            {
                Console.WriteLine("No  reservations made  for  upcoming  showtime.");
            }

            _context.SaveChanges();



        }

        public void CancelReservationsForRemovedUser(string name)
        {

            cancel_reseved_seats(name);

            _userservices.RemoveUser(name);
        }


    }
}
