using Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.services
{
    internal class MovieManagerFactory
    {
        public static movie create(string name, string description,string category)
        {
            return new movie(name, description, category);
        }
    }
}
