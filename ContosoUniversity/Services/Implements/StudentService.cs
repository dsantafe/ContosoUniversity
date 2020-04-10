using ContosoUniversity.Models;
using ContosoUniversity.Repositories;

namespace ContosoUniversity.Services.Implements
{
    public class StudentService : GenericService<Student>, IStudentService
    {
        private IStudentRepository studentRepository;

        public StudentService(IStudentRepository studentRepository) : base(studentRepository)
        {
            this.studentRepository = studentRepository;
        }
    }
}
