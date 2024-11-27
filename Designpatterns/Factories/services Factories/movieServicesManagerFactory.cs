﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movie.services;
using Movie.services.interfaces;

namespace Movie.Designpatterns.Factories
{
    internal class movieServicesManagerFactory
    {
        public static Imovieservices create(ApplicationDbcontext dbcontext)
        {
            return new movieservices(dbcontext);
        }
    }
}
