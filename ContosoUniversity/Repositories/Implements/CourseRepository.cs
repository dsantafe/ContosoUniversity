using ContosoUniversity.Data;
using ContosoUniversity.Models;

namespace ContosoUniversity.Repositories.Implements
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(SchoolContext dbContext) : base(dbContext) { }
    }
}
