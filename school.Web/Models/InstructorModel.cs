namespace school.Web.Models
{
    public class InstructorModel
    {
        public int Id { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime HireDate { get; set; }
    }
}