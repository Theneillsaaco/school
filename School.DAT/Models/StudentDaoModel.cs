namespace School.DAL.Models
{
    public class StudentDaoModel
    {
        public int Id { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? EnrollmentDate { get; set; }

    }
}
