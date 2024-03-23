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

        List<OnlineCourseDaoModel> GetOnlineCourses();

        List<OnlineCourseDaoModel> GetOnlineCourses(Func<OnlineCourse, bool> filter);

        bool ExtistsOnlineCourse(Func<OnlineCourse, bool> filter);
    }
}
