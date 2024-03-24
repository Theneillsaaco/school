using School.DAL.Entities;

namespace School.DAL.Interfaces
{
    public interface IDaoInstructor
    {
        void SaveInstructor(Instructor instructor);
        void UpdateInstructor(Instructor instructor);
        void RemoveInstructor(Instructor instructor);
        Instructor GetInstructor(int id);

        List<Instructor> GetInstructors();

        bool ExtistsInstructor(Func<Instructor, bool> filter);
        List<Instructor> GetInstructors(Func<Instructor, bool> filter);
    }
}