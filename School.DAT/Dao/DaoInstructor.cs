using School.DAL.Context;
using School.DAL.Entities;
using School.DAL.Exceptions;
using School.DAL.Interfaces;
using School.DAL.Enums;

namespace School.DAL.Dao
{
    public class DaoInstructor : IDaoInstructor
    {
        private readonly SchoolContext context;
        public DaoInstructor(SchoolContext context)
        {
            this.context = context;
        }
        public bool ExtistsInstructor(Func<Instructor, bool> filter)
        {
            return this.context.Instructors.Any(filter);
        }

        public Instructor GetInstructor(int id)
        {
            return this.context.Instructors.Find(id);
        }

        public List<Instructor> GetInstructors()
        {
            var querry = (from inst in this.context.Instructors
                          where inst.Deleted == false
                          orderby inst.Id ascending
                          select inst).ToList();
            return querry;
        }

        public List<Instructor> GetInstructors(Func<Instructor, bool> filter)
        {
            return this.context.Instructors.Where(filter).ToList();
        }

        public void RemoveInstructor(Instructor instructor)
        {
            Instructor instructorToRemove = this.GetInstructor(instructor.Id);

            instructorToRemove.Deleted = instructor.Deleted;
            instructorToRemove.DeletedDate = instructor.DeletedDate;
            instructorToRemove.UserDeleted = instructor.UserDeleted;

            this.context.Instructors.Update(instructorToRemove);

            this.context.SaveChanges();
        }

        public void SaveInstructor(Instructor instructor)
        {
            string message = string.Empty;

            if (!IsInstructorValid(instructor, ref message, Operations.Save))
                throw new DaoInstructorException(message);

            this.context.Instructors.Add(instructor);
            this.context.SaveChanges();
        }

        public void UpdateInstructor(Instructor instructor)
        {
            string message = string.Empty;

            if (!IsInstructorValid(instructor, ref message, Operations.Update))
                throw new DaoInstructorException(message);

            Instructor instructorToUpdate = this.context.Instructors.Find(instructor.Id);

            instructorToUpdate.ModifyDate = instructor.ModifyDate;
            instructorToUpdate.UserMod = instructor.UserMod;
            instructorToUpdate.FirstName = instructor.FirstName;
            instructorToUpdate.LastName = instructor.LastName;
            instructorToUpdate.UserMod = instructor.UserMod;
            instructorToUpdate.HireDate = instructor.HireDate;

            this.context.Instructors.Update(instructorToUpdate);
            this.context.SaveChanges();
        }
        private bool IsInstructorValid(Instructor instructor, ref string message, Operations operations)
        {
            bool result = false;


            if (string.IsNullOrEmpty(instructor.LastName))
            {
                message = "El apellido del instructor es requerido";
                return true;
            }

            if (instructor.LastName.Length > 50)
            {
                message = "El apellido es demaciado largo, el limite es 50 caracteres";
                return true;
            }

            if (instructor.FirstName.Length > 50)
            {
                message = "El apellido es demaciado largo, el limite es 50 caracteres";
                return true;
            }

            if (string.IsNullOrEmpty(instructor.FirstName))
            {
                message = "El apellido del instructor es requerido";
                return true;
            }

            if (operations == Operations.Save)
            {
                if (this.ExtistsInstructor(cd => cd.LastName == instructor.LastName))
                {
                    message = "El apellido ya se encuentra registrado.";
                    return result;
                }
                if (this.ExtistsInstructor(cd => cd.FirstName == instructor.FirstName))
                {
                    message = "El nombre ya se encuentra registrado.";
                    return result;
                }
            }

            else
                result = true;

            return result;
        }
    }
}
