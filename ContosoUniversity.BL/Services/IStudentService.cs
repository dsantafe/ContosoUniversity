using ContosoUniversity.BL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContosoUniversity.BL.Services
{
    public interface IStudentService : IGenericService<Student>
    {
        Task<IEnumerable<Course>> GetCoursesByStudentId(int id);
    }
}
