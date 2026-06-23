using System;
using System.Collections.Generic;
using System.Text;

namespace StudentCourseDemo
{
    public class Courses
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public int Duration { get; set; }
     
        public decimal Fee { get;  set; }
    }
}
