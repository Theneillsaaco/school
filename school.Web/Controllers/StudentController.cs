using Microsoft.AspNetCore.Mvc;
using school.Web.Models;
using School.DAL.Dao;
using School.DAL.Entities;
using School.DAL.Interfaces;

namespace school.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IDaoStudent daoStudent;

        public StudentController(IDaoStudent daoStudent)
        {
            this.daoStudent = daoStudent;
        }

        // GET: StudentController
        public ActionResult Index()
        {
            var students = this.daoStudent
                              .GetStudents()
                              .Select(cd => new StudentModel()
                              {
                                  FirstName = cd.FirstName,
                                  LastName = cd.LastName,
                                  Id = cd.Id,
                                  EnrollmentDate= cd.EnrollmentDate,
                              });

            return View(students);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int Id)
        {
            var student = this.daoStudent.GetStudent(Id);

            var modelStud = new StudentModel()
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Id = student.Id,
                CreationDate = student.CreationDate,
                EnrollmentDate = student.EnrollmentDate
            };


            return View();
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
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

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentController/Edit/5
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

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentController/Delete/5
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
