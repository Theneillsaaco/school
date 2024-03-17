using School.DAL.Context;
using School.DAL.Entities;
using School.DAL.Exceptions;
using School.DAL.Interfaces;
using School.DAL.Enums;

namespace School.DAL.Dao
{
    public class DaoOnsiteCourse : IDaoOnsiteCourse
    {
        private readonly SchoolContext context;
        public DaoOnsiteCourse(SchoolContext context)
        {
            this.context = context;
        }
        public bool ExtistsOnsiteCourse(Func<OnsiteCourse, bool> filter)
        {
            return this.context.OnsiteAssignments.Any(filter);
        }

        public List<OnsiteCourse> GetDepartments(Func<OnsiteCourse, bool> filter)
        {
            throw new NotImplementedException();
        }

        public OnsiteCourse GetOnsiteCourse(int id)
        {
            return this.context.OnsiteAssignments.Find(id);
        }

        public List<OnsiteCourse> GetOnsiteCourse()
        {
            return this.context.OnsiteAssignments.ToList();
        }

        public List<OnsiteCourse> GetOnsiteCourse(Func<OnsiteCourse, bool> filter)
        {
            return this.context.OnsiteAssignments.Where(filter).ToList();
        }

        public void RemoveOnsiteCourse(OnsiteCourse onsiteCourse)
        {
            OnsiteCourse onsiteCourseToRemove = this.GetOnsiteCourse(onsiteCourse.CourseId);

            this.context.OnsiteAssignments.Update(onsiteCourseToRemove);

            this.context.SaveChanges();
        }

        public void SaveOnsiteCourse(OnsiteCourse onsiteCourse)
        {
            string message = string.Empty;

            if (!IsOnsiteCourseValid(onsiteCourse, ref message, Operations.Save))
                throw new DaoOnsiteCourseException(message);

            this.context.OnsiteAssignments.Add(onsiteCourse);
            this.context.SaveChanges();
        }

        public void UpdateOnsiteCourse(OnsiteCourse onsiteCourse)
        {
            string message = string.Empty;

            if (!IsOnsiteCourseValid(onsiteCourse, ref message, Operations.Update))
                throw new DaoOnsiteCourseException(message);

            OnsiteCourse onsiteCourseToUpdate = this.GetOnsiteCourse(onsiteCourse.CourseId);

            this.context.OnsiteAssignments.Add(onsiteCourseToUpdate);
            this.context.SaveChanges();
        }
        private bool IsOnsiteCourseValid(OnsiteCourse onsiteCourse, ref string message, Operations operations)
        {
            bool result = false;



            if (operations == Operations.Save)
            {
                if (this.ExtistsOnsiteCourse(cd => cd.Course == onsiteCourse.Course))
                {
                    message = "El curso ya tiene sitio.";
                    return result;
                }
            }

            else
                result = true;

            return result;
        }
    }
}
