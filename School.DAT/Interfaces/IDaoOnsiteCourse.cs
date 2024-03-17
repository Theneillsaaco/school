using School.DAL.Entities;

namespace School.DAL.Interfaces
{
    public interface IDaoOnsiteCourse
    {
        void SaveOnsiteCourse(OnsiteCourse onsiteCourse);
        void UpdateOnsiteCourse(OnsiteCourse onsiteCourse);
        void RemoveOnsiteCourse(OnsiteCourse onsiteCourse);
        OnsiteCourse GetOnsiteCourse(int id);

        List<OnsiteCourse> GetOnsiteCourse();

        bool ExtistsOnsiteCourse(Func<OnsiteCourse, bool> filter);
        List<OnsiteCourse> GetDepartments(Func<OnsiteCourse, bool> filter);
    }
}
