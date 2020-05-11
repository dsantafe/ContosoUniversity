using System.Collections.Generic;

namespace ContosoUniversity.BL.DTOs
{
    public class CourseDTO
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public ICollection<EnrollmentDTO> EnrollmentsDTO { get; set; }
    }
}
