using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movie.services.interfaces;

namespace Movie.services
{
    internal class reservationservicesManagerFactory
    {
        public static Ireservationservice create(ApplicationDbcontext context,Iseatsservices seat,Iuserservices user,Ishowtimeservices show)
        {
            return new reservationservice(context, seat, user, show);
        }
    }
}
