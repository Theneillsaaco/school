using School.DAL.Entities;
using School.DAL.Models;

namespace School.DAL.Interfaces
{
    public interface IDaoStudent
    {
        void SaveStudent(Student student);
        void UpdateStudent(Student student);
        void RemoveStudent(Student student);
        Student GetStudent(int Id);
        List<Student> GetStudents();
        List<StudentDaoModel> GetStudents(Func<Student, bool> filter);
        bool ExistesStudent(Func<Student, bool> filter);
    }
}
