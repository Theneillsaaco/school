
using School.DAL.Entities;

namespace School.DAL.Interfaces
{
    public interface IDaoOfficeAssignment
    {
        void SaveOfficeAssignment(OfficeAssignment department);
        void UpdateOfficeAssignment(OfficeAssignment department);
        void RemoveOfficeAssignment(OfficeAssignment department);
        OfficeAssignment GetOfficeAssignment(int id);

        List<OfficeAssignment> GetOfficeAssignment();

        bool ExtistsOfficeAssignment(Func<OfficeAssignment, bool> filter);
        List<OfficeAssignment> GetOfficeAssignment(Func<OfficeAssignment, bool> filter);
    }
}
