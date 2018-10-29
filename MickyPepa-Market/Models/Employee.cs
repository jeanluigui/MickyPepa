using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MickyPepa_Market.Models
{
    //[Table("NewNameTable")] Renombrar tabla
    public class Employee
    {
        [Key]
        public Int32 EmployeeID { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "You must enter {0}")]
        [StringLength(30, ErrorMessage = "The Field {0} must be between {1} and {2} characters", MinimumLength = 3)]
        //[Column("Name")] //Renombrar columna
        public String FirstName { get; set; }

        [StringLength(30, ErrorMessage = "The Field {0} must be between {1} and {2} characters", MinimumLength = 3)]
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You must enter {0}")]
        public String LastName { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public Decimal Salary { get; set; }

        [Display(Name = "Bonus %")]
        [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = false)]
        public float BonusPercent { get; set; }

        [Display(Name = "Date Of Birth")]
        [Required(ErrorMessage = "You must enter {0}")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Start Time")]
        [Required(ErrorMessage = "You must enter {0}")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }

        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        [DataType(DataType.Url)]
        public String Url { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        //[ForeignKey("NombredeForanea")] //para ponerle el mismo nombre que en la otra tabla
        public Int32 DocumentTypeID { get; set; }

        [NotMapped]
        public Int32 Age { get { return DateTime.Now.Year - DateOfBirth.Year; } }

        public virtual DocumentType DocumentType { get; set; }
    }
}