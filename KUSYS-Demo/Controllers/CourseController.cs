using Microsoft.AspNetCore.Mvc;
using KUSYS_Demo.Entity;


namespace KUSYS_Demo.Controllers
{
    public class CourseController : Controller
    {
        private readonly Context _context;
        public CourseController(Context context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            return View(_context.Courses.ToList());
        }
        [HttpPost]
        public ActionResult Add(string cName)
        {
            Course c = new Course();
            c.CourseName = cName;
            _context.Courses.Add(c);
            _context.SaveChanges();
            return RedirectToAction("Index", "Course");
        }
        [HttpPost]
        public ActionResult Edit(int CourseId, string cName)
        {
            Course c = _context.Courses.Where(m => m.CourseId == CourseId).First();
            c.CourseName = cName;
            _context.SaveChanges();
            return RedirectToAction("Index", "Course");
        }
        [HttpPost]
        public ActionResult Delete(int CourseId)
        {
            Course c = _context.Courses.Where(m => m.CourseId == CourseId).First();
            _context.Courses.Attach(c);
            _context.Courses.Remove(c);
            _context.SaveChanges();
            return RedirectToAction("Index", "Course");
        }
    }
}
