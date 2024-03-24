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
        // GET: InstructorController
        public ActionResult Index()
        {
            var instructor = this.daoInstructor
                                 .GetInstructors()
                                 .Select(cd => new InstructorModel()
                                 {
                                     FirstName = cd.FirstName,
                                     LastName = cd.LastName,
                                     Id = cd.Id,
                                     HireDate = cd.HireDate,
                                 });

            return View(instructor);
        }

        // GET: InstructorController/Details/5
        public ActionResult Details(int id)
        {
            var instructor = this.daoInstructor.GetInstructor(id);

            var modelInst = new InstructorModel()
            {
                FirstName = instructor.FirstName,
                LastName = instructor.LastName,
                Id = instructor.Id,
                HireDate = instructor.HireDate,
                CreationDate = instructor.CreationDate
            };

            return View(modelInst);
        }

        // GET: InstructorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InstructorController/Create
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

        // GET: InstructorController/Edit/5
        public ActionResult Edit(int id)
        {
            var instructor = this.daoInstructor.GetInstructor(id);

            var modelInst = new InstructorModel() 
            {
                FirstName = instructor.FirstName,
                LastName = instructor.LastName,
                HireDate=instructor.HireDate
            };

            return View(modelInst);
        }

        // POST: InstructorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InstructorModel instructorModel)
        {
            try
            {
                Instructor instructor = new Instructor() 
                {
                    FirstName = instructorModel.FirstName,
                    LastName = instructorModel.LastName,
                    HireDate = instructorModel.HireDate,
                    ModifyDate = DateTime.Now,
                    UserMod = 1
                };

                this.daoInstructor.UpdateInstructor(instructor);
                return RedirectToAction(nameof(Index));
            }
            catch (DaoInstructorException daoEx)
            {
                ViewBag.Message = daoEx.Message;
                return View();
            }
        }

        // GET: InstructorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InstructorController/Delete/5
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
