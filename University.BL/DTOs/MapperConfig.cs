using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using University.BL.Models;

namespace University.BL.DTOs
{
    public class MapperConfig
    {
        public static MapperConfiguration MapperConfiguration()
        {

            return new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<Course, CourseDTO>();
                cfg.CreateMap<CourseDTO, Course>();

                cfg.CreateMap<Student, StudentDTO>();
                cfg.CreateMap<StudentDTO, Student>();

                cfg.CreateMap<Enrollment, EnrollmentDTO>();
                cfg.CreateMap<EnrollmentDTO, Enrollment>();

                cfg.CreateMap<Instructor, InstructorDTO>();
                cfg.CreateMap<InstructorDTO, Instructor>();

                cfg.CreateMap<Department, DepartmentDTO>();
                cfg.CreateMap<DepartmentDTO, Department>();

                cfg.CreateMap<OfficeAssignment, OfficeAssignmentDTO>();
                cfg.CreateMap<OfficeAssignmentDTO, OfficeAssignment>();


            });

        }
    }
}
