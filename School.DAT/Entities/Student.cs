using School.DAL.core;

namespace School.DAL.Entities
{
    public partial class Student : PersonBase
    {
        public int Id { get; set; }

        public DateTime? EnrollmentDate { get; set; }

    }
}