using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MickyPepa_Market.Models
{
    public class Product
    {
        [Key]
        public Int32 ProductID { get; set; }

        [StringLength(30, ErrorMessage = "The field {0} must contain between {2} and {1} characters", MinimumLength =3)]
        [Required(ErrorMessage = "You must enter the field {0}")]
        [Display(Name = "Product Description")]
        public String Description { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString ="{0:C2}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage ="You must enter the field {0}")]
        public Decimal Price { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LastBuy { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString ="{0:N2}", ApplyFormatInEditMode =false)]
        public Int32 Stock { get; set; }

        [DataType(DataType.MultilineText)]
        public String Remarks { get; set; }

        public virtual ICollection<SupplierProduct> SupplierProducts { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}