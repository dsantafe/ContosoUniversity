using System;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.DTOs
{
    public class StudentDTO
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "The Last Name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The First MidNameis required")]
        [Display(Name = "First MidName")]
        public string FirstMidName { get; set; }

        [Required(ErrorMessage = "The Enrollment Date is required")]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }
    }
}
