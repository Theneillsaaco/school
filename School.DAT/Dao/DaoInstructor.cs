using School.DAL.Context;
using School.DAL.Entities;
using School.DAL.Exceptions;
using School.DAL.Interfaces;
using School.DAL.Enums;
using Microsoft.EntityFrameworkCore;

namespace School.DAL.Dao
{
    public class DaoInstructor : IDaoInstructor
    {
        private readonly SchoolContext context;
        public DaoInstructor(SchoolContext context)
        {
            this.context = context;
        }

        public bool ExistesInstructor(Func<Instructor, bool> filter)
        {
            return this.context.Instructors.Any(filter);
        }

        public Instructor? GetInstructor(int Id)
        {
            return this.context.Instructors.Find(Id);
        }

        public List<Instructor> GetInstructors()
        {
            var querry = (from Inst in this.context.Instructors
                          where Inst.Deleted == false
                          orderby Inst.Id ascending
                          select Inst).ToList();
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
            try
            {
                this.context.Instructors.Add(instructor);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new DaoInstructorException(ex.Message);
            }

        }

        public void UpdateInstructor(Instructor instructor)
        {
            var instructorToUpdate = context.Instructors.Find(instructor.Id);

            if (instructorToUpdate == null)
               throw new DaoInstructorException("No se encontró el instructor"); // Informative exception


            // Update properties of instructorToUpdate using instructor values
            instructorToUpdate.FirstName = instructor.FirstName;
            instructorToUpdate.LastName = instructor.LastName;
            instructorToUpdate.HireDate = instructor.HireDate;
            instructorToUpdate.ModifyDate = instructor.ModifyDate; // Assuming this is populated
            instructorToUpdate.UserMod = instructor.UserMod; // Assuming this is populated

            context.SaveChanges();
        }

        private bool IsInstructorValid(Instructor instructor, ref string message, Operations operations)
        {
            bool result = false;

            if (string.IsNullOrEmpty(instructor.FirstName))
            {
                message = "Se requiere un nombre";
                return true;
            }
            if (instructor.FirstName.Length > 50)
            {
                message = "El nombre es demaciado largo, El limite es 50 caracteres.";
                return true;
            }
            if (string.IsNullOrEmpty(instructor.LastName))
            {
                message = "Se requiere un apellido";
                return true;
            }
            if (instructor.LastName.Length > 50)
            {
                message = "El apellido es demaciado largo, El limite es 50 caracteres.";
                return true;
            }
            if (operations == Operations.Save)
            {
            }
            else
                result = true;

            return result;
        }
    }
}
