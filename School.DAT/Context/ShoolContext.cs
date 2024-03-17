using Microsoft.EntityFrameworkCore;
using School.DAL.Entities;

namespace School.DAL.Context
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base (options) 
        {
        }
        #region"Entities"
        public DbSet <Course> Course { get; set; }
        public DbSet <Department> Departments { get; set; }
        public DbSet <Instructor> Instructors { get; set; }
        public DbSet <OfficeAssignment> OfficeAssignments { get; set; }
        public DbSet <OnlineCourse> OnlineAssignments { get; set; }
        public DbSet <OnsiteCourse> OnsiteAssignments { get; set; }
        public DbSet <Person> Persons { get; set; }
        public DbSet <Student> Students { get; set; }
        public DbSet <StudentGrade> StudentGrades { get; set; }
        #endregion
    }
}
