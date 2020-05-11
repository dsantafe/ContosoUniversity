using ContosoUniversity.BL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContosoUniversity.BL.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
            new Student{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01")},
            new Student{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01")},
            new Student{FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")}
            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
            new Course{CourseID=1050,Title="Chemistry",Credits=3},
            new Course{CourseID=4022,Title="Microeconomics",Credits=3},
            new Course{CourseID=4041,Title="Macroeconomics",Credits=3},
            new Course{CourseID=1045,Title="Calculus",Credits=4},
            new Course{CourseID=3141,Title="Trigonometry",Credits=4},
            new Course{CourseID=2021,Title="Composition",Credits=3},
            new Course{CourseID=2042,Title="Literature",Credits=4}
            };
            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
            new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
            new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
            new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},
            new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
            new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.F},
            new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.F},
            new Enrollment{StudentID=3,CourseID=1050},
            new Enrollment{StudentID=4,CourseID=1050},
            new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F},
            new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C},
            new Enrollment{StudentID=6,CourseID=1045},
            new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A},
            };
            foreach (Enrollment e in enrollments)
            {
                context.Enrollments.Add(e);
            }
            context.SaveChanges();

            var instructors = new List<Instructor>
            {
                new Instructor { FirstMidName="Kim",LastName="Abercrombie",HireDate=DateTime.Parse("1995-03-11") },
                new Instructor { FirstMidName="Fadi",LastName="Fakhouri",HireDate=DateTime.Parse("2002-07-06") },
                new Instructor { FirstMidName="Roger",LastName="Harui",HireDate=DateTime.Parse("1998-07-01") },
                new Instructor { FirstMidName="Candace",LastName="Kapoor",HireDate=DateTime.Parse("2001-01-15") },
                new Instructor { FirstMidName="Roger",LastName="Zheng",HireDate=DateTime.Parse("2004-02-12") }
            };

            instructors.ForEach(s => context.Instructors.Add(s));
            context.SaveChanges();

            var departments = new List<Department>
            {
                new Department { Name = "English",     Budget = 350000,StartDate = DateTime.Parse("2007-09-01"),InstructorID  = instructors.Single( i => i.LastName == "Abercrombie").ID },
                new Department { Name = "Mathematics", Budget = 100000,StartDate = DateTime.Parse("2007-09-01"),InstructorID  = instructors.Single( i => i.LastName == "Fakhouri").ID },
                new Department { Name = "Engineering", Budget = 350000,StartDate = DateTime.Parse("2007-09-01"),InstructorID  = instructors.Single( i => i.LastName == "Harui").ID },
                new Department { Name = "Economics",   Budget = 100000,StartDate = DateTime.Parse("2007-09-01"),InstructorID  = instructors.Single( i => i.LastName == "Kapoor").ID }
            };

            departments.ForEach(s => context.Departments.Add(s));
            context.SaveChanges();

            var officeAssignments = new List<OfficeAssignment>
            {
                new OfficeAssignment {InstructorID = instructors.Single( i => i.LastName == "Fakhouri").ID,Location = "Smith 17" },
                new OfficeAssignment {InstructorID = instructors.Single( i => i.LastName == "Harui").ID,Location = "Gowan 27" },
                new OfficeAssignment {InstructorID = instructors.Single( i => i.LastName == "Kapoor").ID,Location = "Thompson 304" }
            };

            officeAssignments.ForEach(s => context.OfficeAssignments.Add(s));
            context.SaveChanges();

            AddOrUpdateInstructor(context, "Chemistry", "Kapoor");
            AddOrUpdateInstructor(context, "Chemistry", "Harui");
            AddOrUpdateInstructor(context, "Microeconomics", "Zheng");
            AddOrUpdateInstructor(context, "Macroeconomics", "Zheng");

            AddOrUpdateInstructor(context, "Calculus", "Fakhouri");
            AddOrUpdateInstructor(context, "Trigonometry", "Harui");
            AddOrUpdateInstructor(context, "Composition", "Abercrombie");
            AddOrUpdateInstructor(context, "Literature", "Abercrombie");

            context.SaveChanges();
        }

        static void AddOrUpdateInstructor(SchoolContext context, string courseTitle, string instructorName)
        {
            var flag = context.CourseInstructors
                .Include(x => x.Course)
                .Include(x => x.Instructor)
                .Where(c => c.Course.Title == courseTitle && c.Instructor.LastName == instructorName)
                .Any();            

            if (!flag)
                context.CourseInstructors.Add(new CourseInstructor {
                    InstructorID = context.Instructors.Single(i => i.LastName == instructorName).ID,
                    CourseID = context.Courses.Single(i => i.Title == courseTitle).CourseID,
                });
        }
    }
}
