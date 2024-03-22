using School.DAL.Entities;
using School.DAL.Models;

namespace School.DAL.Interfaces
{
    public interface IDaoCourse
    {
        void SaveCourse(Course course);
        void UpdateCourse(Course course);
        void RemoveCourse(Course course);
        CourseDaoModel GetCourse(int Id);
        List<CourseDaoModel> GetCourses();
        List<CourseDaoModel> GetCourses(Func<Course, bool> filter);
        bool ExistsCourse(Func<Course, bool> filter);
    }
}
