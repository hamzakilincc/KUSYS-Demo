using Microsoft.AspNetCore.Mvc;
using KUSYS_Demo.Entity;

namespace KUSYS_Demo.Controllers
{
    public class StudentController : Controller
    {
        private readonly Context _context;
        public StudentController(Context context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            ViewBag.Courses = _context.Courses.ToList();
            return View(_context.Students.ToList());
        }
        [HttpPost]
        public ActionResult Add(string fName, string lName, string eMail, string Password, DateTime bDate)
        {
            Student s = new Student();
            s.FirstName = fName;
            s.LastName = lName;
            s.EMail = eMail;
            s.Password = Password;
            s.BirthDate = bDate;
            _context.Students.Add(s);
            _context.SaveChanges();
            return RedirectToAction("Index", "Student");
        }
        [HttpPost]
        public ActionResult Edit(int StudentId, string fName, string lName, string eMail, string Password, DateTime bDate)
        {
            Student s = _context.Students.Where(m => m.StudentId == StudentId).First();
            s.FirstName = fName;
            s.LastName = lName;
            s.EMail = eMail;
            s.Password = Password;
            s.BirthDate = bDate;
            _context.SaveChanges();
            return RedirectToAction("Index", "Student");
        }
        [HttpPost]
        public ActionResult Delete(int StudentId)
        {
            Student s = _context.Students.Where(m => m.StudentId == StudentId).First();
            _context.Students.Attach(s);
            _context.Students.Remove(s);
            _context.SaveChanges();
            return RedirectToAction("Index", "Student");
        }
        [HttpPost]
        public ActionResult AddCourse(int courses, int StudentId)
        {
            if (!_context.Enrolleds.Any(m => m.CourseId == courses && m.StudentId == StudentId))
            {
                Enrolled e = new Enrolled();
                e.StudentId = StudentId;
                e.CourseId = courses;
                _context.Enrolleds.Add(e);
                _context.SaveChanges();
                return RedirectToAction("Index", "Student");
            }

            return RedirectToAction("Index", "Student");
        }
        [HttpPost]
        public ActionResult GetCourseList(int StudentId)
        {
            List<Course> courses = _context.Courses.ToList();
            List<Enrolled> e = _context.Enrolleds.Where(m => m.StudentId == StudentId).ToList();
            for (int i = 0; i < e.Count; i++)
            {
                courses.Remove(courses.Where(m => m.CourseId == e[i].CourseId).First());
            }
            ViewBag.Courses = courses;

            return new JsonResult (true);

        }
    }
}
