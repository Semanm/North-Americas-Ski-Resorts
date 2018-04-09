using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NASR.Models
{
    public class SkiResort 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public int Zip { get; set; }
        public int SnowFall { get; set; }
        public int NumberOfRuns { get; set; }
        public int NumberOfLifts { get; set; }
        public int Elevation { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}