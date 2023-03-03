using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data.Models
{
    public class Course
    {
        public Course()
        {
            StudentsCourses = new List<StudentCourse>();
            Resources = new List<Resource>();
            Homeworks = new List<Homework>();

        }

        [Key]
        public int CourseId { get; set; }


        [Required]
        [MaxLength(80)]
        //UniCode
        public string Name { get; set; }

        //UniCode
        public string? Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        public ICollection<StudentCourse> StudentsCourses { get; set; }

        public ICollection<Resource> Resources { get; set; }

        public ICollection<Homework> Homeworks { get; set; }
    }
}
