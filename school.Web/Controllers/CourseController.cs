using Microsoft.AspNetCore.Mvc;
using school.Web.Models;
using School.DAL.Interfaces;

namespace school.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly IDaoCourse daoCourse;

        public CourseController(IDaoCourse daoCourse) 
        {
            this.daoCourse = daoCourse;
        }


        // GET: CourseController1
        public ActionResult Index()
        {
            var courses = this.daoCourse.GetCourses().Select(cd => new Models.CourseModel(cd));

            return View(courses);
        }

        // GET: CourseController1/Details/5
        public ActionResult Details(int id)
        {
            var course = this.daoCourse.GetCourse(id);
            CourseModel  courseModel = new CourseModel(course);

            return View(courseModel);
        }

        // GET: CourseController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CourseController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CourseController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
