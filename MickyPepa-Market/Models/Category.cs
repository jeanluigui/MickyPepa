using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MickyPepa_Market.Models
{
    public class Category
    {
        [Key]
        public Int32 CategoryID { get; set; }

        [StringLength(30, ErrorMessage = "The field {0} must contain between {2} and {1} characters", MinimumLength = 3)]
        [Required(ErrorMessage = "You must enter the field {0}")]
        [Display(Name = "Document Description")]
        public String Description { get; set; }
    }
}