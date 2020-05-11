using ContosoUniversity.BL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContosoUniversity.BL.Repositories
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Task<IEnumerable<Course>> GetCoursesByStudentId(int id);
    }
}
