using Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Movie.services
{
    public class seatsservices : Iseatsservices
    {
        private ApplicationDbcontext _context;
        // private reservations _reservations;
        public seatsservices(ApplicationDbcontext context)
        {
            _context = context;
        }

        public List<showtimeseats> GetSeats(int showtime_id)
        {
            return _context.showtimeseats.Where(s => s.showtime_id == showtime_id).ToList();
        }

        public List<string> splittingString(string type)
        {
            return type.Split(",").Select(x => x.Trim()).ToList();
        }



    }
}
