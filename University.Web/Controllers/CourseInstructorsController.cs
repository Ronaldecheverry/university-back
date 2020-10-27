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
    public class CourseInstructorsController : ApiController
    {

        private IMapper mapper;
        private readonly CourseInstructorService courseInstructorService = new CourseInstructorService(new CourseInstructorRepository(UniversityContext.Create()));
        public CourseInstructorsController()
        {

            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();

        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {

            var courseInstructors = await courseInstructorService.GetAll();
            var coursesInstructorsDTO = courseInstructors.Select(x => mapper.Map<CourseInstructorDTO>(x));

            return Ok(coursesInstructorsDTO); //status code 200
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {

            var courseInstructors = await courseInstructorService.GetById(id);
            var coursesInstructorsDTO = mapper.Map<CourseInstructorDTO>(courseInstructors);

            return Ok(coursesInstructorsDTO); //status code 200
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(CourseInstructorDTO courseInstructorDTO)
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
                var courseInstructors = mapper.Map<CourseInstructor>(courseInstructorDTO);

                courseInstructors = await courseInstructorService.Insert(courseInstructors);
                return Ok(courseInstructorDTO); //status code 200

            }
            catch (Exception ex)
            {

                return InternalServerError(ex); //Status code 500 
            }

        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(CourseInstructorDTO courseInstructorDTO, int id)
        {
            if (!ModelState.IsValid)

                return BadRequest(ModelState);

            if (courseInstructorDTO.ID != id)
                return BadRequest();

            var flag = await courseInstructorService.GetById(id);
            if (flag == null)
                return NotFound(); // status 404 

            try
            {
                var courseInstructors = mapper.Map<CourseInstructor>(courseInstructorDTO);

                courseInstructors = await courseInstructorService.Update(courseInstructors);
                return Ok(courseInstructorDTO); //status code 200

            }
            catch (Exception ex)
            {

                return InternalServerError(ex); //Status code 500 
            }

        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {

            var flag = await courseInstructorService.GetById(id);
            if (flag == null)
                return NotFound(); // status 404 

            try
            {

                await courseInstructorService.Delete(id);
                return Ok(); //status code 200

            }
            catch (Exception ex)
            {

                return InternalServerError(ex); //Status code 500 
            }

        }

    }
}
