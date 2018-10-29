using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MickyPepa_Market.Models
{
    public class Customer
    {
        [Key]
        public Int32 CustomerID { get; set; }
        
        [StringLength(30, ErrorMessage = "The field {0} must contain between {2} and {1} characters", MinimumLength = 3)]
        [Required(ErrorMessage = "You must enter the field {0}")]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [StringLength(30, ErrorMessage = "The field {0} must contain between {2} and {1} characters", MinimumLength = 3)]
        [Required(ErrorMessage = "You must enter the field {0}")]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(30, ErrorMessage = "The field {0} must contain between {2} and {1} characters", MinimumLength = 3)]
        [Required(ErrorMessage = "You must enter the field {0}")]
        public String Phone { get; set; }

        [StringLength(30, ErrorMessage = "The field {0} must contain between {2} and {1} characters", MinimumLength = 3)]
        [Required(ErrorMessage = "You must enter the field {0}")]
        public String Address { get; set; }

        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        [StringLength(30, ErrorMessage = "The field {0} must contain between {2} and {1} characters", MinimumLength = 5)]
        [Required(ErrorMessage = "You must enter the field {0}")]
        [Display(Name = "Document")]
        public String Document { get; set; }
        
        public String FullName
        {
            get
            {
                return String.Format("{0} {1}", FirstName, LastName);
            }
            //set {
            //    FullName = value;
            //}
        }

        public Int32 DocumentTypeID { get; set; }

        public virtual DocumentType DocumentType { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
