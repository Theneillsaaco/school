using School.DAL.Context;
using School.DAL.Entities;
using School.DAL.Enums;
using School.DAL.Exceptions;
using School.DAL.Interfaces;

namespace School.DAL.Dao
{
    public class DaoOfficeAssignment : IDaoOfficeAssignment
    {
        private readonly SchoolContext context;
        public DaoOfficeAssignment(SchoolContext context)
        {
            this.context = context;
        }
        public bool ExtistsOfficeAssignment(Func<OfficeAssignment, bool> filter)
        {
            return this.context.OfficeAssignments.Any(filter);
        }

        public OfficeAssignment GetOfficeAssignment(int id)
        {
            return this.context.OfficeAssignments.Find(id);
        }

        public List<OfficeAssignment> GetOfficeAssignment()
        {
            return this.context.OfficeAssignments.ToList();
        }

        public List<OfficeAssignment> GetOfficeAssignment(Func<OfficeAssignment, bool> filter)
        {
            return this.context.OfficeAssignments.Where(filter).ToList();
        }

        public void RemoveOfficeAssignment(OfficeAssignment officeAssignment)
        {
            OfficeAssignment officeAssignmentToRemove = this.GetOfficeAssignment(officeAssignment.InstructorId);

            this.context.OfficeAssignments.Update(officeAssignmentToRemove);

            this.context.SaveChanges();
        }

        public void SaveOfficeAssignment(OfficeAssignment officeAssignment)
        {
            string message = string.Empty;

            if (!IsOfficeAssignmentValid(officeAssignment, ref message, Operations.Save))
                throw new DaoOfficeAssignmentException(message);

            this.context.OfficeAssignments.Add(officeAssignment);
            this.context.SaveChanges();
        }

        public void UpdateOfficeAssignment(OfficeAssignment officeAssignment)
        {
            string message = string.Empty;

            if (!IsOfficeAssignmentValid(officeAssignment, ref message, Operations.Update))
                throw new DaoOfficeAssignmentException(message);

            OfficeAssignment officeAssignmentToUpdate = this.GetOfficeAssignment(officeAssignment.InstructorId);

            officeAssignmentToUpdate.Instructor = officeAssignment.Instructor;

            this.context.OfficeAssignments.Add(officeAssignmentToUpdate);
            this.context.SaveChanges();
        }
        private bool IsOfficeAssignmentValid(OfficeAssignment officeAssignment, ref string message, Operations operations)
        {
            bool result = false;

            if (operations == Operations.Save)
            {
                if (this.ExtistsOfficeAssignment(cd => cd.InstructorId == officeAssignment.InstructorId))
                {
                    message = "El intructor ya se encuentra registrado.";
                    return result;
                }
            }

            else
                result = true;

            return result;
        }
    }
}
