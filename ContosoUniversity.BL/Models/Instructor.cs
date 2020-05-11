using System;
using System.Collections.Generic;

namespace ContosoUniversity.BL.Models
{
    public class Instructor
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime HireDate { get; set; }

        public virtual ICollection<CourseInstructor> CourseInstructors { get; set; }
        public virtual OfficeAssignment OfficeAssignment { get; set; }
    }
}
