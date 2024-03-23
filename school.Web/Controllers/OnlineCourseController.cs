using Microsoft.AspNetCore.Mvc;
using School.DAL.Interfaces;
using school.Web.Models;

namespace school.Web.Controllers
{
    public class OnlineCourseController : Controller
    {
        private readonly IDaoOnlineCourse daoOnlineCourse;
        private readonly IDaoCourse daoCourse;

        public OnlineCourseController(IDaoOnlineCourse daoOnlineCourse, IDaoCourse daoCourse)
        {
            this.daoOnlineCourse = daoOnlineCourse;
            this.daoCourse = daoCourse;
        }


        // GET: OnlineCourseController
        public ActionResult Index()
        {
            var OnlineCourse = this.daoOnlineCourse.GetOnlineCourses()
                                                   .Select(cd => new OnlineCourseModel(cd));
            return View();
        }

        // GET: OnlineCourseController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OnlineCourseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OnlineCourseController/Create
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

        // GET: OnlineCourseController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OnlineCourseController/Edit/5
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

        // GET: OnlineCourseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OnlineCourseController/Delete/5
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
