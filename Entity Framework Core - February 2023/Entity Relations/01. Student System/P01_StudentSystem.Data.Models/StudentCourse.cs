using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data.Models
{
    public class StudentCourse
    {
        
        [Required]
        public Student? Student { get; set; }

        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }


        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }

        [Required]
        public Course? Course { get; set; }

    }
}
