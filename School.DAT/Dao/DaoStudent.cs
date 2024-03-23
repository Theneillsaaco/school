using School.DAL.Context;
using School.DAL.Entities;
using School.DAL.Exceptions;
using School.DAL.Interfaces;
using School.DAL.Enums;
using School.DAL.Models;
using System.Linq;

namespace School.DAL.Dao
{
    public class DaoStudent : IDaoStudent
    {
        private readonly SchoolContext context;
        public DaoStudent(SchoolContext context)
        {
            this.context = context;
        }

        public bool ExistesStudent(Func<Student, bool> filter)
        {
            return this.context.Students.Any(filter);
        }

        public StudentDaoModel GetStudent(int Id)
        {
            StudentDaoModel? studentDaoModel = new StudentDaoModel();
            try
            {
                studentDaoModel = (from Student in this.context.Students
                                   where Student.Deleted == false
                                   && Student.Id == Id
                                   select new StudentDaoModel()
                                   {
                                       CreationDate = Student.CreationDate,
                                       LastName = Student.LastName,
                                       FirstName = Student.FirstName,
                                       Id = Student.Id,
                                       EnrollmentDate = Student.EnrollmentDate
                                   }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new DaoStudentException($"Error, no se pudo obtener el curso: {ex.Message}");
            }
            return studentDaoModel;
        }

        public List<StudentDaoModel> GetStudent()
        {
            List<StudentDaoModel>? querry = new List<StudentDaoModel>();
            try
            {
                querry = (from depto in this.context.Students
                               where depto.Deleted == false
                               select new StudentDaoModel()
                               {
                                   CreationDate = depto.CreationDate,
                                   LastName = depto.LastName,
                                   FirstName = depto.FirstName,
                                   Id = depto.Id,
                                   EnrollmentDate = depto.EnrollmentDate
                               }).ToList();

            }
            catch (Exception ex)
            {

                throw new DaoStudentException($"Error, no se pudo obtener el curso: {ex.Message}");
            }

            return querry;
        }

        public List<StudentDaoModel> GetStudents(Func<Student, bool> filter)
        {
            List<StudentDaoModel>? studentList = new List<StudentDaoModel>();

            try
            {
                var student = this.context.Students.Where(filter).ToList();
            }
            catch (Exception ex)
            {

                throw new DaoStudentException($"Error, no se pudo obtener el curso: {ex.Message}");
            }

            return studentList;
        }

        public IEnumerable<StudentDaoModel> GetStudents()
        {
            throw new NotImplementedException();
        }

        public void RemoveStudent(Student student)
        {

        }

        public void SaveStudent(Student student)
        {
            try
            {
                this.context.Students.Add(student);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new DaoStudentException(ex.Message);
            }

        }

        public void UpdateStudent(Student student)
        {
            string message = string.Empty;

            if (!IsStudentsValid(student, ref message, Operations.Update))
                throw new DaoStudentException(message);

            Student? studentToUpdate = this.context.Students.Find(student.Id);

            if (student is null)
                throw new DaoStudentException("No se encotro el curso.");

            studentToUpdate.ModifyDate = student.ModifyDate;
            studentToUpdate.LastName = student.LastName;
            studentToUpdate.UserMod = student.UserMod;
            studentToUpdate.FirstName = student.FirstName;


            this.context.Students.Update(studentToUpdate);
            this.context.SaveChanges();
        }

        private bool IsStudentsValid(Student student, ref string message, Operations operations)
        {
            bool result = false;

            if (string.IsNullOrEmpty(student.FirstName))
            {
                message = "Se requiere un nombre";
                return true;
            }
            if (student.FirstName.Length > 50)
            {
                message = "El nombre es demaciado largo, El limite es 50 caracteres.";
                return true;
            }
            if (string.IsNullOrEmpty(student.LastName))
            {
                message = "Se requiere un apellido";
                return true;
            }
            if (student.LastName.Length > 50)
            {
                message = "El apellido es demaciado largo, El limite es 50 caracteres.";
                return true;
            }
            if (operations == Operations.Save)
            {
            }
            else
                result = true;

            return result;
        }
    }
}
