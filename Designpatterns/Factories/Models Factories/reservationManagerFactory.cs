using Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.services
{
    internal class reservationManagerFactory
    {
        public static reservations create(int user_id,DateTime date, string reservationdate, int showtime_id)
        {
            return new reservations(user_id,date,reservationdate,showtime_id);
        }
    }
}
