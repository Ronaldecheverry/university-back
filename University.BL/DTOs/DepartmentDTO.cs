﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace University.BL.DTOs
{
    public class DepartmentDTO
    {
        public int DepartmentID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public decimal Budget { get; set; }

        [Required]
        public DateTime StartDate { get; set; }


        public int InstructorID { get; set; }


        public InstructorDTO Instructor { get; set; }

    }
}
