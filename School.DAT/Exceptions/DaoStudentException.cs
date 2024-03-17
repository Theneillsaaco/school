

namespace School.DAL.Exceptions
{
    public class DaoStudentException : Exception
    {
        public DaoStudentException(string message) : base(message)
        { 
            // x logica para guardar el error.
        }
    }
}
