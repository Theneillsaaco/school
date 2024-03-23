using Microsoft.AspNetCore.Mvc;
using School.Web.Models;
using School.DAL.Entities;
using School.DAL.Exceptions;
using School.DAL.Interfaces;


namespace School.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDaoDepartment daoDepartment;

        public DepartmentController(IDaoDepartment daoDepartment)
        {
            this.daoDepartment = daoDepartment;
        }
        // GET: DepartmentController
        public ActionResult Index()
        {
            var departments = this.daoDepartment
                                  .GetDepartments()
                                  .Select(cd => new DepartamentGetModel()
                                  {
                                      Administrator = cd.Administrator,
                                      Budget = cd.Budget,
                                      DepartmentId = cd.DepartmentId,
                                      Name = cd.Name,
                                      StartDate = cd.StartDate
                                  });

            return View(departments);
        }

        // GET: DepartmentController/Details/5
        public ActionResult Details(int id)
        {

            var department = this.daoDepartment.GetDepartment(id);

            var modelDepto = new DepartamentGetModel()
            {
                DepartmentId = department.DepartmentId,
                Administrator = department.Administrator,
                Budget = department.Budget,
                Name = department.Name,
                StartDate = department.StartDate
            };


            return View(modelDepto);
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DepartamentGetModel departmentModel)
        {
            try
            {
                Department department = new Department()
                {
                    Administrator = departmentModel.Administrator,
                    Name = departmentModel.Name,
                    Budget = departmentModel.Budget,
                    CreationUser = 1,
                    CreationDate = DateTime.Now,
                    StartDate = departmentModel.StartDate
                };

                this.daoDepartment.SaveDerpartment(department);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id, string name)
        {
            var department = this.daoDepartment.GetDepartment(id);

            var modelDepto = new DepartamentGetModel()
            {
                DepartmentId = department.DepartmentId,
                Administrator = department.Administrator,
                Budget = department.Budget,
                Name = department.Name,
                StartDate = department.StartDate
            };

            return View(modelDepto);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DepartamentGetModel departmentModel)
        {
            try
            {
                Department department = new Department()
                {
                    Administrator = departmentModel.Administrator,
                    Name = departmentModel.Name,
                    Budget = departmentModel.Budget,
                    UserMod = 1,
                    StartDate = departmentModel.StartDate,
                    DepartmentId = departmentModel.DepartmentId,
                    ModifyDate = DateTime.Now

                };

                this.daoDepartment.UpdateDepartment(department);
                return RedirectToAction(nameof(Index));
            }
            catch (DaoDepartmentException daoEx)
            {
                ViewBag.Message = daoEx.Message;
                return View();
            }
        }

    }
}