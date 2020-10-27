using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using University.BL.Data;
using University.BL.DTOs;
using University.BL.Models;
using University.BL.Repositories.Implements;
using University.BL.Services.Implements;

namespace University.Web.Controllers
{
    public class EnrollmentsController : ApiController
    {
        private IMapper mapper;
        private readonly EnrollmentService enrollmentService = new EnrollmentService(new EnrollmentRepository(UniversityContext.Create()));
        public EnrollmentsController()
        {

            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();

        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {

            var enrollment = await enrollmentService.GetAll();
            var enrollmentDTO = enrollment.Select(x => mapper.Map<EnrollmentDTO>(x));

            return Ok(enrollmentDTO); //status code 200
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {

            var enrollment = await enrollmentService.GetById(id);
            var enrollmentDTO = mapper.Map<EnrollmentDTO>(enrollment);

            return Ok(enrollmentDTO); //status code 200
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(EnrollmentDTO enrollmentDTO)
        {
            if (!ModelState.IsValid)

                return BadRequest(ModelState);

            //var course = new Course
            //{
            //    CourseID = courseDTO.CourseID,
            //    Title = courseDTO.Title,
            //    Credits = courseDTO.Credits

            //};

            try
            {
                var enrollment = mapper.Map<Enrollment>(enrollmentDTO);

                enrollment = await enrollmentService.Insert(enrollment);
                return Ok(enrollmentDTO); //status code 200

            }
            catch (Exception ex)
            {

                return InternalServerError(ex); //Status code 500 
            }

        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(EnrollmentDTO enrollmentDTO, int id)
        {
            if (!ModelState.IsValid)

                return BadRequest(ModelState);

            if (enrollmentDTO.EnrollmentID != id)
                return BadRequest();

            var flag = await enrollmentService.GetById(id);
            if (flag == null)
                return NotFound(); // status 404 

            try
            {
                var enrollment = mapper.Map<Enrollment>(enrollmentDTO);

                enrollment = await enrollmentService.Update(enrollment);
                return Ok(enrollmentDTO); //status code 200

            }
            catch (Exception ex)
            {

                return InternalServerError(ex); //Status code 500 
            }

        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {

            var flag = await enrollmentService.GetById(id);
            if (flag == null)
                return NotFound(); // status 404 

            try
            {

                await enrollmentService.Delete(id);
                return Ok(); //status code 200

            }
            catch (Exception ex)
            {

                return InternalServerError(ex); //Status code 500 
            }

        }
    }
}
