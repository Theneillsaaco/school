using School.DAL.Entities;

namespace School.DAL.Interfaces
{
    internal interface IDaoStudent
    {
        void SaveStudent(Student student);
        void UpdateStudent(Student student);    
        void RemoveStudent(Student student);
        Student GetStudent(int Id);
        List<Student> GetStudent(); 
        List<Student> GetStudents(Func<Student, bool>filter);
        bool ExistesStudent(Func<Student, bool>filter);
    }
}
