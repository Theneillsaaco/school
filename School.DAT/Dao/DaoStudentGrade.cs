using School.DAL.Context;
using School.DAL.Entities;
using School.DAL.Enums;
using School.DAL.Exceptions;
using School.DAL.Interfaces;

namespace School.DAL.Dao
{
    public class DaoStudentGrade : IDaoStudentGrade
    {
        private readonly SchoolContext context;
        public DaoStudentGrade(SchoolContext context)
        {
            this.context = context;
        }
        public bool ExtistsStudentGrade(Func<StudentGrade, bool> filter)
        {
            return this.context.StudentGrades.Any(filter);
        }

        public StudentGrade GetStudentGrade(int id)
        {
            return this.context.StudentGrades.Find(id);
        }
        public StudentGrade GetCourse(int id)
        {
            return this.context.StudentGrades.Find(id);
        }
        public List<StudentGrade> GetStudentGrade()
        {
            return this.context.StudentGrades.ToList();
        }

        public List<StudentGrade> GetStudentGrade(Func<StudentGrade, bool> filter)
        {
            return this.context.StudentGrades.Where(filter).ToList();
        }

        public void SaveStudentGrade(StudentGrade studentGrade)
        {
            this.context.StudentGrades.Add(studentGrade);
            this.context.SaveChanges();
        }

        public void UpdateStudentGrade(StudentGrade studentGrade, StudentGrade course)
        {
            string message = string.Empty;

            if (!IsStudentGradeValid(studentGrade, ref message, Operations.Update))
                throw new DaoStudentGradeException(message);

            StudentGrade studentGradeToUpdate = this.GetStudentGrade(studentGrade.StudentId);

            studentGradeToUpdate.Grade = studentGrade.Grade;

            this.context.StudentGrades.Add(studentGradeToUpdate);
            this.context.SaveChanges();
        }
        private bool IsStudentGradeValid(StudentGrade studentGrade, ref string message, Operations operations)
        {
            bool result = false;


            if (operations == Operations.Save)
            {
                if (this.ExtistsStudentGrade(cd => cd.StudentId == studentGrade.StudentId))
                {
                    message = "El departamento ya se encuentra registrado.";
                    return result;
                }
            }

            else
                result = true;

            return result;
        }

        public void UpdateStudentGrade(StudentGrade studentGrade)
        {
            throw new NotImplementedException();
        }
    }
}
