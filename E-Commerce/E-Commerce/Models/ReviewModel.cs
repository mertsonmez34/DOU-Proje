using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public class ReviewModel
    {
        public int ProductID { get; set; }

        public DateTime Date { get; set; }

        public string SenderName { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Enter number 1 - 5")]
        public int Ranking { get; set; }

        [DisplayName("Write your comment")]
        [Required(ErrorMessage = "Comment can not be empty")]
        [StringLength(150, ErrorMessage = "You reached maximum character limit")]
        public string Content { get; set; }
    }
}