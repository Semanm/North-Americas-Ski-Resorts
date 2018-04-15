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
        [Required]
        public string Content { get; set; }
        public int NumberOfStars { get; set; }
        [Display(Name ="Ski Resort")]
        public int SkiResortId { get; set; }
        public string SkiResortName { get; set; }
    }
}