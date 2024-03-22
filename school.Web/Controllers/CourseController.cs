using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using school.Web.Models;
using School.DAL.Interfaces;
using School.DAL.Entities;

namespace school.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly IDaoCourse daoCourse;
        private readonly IDaoDepartment daoDepartment;

        public CourseController(IDaoCourse daoCourse, IDaoDepartment daoDepartment) 
        {
            this.daoCourse = daoCourse;
            this.daoDepartment = daoDepartment;
        }


        // GET: CourseController1
        public ActionResult Index()
        {
            var courses = this.daoCourse.GetCourses()
                                        .Select(cd => new CourseModel(cd));

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
            var course = this.daoCourse.GetCourse(id);
            CourseModel courseModel = new CourseModel(course);

            var departmentList = this.daoDepartment.GetDepartments()
                                                   .Select(cd => new DepartmentList() 
                                                   {
                                                       DepartmentId = cd.DepartmentId,
                                                       Name = cd.Name
                                                   })
                                                   .ToList();

            ViewData["Departments"] = new SelectList(departmentList, "DepartmentId", "Name");

            return View(courseModel);
        }

        // POST: CourseController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CourseModel courseModel)
        {
            try
            {
                this.daoCourse.UpdateCourse(new Course()
                {
                    CourseId = courseModel.CourseId,
                    ModifyDate = DateTime.Now,
                    DepartmentId = courseModel.DepartmentId,
                    Credits = courseModel.Credits,
                    UserMod = 1,
                    Title = courseModel.Title
                });
   
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
