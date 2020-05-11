using ContosoUniversity.BL.Models;
using ContosoUniversity.BL.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContosoUniversity.BL.Services.Implements
{
    public class StudentService : GenericService<Student>, IStudentService
    {
        private IStudentRepository studentRepository;

        public StudentService(IStudentRepository studentRepository) : base(studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public async Task<IEnumerable<Course>> GetCoursesByStudentId(int id) {
            return await studentRepository.GetCoursesByStudentId(id);
        }
    }
}
