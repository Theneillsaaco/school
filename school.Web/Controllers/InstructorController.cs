using Microsoft.AspNetCore.Mvc;
using school.Web.Models;
using School.DAL.Entities;
using School.DAL.Exceptions;
using School.DAL.Interfaces;

namespace school.Web.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IDaoInstructor daoInstructor;

        public InstructorController(IDaoInstructor daoInstructor)
        {
            this.daoInstructor = daoInstructor;
        }

        // GET: StudentController
        public ActionResult Index()
        {
            var instructors = this.daoInstructor
                              .GetInstructors()
                              .Select(cd => new InstructorModel()
                              {
                                  FirstName = cd.FirstName,
                                  LastName = cd.LastName,
                                  Id = cd.Id,
                                  HireDate = cd.HireDate
                              });

            return View(instructors);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int Id)
        {
            var instructor = this.daoInstructor.GetInstructor(Id);

            var modelInst = new InstructorModel()
            {
                FirstName = instructor.FirstName,
                LastName = instructor.LastName,
                Id = instructor.Id,
                CreationDate = instructor.CreationDate,
                HireDate= instructor.HireDate
            };


            return View(modelInst);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InstructorModel instructorModel)
        {
            try
            {
                Instructor instructor = new Instructor()
                {
                    FirstName = instructorModel.FirstName,
                    LastName = instructorModel.LastName,
                    CreationUser = 1,
                    CreationDate = DateTime.Now,
                    HireDate = instructorModel.HireDate
                };

                this.daoInstructor.SaveInstructor(instructor);
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
            var instructor = this.daoInstructor.GetInstructor(id);

            var modelInst = new InstructorModel()
            {
                Id = instructor.Id,
                LastName = instructor.LastName,
                FirstName = instructor.FirstName,
                HireDate = instructor.HireDate
            };

            return View(modelInst);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InstructorModel instructorModel)
        {
            try
            {
                Instructor instructor = new Instructor()
                {
                    Id = instructorModel.Id,
                    LastName = instructorModel.LastName,
                    FirstName = instructorModel.FirstName,
                    HireDate = instructorModel.HireDate,
                    ModifyDate = DateTime.Now,
                    UserMod = 1
                };

                this.daoInstructor.UpdateInstructor(instructor);
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
