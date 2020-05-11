using ContosoUniversity.BL.Models;
using ContosoUniversity.BL.Repositories;

namespace ContosoUniversity.BL.Services.Implements
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
