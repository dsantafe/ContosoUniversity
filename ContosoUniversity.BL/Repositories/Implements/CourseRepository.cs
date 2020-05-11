using ContosoUniversity.BL.Data;
using ContosoUniversity.BL.Models;

namespace ContosoUniversity.BL.Repositories.Implements
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(SchoolContext dbContext) : base(dbContext) { }
    }
}
