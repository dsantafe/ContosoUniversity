using ContosoUniversity.BL.Data;
using ContosoUniversity.BL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContosoUniversity.BL.Repositories.Implements
{
    public class EnrollmentRepository : GenericRepository<Enrollment>, IEnrollmentRepository
    {
        private readonly SchoolContext schoolContext;

        public EnrollmentRepository(SchoolContext schoolContext) : base(schoolContext)
        {
            this.schoolContext = schoolContext;
        }

        public new async Task<List<Enrollment>> GetAll()
        {
            var listEnrollments = await schoolContext.Enrollments.Include(x => x.Course)
                .Include(x => x.Student)
                .ToListAsync();

            return listEnrollments;
        }
    }
}
