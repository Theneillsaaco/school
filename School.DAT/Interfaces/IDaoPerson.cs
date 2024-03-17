using School.DAL.Entities;

namespace School.DAL.Interfaces
{
    public interface IDaoPerson
    {
        void SavePerson(Person person);
        void UpdatePerson(Person person);
        void RemovePerson(Person person);
        Person GetPerson(int Id);
        List<Person> GetPersons();
        bool ExtistsPerson(Func<Person, bool> filter);
        List<Person> GetPersons(Func<Person, bool> filter);

    }
}
