using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NASR.Models
{
        
    public class Review
    {
        public int Id { get; set; }
        [Display(Name = "Review")]
        public string Content { get; set; }
        [Display(Name = "Number Of Stars")]
        [Range(1,5)]
        public int NumberOfStars { get; set; }
        public int SkiResortId { get; set; }
    }
}