﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NASR.Models
{
        
    public class Review
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int NumberOfStars { get; set; }
        public int SkiResortId { get; set; }
    }
}