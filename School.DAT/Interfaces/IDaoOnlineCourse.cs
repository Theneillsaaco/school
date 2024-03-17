using School.DAL.Entities;

namespace School.DAL.Interfaces
{
    public interface IDaoOnlineCourse
    {
        void SaveOnlineCourse(OnlineCourse onlineCourse);
        void UpdateOnlineCourse(OnlineCourse onlineCourse);
        void RemoveOnlineCourse(OnlineCourse onlineCourse);
        OnlineCourse GetOnlineCourset(int id);

        List<OnlineCourse> GetOnlineCourse();

        bool ExtistsOnlineCourse(Func<OnlineCourse, bool> filter);
        List<OnlineCourse> GetOnlineCourse(Func<OnlineCourse, bool> filter);
    }
}
