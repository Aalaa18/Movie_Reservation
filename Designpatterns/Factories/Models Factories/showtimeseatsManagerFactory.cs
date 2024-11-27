using Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.services
{
    internal class showtimeseatsManagerFactory
    {

        public static showtimeseats create(int seatid, int showid)
        {
            return new showtimeseats(seatid, showid);
        }
    }
}
