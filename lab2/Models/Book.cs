using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace lab2.Models
{
    public class Book
    {
        public int id { get; set; }
        [Required(ErrorMessage = "please input Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "please input Author")]
        [StringLength(50, ErrorMessage ="Author les than 50 characters")]
        public string Author { get; set; }
        public int PublicYear { get; set; }
        public double Price { get; set; }
        public string Cover { get; set; }
    }
}