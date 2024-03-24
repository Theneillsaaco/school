using School.DAL.core;

namespace School.DAL.Entities
{
    public partial class Instructor : PersonBase
    {
        public int Id { get; set; }
        public DateTime HireDate { get; set; }
    }
}