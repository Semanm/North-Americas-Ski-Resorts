using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NASR.Models
{
    public class SkiResortReviewViewModel
    {
        [Key]
        public int Id { get; set; }
   
        [Display(Name = "Review")]
        [Required]
        public string Content { get; set; }
        [Display(Name = "Number Of Stars")]
        [Range(1,5)]
        public int NumberOfStars { get; set; }
        [Display(Name ="Ski Resort")]
        public int SkiResortId { get; set; }
        [Display(Name = "Resort Name")]
        public string SkiResortName { get; set; }
    }
}