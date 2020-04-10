using ContosoUniversity.Data;
using ContosoUniversity.Models;

namespace ContosoUniversity.Repositories.Implements
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(SchoolContext schoolContext) : base(schoolContext)
        {

        }
    }
}
