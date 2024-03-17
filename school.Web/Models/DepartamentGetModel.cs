
namespace School.Web.Models
{
    public class DepartamentGetModel
    {
        public int DepartmentId { get; set; }
        public string? Name { get; set; }
        public decimal Budget { get; set; }
        public int? Administrator { get; set; }
        public DateTime StartDate {  get; set; }
    }
}
