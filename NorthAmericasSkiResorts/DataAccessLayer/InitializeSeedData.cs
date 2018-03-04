using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NorthAmericasSkiResorts.Models;

namespace NorthAmericasSkiResorts.DataAccessLayer
{
    public static class InitializeSeedData
    {
        public static IEnumerable<SkiResort> GetAllSkiResorts()
        {
            IList<SkiResort> skiResorts = new List<SkiResort>();

            skiResorts.Add(new SkiResort
            {
                Id = 1,
                Name = "Telluride",
                Address = "565 Mountain Village Blvd.",
                City = "Telluride",
                State = "CO",
                Zip = "81435",
                Phone = "(866) 754-8355",
                URL = "TellurideSkiResort.com"
            });

            return skiResorts;
        }
    }
}