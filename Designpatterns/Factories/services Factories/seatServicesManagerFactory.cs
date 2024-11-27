using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movie.services;
using Movie.services.interfaces;

namespace Movie.Designpatterns.Factories
{
    internal class seatServicesManagerFactory
    {
        public static Iseatsservices create(ApplicationDbcontext context)
        {
            return new seatsservices(context);
        }
    }
}
