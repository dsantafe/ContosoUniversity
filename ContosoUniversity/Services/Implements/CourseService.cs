using ContosoUniversity.Models;
using ContosoUniversity.Repositories;

namespace ContosoUniversity.Services.Implements
{
    public class CourseService : GenericService<Course>, ICourseService
    {
        private ICourseRepository courseRepository;

        public CourseService(ICourseRepository courseRepository) : base(courseRepository)
        {
            this.courseRepository = courseRepository;
        }
    }
}
