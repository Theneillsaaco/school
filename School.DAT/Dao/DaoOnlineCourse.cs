using School.DAL.Context;
using School.DAL.Entities;
using School.DAL.Exceptions;
using School.DAL.Interfaces;
using School.DAL.Enums;
using School.DAL.Models;

namespace School.DAL.Dao
{
    public class DaoOnlineCourse : IDaoOnlineCourse
    {
        private readonly SchoolContext context;
        public DaoOnlineCourse(SchoolContext context)
        {
            this.context = context;
        }
        public bool ExtistsOnlineCourse(Func<OnlineCourse, bool> filter)
        {
            return this.context.OnlineAssignments.Any(filter);
        }

        public OnlineCourseDaoModel GetOnlineCourse(int Id)
        {
            OnlineCourseDaoModel? onlineCourseDaoModel = new OnlineCourseDaoModel();
            try
            {
                onlineCourseDaoModel = (from OnlineCourse in this.context.OnlineAssignments
                                        join depto in this.context.Course on OnlineCourse.CourseId
                                                                          equals depto.CourseId
                                        select new OnlineCourseDaoModel()
                                        {
                                            CourseId = OnlineCourse.CourseId,
                                            CourseName = depto.Title
                                        }).FirstOrDefault();  
            }
            catch(Exception ex)
            {
                throw new DaoOnlineCourseException($"Error, no se pudo obtener el curso: {ex.Message}");
            }
            return onlineCourseDaoModel;
        }

        public List<OnlineCourseDaoModel> GetOnlineCourses()
        {
            List<OnlineCourseDaoModel>? onlineList= new List<OnlineCourseDaoModel>();
            try
            {
                onlineList = (from OnlineCourse in this.context.OnlineAssignments
                              join depto in this.context.Course on OnlineCourse.CourseId
                                                                     equals depto.CourseId
                              select new OnlineCourseDaoModel()
                              {
                                  CourseId = OnlineCourse.CourseId,
                                  CourseName = depto.Title

                              }).ToList();
            }
            catch (Exception ex)
            {
                throw new DaoOnlineCourseException($"Error, no se pudo obtener el curso: {ex.Message}");
            }
            return onlineList;
        }

        public List<OnlineCourseDaoModel> GetOnlineCourses(Func<OnlineCourse, bool> filter)
        {
            List<OnlineCourseDaoModel>? onlineList = new List<OnlineCourseDaoModel>();

            try
            {
                var OnlineCourse = this.context.OnlineAssignments.Where(filter);

                onlineList = (from onlineCourse in OnlineCourse
                              join depto in this.context.Course on onlineCourse.CourseId equals depto.CourseId
                              select new OnlineCourseDaoModel()
                              {
                                  CourseId = onlineCourse.CourseId,
                                  CourseName = depto.Title

                              }).ToList();

            }
            catch (Exception ex)
            {
                throw new DaoOnlineCourseException($"Error, no se pudo obtener el curso: {ex.Message}");
            }
            return onlineList;
        }

        public void RemoveOnlineCourse(OnlineCourse onlineCourse)
        {

        }

        public void SaveOnlineCourse(OnlineCourse onlineCourse)
        {
            string message = string.Empty;

            if (!IsOnlineCourseValid(onlineCourse, ref message, Operations.Save))
                throw new DaoOnlineCourseException(message);

            this.context.OnlineAssignments.Add(onlineCourse);
            this.context.SaveChanges();
        }

        public void UpdateOnlineCourse(OnlineCourse onlineCourse)
        {
            string message = string.Empty;

            if (!IsOnlineCourseValid(onlineCourse, ref message, Operations.Update))
                throw new DaoDepartmentException(message);

            OnlineCourse onlineCourseToUpdate = this.context.OnlineAssignments.Find(onlineCourse.CourseId);

            onlineCourseToUpdate.Url = onlineCourse.Url;
            onlineCourseToUpdate.CourseId = onlineCourse.CourseId;



            this.context.OnlineAssignments.Update(onlineCourseToUpdate);
            this.context.SaveChanges();
        }
        private bool IsOnlineCourseValid(OnlineCourse onlineCourse, ref string message, Operations operations)
        {
            bool result = false;

            if (operations == Operations.Save)
            {
                if (this.ExtistsOnlineCourse(cd => cd.Course == onlineCourse.Course))
                {
                    message = "El curso ya se encuentra registrado.";
                    return result;
                }
            }

            else
                result = true;

            return result;
        }
    }
}
