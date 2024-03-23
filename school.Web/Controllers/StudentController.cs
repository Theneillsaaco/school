using Microsoft.AspNetCore.Mvc;
using school.Web.Models;
using School.DAL.Dao;
using School.DAL.Entities;
using School.DAL.Exceptions;
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


            return View(modelStud);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentModel studentModel)
        {
            try
            {
                Student student = new Student()
                {
                    FirstName = studentModel.FirstName,
                    LastName = studentModel.LastName,
                    CreationUser = 1,
                    CreationDate = DateTime.Now,
                    EnrollmentDate = DateTime.Now
                };

                this.daoStudent.SaveStudent(student);
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
            var student = this.daoStudent.GetStudent(id);

            var modelStud = new StudentModel()
            {
                Id = student.Id,
                LastName = student.LastName,
                FirstName = student.FirstName,
                EnrollmentDate = student.EnrollmentDate,
            };

            return View(modelStud);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentModel studentModel)
        {
            try
            {
                Student student = new Student()
                {
                    Id = studentModel.Id,
                    LastName = studentModel.LastName,
                    FirstName = studentModel.FirstName,
                    EnrollmentDate = studentModel.EnrollmentDate,
                    ModifyDate = DateTime.Now,
                    UserMod = 1

                };

                this.daoStudent.UpdateStudent(student);
                return RedirectToAction(nameof(Index));
            }
            catch (DaoStudentException daoEx)
            {
                ViewBag.Message = daoEx.Message; 
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
