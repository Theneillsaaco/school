﻿namespace school.Web.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? EnrollmentDate { get; set; }
    }
}
