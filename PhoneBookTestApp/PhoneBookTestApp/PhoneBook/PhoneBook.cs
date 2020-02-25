using System.Diagnostics;
using System.Linq;
using PhoneBookTestApp.DataAccess;
using PhoneBookTestApp.Model;

namespace PhoneBookTestApp.PhoneBook
{
    public class PhoneBook : IPhoneBook
    {
        private ApplicationDbContext _context;

        public PhoneBook(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddPerson(Person person)
        {
            _context.PhoneBook.Add(person);
            _context.SaveChanges();
        }

        public Person FindPerson(string firstName, string lastName)
        {
            string name = $"{firstName} {lastName}";
            return _context.PhoneBook.FirstOrDefault(x => x.Name == name);
        }

        public void Print()
        {
            foreach (var person in _context.PhoneBook)
            {
                //Equivalent of System.out
                Trace.WriteLine(person);
            }
        }

    }
}