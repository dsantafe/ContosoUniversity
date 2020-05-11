using AutoMapper;
using ContosoUniversity.BL.Models;

namespace ContosoUniversity.BL.DTOs
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<StudentDTO, Student>();
            CreateMap<Student, StudentDTO>();

            CreateMap<EnrollmentDTO, Enrollment>();
            CreateMap<Enrollment, EnrollmentDTO>();

            CreateMap<CourseDTO, Course>();
            CreateMap<Course, CourseDTO>();
        }
    }
}
