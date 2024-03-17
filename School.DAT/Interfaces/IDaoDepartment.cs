using School.DAL.Entities;

namespace School.DAL.Interfaces
{
    public interface IDaoDepartment
    {
        void SaveDerpartment(Department department);
        void UpdateDepartment(Department department);
        void RemoveDepartment(Department department);
        Department GetDepartment(int id);

        List<Department> GetDepartments();

        bool ExtistsDepartments(Func<Department, bool> filter);
        List<Department> GetDepartments(Func<Department, bool> filter);
    }
}
