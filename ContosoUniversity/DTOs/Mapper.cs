using AutoMapper;
using ContosoUniversity.Models;

namespace ContosoUniversity.DTOs
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<StudentDTO, Student>();
            CreateMap<Student, StudentDTO>();
        }
    }
}
