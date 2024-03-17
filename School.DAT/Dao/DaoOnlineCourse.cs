using School.DAL.Context;
using School.DAL.Entities;
using School.DAL.Exceptions;
using School.DAL.Interfaces;
using School.DAL.Enums;

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

        public OnlineCourse GetOnlineCourse(int id)
        {
            return this.context.OnlineAssignments.Find(id);
        }

        public List<OnlineCourse> GetOnlineCourse()
        {
            return this.context.OnlineAssignments.ToList();
        }

        public List<OnlineCourse> GetOnlineCourse(Func<OnlineCourse, bool> filter)
        {
            return this.context.OnlineAssignments.Where(filter).ToList();
        }

        public OnlineCourse GetOnlineCourset(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveOnlineCourse(OnlineCourse onlineCourse)
        {
            OnlineCourse onlineCourseToRemove = this.GetOnlineCourse(onlineCourse.CourseId);

            this.context.OnlineAssignments.Update(onlineCourseToRemove);

            this.context.SaveChanges();
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

            OnlineCourse onlineCourseToUpdate = this.GetOnlineCourse(onlineCourse.CourseId);

            this.context.OnlineAssignments.Add(onlineCourseToUpdate);
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
