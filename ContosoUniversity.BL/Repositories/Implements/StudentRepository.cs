using ContosoUniversity.BL.Data;
using ContosoUniversity.BL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.BL.Repositories.Implements
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly SchoolContext schoolContext;

        public StudentRepository(SchoolContext schoolContext) : base(schoolContext)
        {
            this.schoolContext = schoolContext;
        }

        public async Task<IEnumerable<Course>> GetCoursesByStudentId(int id) {

            var listCourses = await schoolContext.Enrollments
                .Include(x => x.Course)
                .Where(x => x.StudentID == id)
                .Select(x => x.Course)
                .ToListAsync();

            return listCourses;
        }

        public new async Task Delete(int id)
        {
            var entity = await GetById(id);

            if (entity == null)
                throw new Exception("The entity is null");            

            var flag = schoolContext.Enrollments.Any(x => x.StudentID == id);

            if (flag)
                throw new Exception("The student have enrollments");

            schoolContext.Students.Remove(entity);
            await schoolContext.SaveChangesAsync();
        }
    }
}
