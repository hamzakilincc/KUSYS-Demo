using System.ComponentModel.DataAnnotations;
namespace KUSYS_Demo.Entity
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
