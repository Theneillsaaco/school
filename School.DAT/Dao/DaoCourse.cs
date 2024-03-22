using School.DAL.Context;
using School.DAL.Entities;
using School.DAL.Exceptions;
using School.DAL.Interfaces;
using School.DAL.Enums;
using School.DAL.Models;

namespace School.DAL.Dao 
{
    public class DaoCourse : IDaoCourse
    {
        private readonly SchoolContext context;
        public DaoCourse(SchoolContext context)
        {
            this.context = context;
        }

        public bool ExistsCourse(Func<Course, bool> filter)
        {
            return this.context.Course.Any(filter);
        }

        public CourseDaoModel GetCourse(int Id)
        {
            CourseDaoModel? courseDaoModel = new CourseDaoModel();
            try
            {
                 courseDaoModel = (from Course in this.context.Course
                             join depto in this.context.Departments on Course.DepartmentId 
                                                                    equals depto.DepartmentId
                             where Course.Deleted == false
                                && Course.CourseId == Id
                             select new CourseDaoModel()
                             {
                                 CourseId = Course.CourseId,
                                 CreatedDate = Course.CreationDate,
                                 Credits = Course.Credits,
                                 DepartmentId = Course.DepartmentId,
                                 DepartmentName = depto.Name,
                                 Title = Course.Title

                             }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new DaoCourseException($"Error, no se pudo obtener el curso: {ex.Message}");
            }
            return courseDaoModel;
        }

        public List<CourseDaoModel> GetCourses()
        {
            List<CourseDaoModel>? courseList = new List<CourseDaoModel>();
            try
            {
                courseList = (from Course in this.context.Course
                                  join depto in this.context.Departments on Course.DepartmentId
                                                                         equals depto.DepartmentId
                                  where Course.Deleted == false
                                  select new CourseDaoModel()
                                  {
                                      CourseId = Course.CourseId,
                                      CreatedDate = Course.CreationDate,
                                      Credits = Course.Credits,
                                      DepartmentId = Course.DepartmentId,
                                      DepartmentName = depto.Name,
                                      Title = Course.Title

                                  }).ToList();
            }
            catch (Exception ex)
            {
                throw new DaoCourseException($"Error, no se pudo obtener el curso: {ex.Message}");
            }
            return courseList;
        }

        public List<CourseDaoModel> GetCourses(Func<Course, bool> filter)
        {
            List<CourseDaoModel>? courseList = new List<CourseDaoModel>();

            try
            {
                var course = this.context.Course.Where(filter);

                courseList = (from Course in course
                             join depto in this.context.Departments on Course.DepartmentId 
                                                                 equals depto.DepartmentId
                             where Course.Deleted == false
                             orderby Course.CreationDate descending
                             select new CourseDaoModel() 
                             {
                                 CourseId = Course.CourseId,
                                 CreatedDate = Course.CreationDate,
                                 Credits = Course.Credits,
                                 DepartmentId = Course.DepartmentId,
                                 DepartmentName = depto.Name,
                                 Title = Course.Title

                             }).ToList();

            }
            catch (Exception ex)
            {
                throw new DaoCourseException($"Error, no se pudo obtener el curso: {ex.Message}");
            }
            return courseList;
        }

        public void RemoveCourse(Course course)
        {

        }

        public void SaveCourse(Course course)
        {
            try
            {
                this.context.Course.Add(course);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new DaoCourseException(ex.Message);
            }
        }

        public void UpdateCourse(Course course)
        {
            string message = string.Empty;

            if (!IsCourseValid(course, ref message, Operations.Update))
                throw new DaoCourseException(message);

            Course? courseToUpdate = this.context.Course.Find(course.CourseId);

            if (course is null)
                throw new DaoCourseException("No se encotro el curso.");
            

            courseToUpdate.ModifyDate = course.ModifyDate;
            courseToUpdate.Title = course.Title;
            courseToUpdate.Credits = course.Credits;
            courseToUpdate.UserMod = course.UserMod;
            courseToUpdate.DepartmentId = course.DepartmentId;

            this.context.Course.Update(courseToUpdate);
            this.context.SaveChanges();
        }

        private bool IsCourseValid(Course course, ref string message, Operations operations)
        {
            bool result = false;

            if (string.IsNullOrEmpty(course.Title))
            {
                message = "El titulo del course es requerido.";
                return true;
            }
            if (course.Title.Length > 100)
            {
                message = "El titulo es demaciado largo, El limite es 100 caracteres.";
                return true;
            }

            
            if (course.Credits == 0)
            {
                message = "El credito no puede ser 0.";
                return true;
            }
            if (operations == Operations.Save)
            {
                if (this.ExistsCourse(cd => cd.Title == course.Title))
                {
                    message = "El nombre ya existe.";
                    return true;
                }
            }
            else
                result = true;

            return result;
        }
    }
}
