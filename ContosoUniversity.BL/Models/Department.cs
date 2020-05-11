using System;

namespace ContosoUniversity.BL.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }

        public string Name { get; set; }
                
        public decimal Budget { get; set; }
                
        public DateTime StartDate { get; set; }

        public int? InstructorID { get; set; }
                
        public virtual Instructor Instructor { get; set; }        
    }
}
