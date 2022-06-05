using System.ComponentModel.DataAnnotations;
namespace KUSYS_Demo.Entity
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }
}
