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
            
        }
        public int CourseId { get; set; }
        public string? Url { get; set; }
    }
}
