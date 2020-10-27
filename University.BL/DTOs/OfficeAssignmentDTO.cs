using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace University.BL.DTOs
{
    public class OfficeAssignmentDTO
    {

        [Required(ErrorMessage = "El campo IntructorID es requerido")]

        public int InstructorID { get; set; }



        [Required(ErrorMessage = "El campo Location es requerido")]

        public string Location { get; set; }

       

        public InstructorDTO Instructor { get; set; }

       
    }
}
