﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movie.services;
using Movie.services.interfaces;

namespace Movie.Designpatterns.Factories
{
    internal class userservicesManagerFactory
    {
        public static Iuserservices create(ApplicationDbcontext context)
        {

            return new userservices(context);

        }
    }
}
