using Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.services
{
    public class userservices
    {
        private ApplicationDbcontext _context;

        public userservices(ApplicationDbcontext context)
        {
            _context = context;
        }

        public users GetUsers(string name)
        {
            return _context.users.SingleOrDefault(x => x.Name == name);
        }

        public void start()
        {
            Console.WriteLine(@"
1- login
2- create account
");
        }

        public void showoptions(string name)
        {
            var user = GetUsers(name);
            if (user.type == "admin")
            {


                Console.WriteLine(@"
1-list the avaliable movies
2-list the showtimes
3-make reservation
4-list my reservations
5-cancel reservation
6-Add movie
7-Remove Movie
8-Add ShowTime
9-Remove ShowTime
10-Add Seats forShowTime
11-Remove User
press x to exit

"
);
            }
            else
            {
                Console.WriteLine(@"
1-list the avaliable movies
2-list the showtimes
3-make  reservation
4-list my reservations
5-cancel reservation
press x to exit

");
            }


        }

        public bool checkusers(string name, string pass)
        {
            bool check = false;
            var user = _context.users.SingleOrDefault(x => x.Name == name && x.pass == pass);
            if (user != null)
            {
                check = true;
                Console.WriteLine("user found");
            }
            else
            {
                check = false;
                Console.WriteLine("incorrect name or password");
            }
            return check;
        }

        public void addusers()
        {

            while (true)
            {
                Console.WriteLine("please enter the user name");
                var user_name = Console.ReadLine();

                Console.WriteLine("please enter the  password the password should be at lease 8 characters");
                var user_pass = Console.ReadLine();

                Console.WriteLine("please enter the  email it should be like exaple***@gmail.com");
                var user_mail = Console.ReadLine();
                Console.WriteLine("please enter the type either ordinary or admin");
                var user_type = Console.ReadLine();
                if (user_pass.Length >= 8 && user_mail.Contains("@gmail.com") && GetUsers(user_name) == null)
                {
                    var user = new users
                    {
                        Name = user_name,
                        email = user_mail,
                        pass = user_pass,
                        type = user_type
                    };

                    _context.users.Add(user);

                    _context.SaveChanges();
                    Console.WriteLine("Account created successfully");

                    break;

                }
                else
                {
                    Console.WriteLine("there's something wrong please reenter the credientails again");
                }
            }

        }

        public bool checkAdmin(string name)
        {
            bool isadmin = false;
            if (_context.users.Any(u => u.Name == name && u.type == "admin"))
            {
                isadmin = true;
            }
            else
            {
                isadmin = false;
            }
            return isadmin;
        }

        public void RemoveUser(string name)
        {
            var user=GetUsers(name);    
            if (user != null)
            {
                _context.users.Remove(user);
                _context.SaveChanges(); 
                Console.WriteLine("User Removed");

            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }
    }
}
