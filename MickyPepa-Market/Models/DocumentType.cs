using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MickyPepa_Market.Models
{
    public class DocumentType
    {
        [Key]
        [Display(Name = "Document Type")]
        public Int32 DocumentTypeID { get; set; }

        [StringLength(30, ErrorMessage = "The field {0} must contain between {2} and {1} characters", MinimumLength = 3)]
        [Required(ErrorMessage = "You must enter the field {0}")]
        [Display(Name = "Document Description")]
        public String Description { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}