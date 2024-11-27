using Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.services
{
    internal class servedhallManagerFactory
    {
        public static servedhall create(int hall_id, int movie_id)
        {
            return new servedhall(hall_id,movie_id);
        }
    }
}
