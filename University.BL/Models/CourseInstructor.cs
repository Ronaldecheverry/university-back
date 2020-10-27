using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.BL.Models
{
    [Table("CourseInstructor", Schema = "dbo")]
    public class CourseInstructor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [ForeignKey("Course")]
        public int CourseID { get; set; }

        [ForeignKey("Instructor")]
        public int InstructorID { get; set; }

        public Course Course { get; set; }

        public Instructor Instructor { get; set; }
    }
}
