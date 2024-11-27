using Movie.services;

namespace Movie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new ApplicationDbcontext();

            Iuserservices userservices = userservicesManagerFactory.create(context);
            Iseatsservices seatsservices = seatServicesManagerFactory.create(context); 
            Ishowtimeservices showtimeservices = ShowtimeServicesManagerFactory.create(context, seatsservices);
            Ireservationservice reservationservice = reservationservicesManagerFactory.create(context, seatsservices, userservices, showtimeservices);
            Imovieservices movieservices = movieServicesManagerFactory.create(context);

            while (true)
            {
                userservices.start();
                Console.WriteLine("Enter your choice");
                var an = (Console.ReadLine());
                if (int.Parse(an) == 1)
                {
                    Console.Write("please enter your user name: ");
                    string name = Console.ReadLine();
                    Console.Write("please enter the password: ");
                    string pass = Console.ReadLine();
                    if (userservices.checkusers(name, pass))
                    {
                        while (true)
                        {
                            userservices.showoptions(name);
                            
                                Console.WriteLine("Enter your choice");
                                string z = Console.ReadLine();
                                if (z.ToLower() == "x" || z.ToUpper() == "X")
                                {
                                    break;
                                }
                                int x = int.Parse(z);

                                if (x == 1)
                                {
                                    movieservices.displaymovie();
                                }
                                else if (x == 2)
                                {
                                    showtimeservices.listshowtimes();



                                }
                                else if (x == 3)
                                {
                                    Console.WriteLine("enter Showtime id");
                                    x = int.Parse(Console.ReadLine());
                                    reservationservice.make_reservation(name, x);
                                }
                                else if (x == 4)
                                {
                                    reservationservice.show_reservation(name);
                                }
                                else if (x == 5)
                                {

                                    reservationservice.CancelReservation(name);
                                }
                            
                                else if (x == 6 &&userservices.checkAdmin(name))
                                {
                                    Console.WriteLine("Enter the movie name");
                                    var movie_name = Console.ReadLine();
                                    Console.WriteLine("Enter the movie Description");
                                    var movie_Des = Console.ReadLine();
                                    Console.WriteLine("Enter the movie type");
                                    var movie_type = Console.ReadLine();
                                    movieservices.AddMovie(movie_name, movie_type, movie_Des);
                                }
                                else if (x == 7 && userservices.checkAdmin(name))
                                {
                                    Console.WriteLine("Enter the movie name");
                                    var movie_name = Console.ReadLine();
                                    movieservices.RemoveMovie(movie_name);
                                }
                            else if (x == 8 && userservices.checkAdmin(name))
                                {
                                    Console.WriteLine("please Enter the MovieId");
                                    var movie_id = int.Parse(Console.ReadLine());
                                    Console.WriteLine("please Enter the HallId");
                                    var hall_n = int.Parse(Console.ReadLine());
                                    Console.WriteLine("please Enter the showtime Date");
                                    var date = DateTime.Parse(Console.ReadLine());
                                showtimeservices.AddShowTime(movie_id, hall_n, date);
                                }
                            else if (x == 9 && userservices.checkAdmin(name))
                            {
                                 showtimeservices.listshowtimes();
                                Console.WriteLine("please Enter the showtime ID");
                                var show_id = Console.ReadLine();
                                showtimeservices.RemoveShowTime(show_id);
                            }   else if (x == 10 && userservices.checkAdmin(name))
                            {
                                
                                Console.WriteLine("please Enter the showtime ID");
                                var show_id = int.Parse(Console.ReadLine());
                                showtimeservices.AddSeatsForShowtime(show_id);
                            }
                            else if (x == 11 && userservices.checkAdmin(name))
                            {

                                Console.WriteLine("please Enter the  User Name");
                                var user_name = Console.ReadLine();
                                reservationservice.CancelReservationsForRemovedUser(user_name);
                            }



                        }
                    }
                }
                else
                {
                    userservices.addusers();
                }
            }
        }
    }
}