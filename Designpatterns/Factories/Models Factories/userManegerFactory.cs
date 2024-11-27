using Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.services
{
    internal class userManegerFactory
    {
        public static users create(string name,string pass,string mail, string type)
        {
            return new users(name, pass, mail, type);
        }
    }
}
