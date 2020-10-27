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
    public class OfficeAssignmentsController : ApiController
    {

        private IMapper mapper;
        private readonly OfficeAssignmentService officeAssignmentService = new OfficeAssignmentService(new OfficeAssignmentRepository(UniversityContext.Create()));
        public OfficeAssignmentsController()
        {

            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();

        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {

            var officeAssignment = await officeAssignmentService.GetAll();
            var officeAssignmentDTO = officeAssignment.Select(x => mapper.Map<OfficeAssignmentDTO>(x));

            return Ok(officeAssignmentDTO); //status code 200
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {

            var officeAssignment = await officeAssignmentService.GetById(id);
            var officeAssignmentDTO = mapper.Map<OfficeAssignmentDTO>(officeAssignment);

            return Ok(officeAssignmentDTO); //status code 200
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(OfficeAssignmentDTO officeAssignmentDTO)
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
                var officeAssignment = mapper.Map<OfficeAssignment>(officeAssignmentDTO);

                officeAssignment = await officeAssignmentService.Insert(officeAssignment);
                return Ok(officeAssignmentDTO); //status code 200

            }
            catch (Exception ex)
            {

                return InternalServerError(ex); //Status code 500 
            }

        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(OfficeAssignmentDTO officeAssignmentDTO, int id)
        {
            if (!ModelState.IsValid)

                return BadRequest(ModelState);

            if (officeAssignmentDTO.InstructorID != id)
                return BadRequest();

            var flag = await officeAssignmentService.GetById(id);
            if (flag == null)
                return NotFound(); // status 404 

            try
            {
                var officeAssignment = mapper.Map<OfficeAssignment>(officeAssignmentDTO);

                officeAssignment = await officeAssignmentService.Update(officeAssignment);
                return Ok(officeAssignmentDTO); //status code 200

            }
            catch (Exception ex)
            {

                return InternalServerError(ex); //Status code 500 
            }

        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {

            var flag = await officeAssignmentService.GetById(id);
            if (flag == null)
                return NotFound(); // status 404 

            try
            {

                await officeAssignmentService.Delete(id);
                return Ok(); //status code 200

            }
            catch (Exception ex)
            {

                return InternalServerError(ex); //Status code 500 
            }

        }

    }
}
