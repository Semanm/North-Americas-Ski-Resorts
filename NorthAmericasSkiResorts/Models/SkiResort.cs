using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NASR.Models
{
    public class SkiResort 
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        [Display(Name = "Zip Code")]
        public int Zip { get; set; }
        [Display(Name = "Annual Snow Fall")]
        public int SnowFall { get; set; }
        [Display(Name = "Number Of Runs")]
        public int NumberOfRuns { get; set; }
        [Display(Name = "Number Of Lifts")]
        public int NumberOfLifts { get; set; }
        [Display(Name = "Mt. Elevation")]
        public int Elevation { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}