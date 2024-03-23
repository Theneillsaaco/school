using School.DAL.Entities;
using School.DAL.Models;

namespace School.DAL.Interfaces
{
    public interface IDaoOnlineCourse
    {
        void SaveOnlineCourse(OnlineCourse onlineCourse);
        void UpdateOnlineCourse(OnlineCourse onlineCourse);
        void RemoveOnlineCourse(OnlineCourse onlineCourse);
        OnlineCourseDaoModel GetOnlineCourse(int id);

        List<OnlineCourseDaoModel> GetOnlineCourse();

        bool ExtistsOnlineCourse(Func<OnlineCourse, bool> filter);
        List<OnlineCourseDaoModel> GetOnlineCourses(Func<OnlineCourse, bool> filter);
    }
}
