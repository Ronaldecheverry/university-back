using System.Data.Entity;
using University.BL.Models;

namespace University.BL.Data
{
    public class UniversityContext : DbContext
    {
        private static UniversityContext universityContext = null;
   
        public UniversityContext() :
            base("UniversityContext")

        {


        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public DbSet<CourseInstructor> CourseInstructors { get; set; }
        public DbSet<Department> Departments { get; set; }

        public static UniversityContext Create() 
        {

            if (universityContext == null)
                universityContext = new UniversityContext();
            return new UniversityContext();
        }


    }
}

//Atajos
//ctrl + k + d formatear
//ctrl + k + c comentamos bloque
//ctrl + k + u descomentamos bloque
//ctrl + k + s rodeamos codigo
//prop (doble tab)
//ctrl + d
//ctor (doble tab) metodo constructor