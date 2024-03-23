using School.DAL.Entities;
using School.DAL.Models;

namespace School.DAL.Interfaces
{
    public interface IDaoStudent
    {
        void SaveStudent(Student student);
        void UpdateStudent(Student student);
        void RemoveStudent(Student student);
        StudentDaoModel GetStudent(int Id);
        List<StudentDaoModel> GetStudent();
        List<StudentDaoModel> GetStudents(Func<Student, bool> filter);
        bool ExistesStudent(Func<Student, bool> filter);
        IEnumerable<StudentDaoModel> GetStudents();
    }
}
