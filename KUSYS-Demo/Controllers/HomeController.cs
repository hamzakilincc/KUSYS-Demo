using KUSYS_Demo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using KUSYS_Demo.Entity;


namespace KUSYS_Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly Context _context;
        public HomeController(Context context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            List<Enrolled> enrolleds = _context.Enrolleds.ToList();
            List<Student> students = _context.Students.ToList();
            List<Course> courses = _context.Courses.ToList();
            List<Enrolled> enrolledsReturn = new List<Enrolled>();
            for (int i = 0; i < enrolleds.Count; i++)
            {
                Enrolled e = new Enrolled();
                e.CourseId = enrolleds[i].CourseId;
                e.StudentId = enrolleds[i].StudentId;
                e.Course = courses.Where(m => m.CourseId == enrolleds[i].CourseId).First();
                e.Student = students.Where(m => m.StudentId == enrolleds[i].StudentId).First();
                enrolledsReturn.Add(e);
            }
            return View(enrolledsReturn);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}