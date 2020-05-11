using AutoMapper;
using ContosoUniversity.BL.DTOs;
using ContosoUniversity.BL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Controllers
{
    public class EnrollmentsController : Controller
    {
        private IEnrollmentService enrollmentService;
        private readonly IMapper mapper;

        public EnrollmentsController(IEnrollmentService enrollmentService, 
            IMapper mapper)
        {
            this.enrollmentService = enrollmentService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var data = await enrollmentService.GetAll();

            var listEnrollments = data.Select(x => mapper.Map<EnrollmentDTO>(x)).ToList();

            return View(listEnrollments);
        }
    }
}