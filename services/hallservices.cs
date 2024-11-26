using Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.services
{
    public class hallservices
    {
        private ApplicationDbcontext _context;
        // private reservations _reservations;
        public hallservices(ApplicationDbcontext context)
        {
            _context = context;
        }

        public servedhall GetHall(int id)
        {
            return _context.servedhalls.SingleOrDefault(h => h.Id == id);
        }
    }
}
