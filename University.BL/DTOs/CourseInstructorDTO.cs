using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace University.BL.DTOs
{
    public class CourseInstructorDTO
    {

        [Required(ErrorMessage = "El Campo ID Es Requerido")]
        public int ID { get; set; }


        [Required(ErrorMessage = "El Campo CourseID Es Requerido")]
        public int CourseID { get; set; }

        [Required(ErrorMessage = "El Campo IntructorID Es Requerido")]

        public int InstructorID { get; set; }


        public CourseDTO Course { get; set; }
        public InstructorDTO Instructor { get; set; }
    }
}
