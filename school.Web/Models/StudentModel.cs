using School.DAL.Models;

namespace school.Web.Models
{
    public class StudentModel
    {
        public StudentModel()
        {
            
        }
        public StudentModel(StudentDaoModel studentDaoModel)
        {
            this.Id = studentDaoModel.Id;
            this.CreationDate = studentDaoModel.CreationDate;
            this.LastName = studentDaoModel.LastName;
            this.FirstName = studentDaoModel.FirstName;
            this.EnrollmentDate = studentDaoModel.EnrollmentDate;
        }
        public int Id { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? EnrollmentDate { get; set; }
    }
}
