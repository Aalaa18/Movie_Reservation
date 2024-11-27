using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movie.services;
using Movie.services.interfaces;

namespace Movie.Designpatterns.Factories
{
    internal class ShowtimeServicesManagerFactory
    {
        public static Ishowtimeservices create(ApplicationDbcontext dbcontext, Iseatsservices seat)
        {
            return new showtimeservices(dbcontext, seat);
        }
    }
}
