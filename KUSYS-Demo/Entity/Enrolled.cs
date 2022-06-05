using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace KUSYS_Demo.Entity
{
    public class Enrolled
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("CourseId")]
        public Course Course { get; set; }  
        public int CourseId { get; set; }
        [ForeignKey("StudentId")]
        public Student Student { get; set; }
        public int StudentId { get; set; }
    }
}
