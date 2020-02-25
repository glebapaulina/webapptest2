using PhoneBookTestApp.Model;

namespace PhoneBookTestApp.PhoneBook
{
    public interface IPhoneBook
    {
        Person FindPerson(string firstName, string lastName);
        void AddPerson(Person newPerson);
        void Print();
    }
}