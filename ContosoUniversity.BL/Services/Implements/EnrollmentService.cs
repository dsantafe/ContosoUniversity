using ContosoUniversity.BL.Models;
using ContosoUniversity.BL.Repositories;
using System.Threading.Tasks;

namespace ContosoUniversity.BL.Services.Implements
{
    public class EnrollmentService : GenericService<Enrollment>, IEnrollmentService
    {
        private IEnrollmentRepository enrollmentRepository;

        public EnrollmentService(IEnrollmentRepository enrollmentRepository) : base(enrollmentRepository)
        {
            this.enrollmentRepository = enrollmentRepository;
        }        
    }
}
