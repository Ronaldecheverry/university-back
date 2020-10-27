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
    public class StudentsController : ApiController
    {
        private IMapper mapper;
        private readonly StudentService studentService = new StudentService(new StudentRepository(UniversityContext.Create()));
        public StudentsController()
        {

            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();

        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {

            var students = await studentService.GetAll();
            var studentsDTO = students.Select(x => mapper.Map<StudentDTO>(x));

            return Ok(studentsDTO); //status code 200
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {

            var student = await studentService.GetById(id);
            var studentsDTO = mapper.Map<StudentDTO>(student);

            return Ok(studentsDTO); //status code 200
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(StudentDTO studentDTO)
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
                var student = mapper.Map<Student>(studentDTO);

                student = await studentService.Insert(student);
                return Ok(studentDTO); //status code 200

            }
            catch (Exception ex)
            {

                return InternalServerError(ex); //Status code 500 
            }

        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(StudentDTO studentDTO, int id)
        {
            if (!ModelState.IsValid)

                return BadRequest(ModelState);

            if (studentDTO.ID != id)
                return BadRequest();

            var flag = await studentService.GetById(id);
            if (flag == null)
                return NotFound(); // status 404 

            try
            {
                var student = mapper.Map<Student>(studentDTO);

                student = await studentService.Update(student);
                return Ok(studentDTO); //status code 200

            }
            catch (Exception ex)
            {

                return InternalServerError(ex); //Status code 500 
            }

        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {

            var flag = await studentService.GetById(id);
            if (flag == null)
                return NotFound(); // status 404 

            try
            {

                await studentService.Delete(id);
                return Ok(); //status code 200

            }
            catch (Exception ex)
            {

                return InternalServerError(ex); //Status code 500 
            }

        }


    }
}

