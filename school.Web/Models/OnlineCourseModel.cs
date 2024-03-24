using School.DAL.Models;

namespace school.Web.Models
{
    public class OnlineCourseModel
    {
        public OnlineCourseModel()
        {
            
        }
        public OnlineCourseModel(OnlineCourseDaoModel onlineCourseDao)
        {
            this.Url = onlineCourseDao.Url;
            this.CourseId = onlineCourseDao.CourseId;
            this.CourseName = onlineCourseDao.CourseName;
        }
        public int CourseId { get; set; }
        public string? Url { get; set; }
        public string? CourseName { get; set; }
    }
}
