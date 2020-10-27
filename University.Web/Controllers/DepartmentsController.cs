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
    public class DepartmentsController : ApiController
    {
       
            private IMapper mapper;
            private readonly DepartmentService departmentService = new DepartmentService(new DepartmentRepository(UniversityContext.Create()));
            public DepartmentsController()
            {

                this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();

            }

            [HttpGet]
            public async Task<IHttpActionResult> Get()
            {

                var departments = await departmentService.GetAll();
                var departmentsDTO = departments.Select(x => mapper.Map<DepartmentDTO>(x));

                return Ok(departmentsDTO); //status code 200
            }

            [HttpGet]
            public async Task<IHttpActionResult> Get(int id)
            {

                var departments = await departmentService.GetById(id);
                var departmentsDTO = mapper.Map<DepartmentDTO>(departments);

                return Ok(departmentsDTO); //status code 200
            }

            [HttpPost]
            public async Task<IHttpActionResult> Post(DepartmentDTO departmentDTO)
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
                    var department = mapper.Map<Department>(departmentDTO);

                department = await departmentService.Insert(department);
                    return Ok(departmentDTO); //status code 200

                }
                catch (Exception ex)
                {

                    return InternalServerError(ex); //Status code 500 
                }

            }

            [HttpPut]
            public async Task<IHttpActionResult> Put(DepartmentDTO departmentDTO, int id)
            {
                if (!ModelState.IsValid)

                    return BadRequest(ModelState);

                if (departmentDTO.DepartmentID != id)
                    return BadRequest();

                var flag = await departmentService.GetById(id);
                if (flag == null)
                    return NotFound(); // status 404 

                try
                {
                    var department = mapper.Map<Department>(departmentDTO);

                department = await departmentService.Update(department);
                    return Ok(departmentDTO); //status code 200

                }
                catch (Exception ex)
                {

                    return InternalServerError(ex); //Status code 500 
                }

            }

            [HttpDelete]
            public async Task<IHttpActionResult> Delete(int id)
            {

                var flag = await departmentService.GetById(id);
                if (flag == null)
                    return NotFound(); // status 404 

                try
                {

                    await departmentService.Delete(id);
                    return Ok(); //status code 200

                }
                catch (Exception ex)
                {

                    return InternalServerError(ex); //Status code 500 
                }

            }


        
    }
}
