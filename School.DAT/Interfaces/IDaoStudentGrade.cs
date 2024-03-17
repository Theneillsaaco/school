
using School.DAL.Entities;

namespace School.DAL.Interfaces
{
    public interface IDaoStudentGrade
    {
        void SaveStudentGrade(StudentGrade studentGrade);
        void UpdateStudentGrade(StudentGrade studentGrade);
        StudentGrade GetStudentGrade(int id);

        List<StudentGrade> GetStudentGrade();

        bool ExtistsStudentGrade(Func<StudentGrade, bool> filter);
        List<StudentGrade> GetStudentGrade(Func<StudentGrade, bool> filter);
    }
}
