using Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.services
{
    internal class showtimeManagerFactory
    {
        public static showtime create(DateTime date,int showhallid)
        {
            return new showtime(date,showhallid);
        }
    }
}
