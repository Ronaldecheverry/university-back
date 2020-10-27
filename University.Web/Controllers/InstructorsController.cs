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
    public class InstructorsController : ApiController
    {
        private IMapper mapper;
        private readonly InstructorService instructorService = new InstructorService(new InstructorRepository(UniversityContext.Create()));
        public InstructorsController()
        {

            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();

        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {

            var instructors = await instructorService.GetAll();
            var instructorDTO = instructors.Select(x => mapper.Map<InstructorDTO>(x));

            return Ok(instructorDTO); //status code 200
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {

            var instructor = await instructorService.GetById(id);
            var instructorDTO = mapper.Map<InstructorDTO>(instructor);

            return Ok(instructorDTO); //status code 200
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(InstructorDTO instructorDTO)
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
                var instructor = mapper.Map<Instructor>(instructorDTO);

                instructor = await instructorService.Insert(instructor);
                return Ok(instructorDTO); //status code 200

            }
            catch (Exception ex)
            {

                return InternalServerError(ex); //Status code 500 
            }

        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(InstructorDTO instructorDTO, int id)
        {
            if (!ModelState.IsValid)

                return BadRequest(ModelState);

            if (instructorDTO.ID != id)
                return BadRequest();

            var flag = await instructorService.GetById(id);
            if (flag == null)
                return NotFound(); // status 404 

            try
            {
                var instructor = mapper.Map<Instructor>(instructorDTO);

                instructor = await instructorService.Update(instructor);
                return Ok(instructorDTO); //status code 200

            }
            catch (Exception ex)
            {

                return InternalServerError(ex); //Status code 500 
            }

        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {

            var flag = await instructorService.GetById(id);
            if (flag == null)
                return NotFound(); // status 404 

            try
            {

                await instructorService.Delete(id);
                return Ok(); //status code 200

            }
            catch (Exception ex)
            {

                return InternalServerError(ex); //Status code 500 
            }

        }


    }
}
