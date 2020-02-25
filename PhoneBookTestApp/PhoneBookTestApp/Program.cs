using System.Diagnostics;
using PhoneBookTestApp.DataAccess;
using PhoneBookTestApp.Model;
using PhoneBookTestApp.PhoneBook;

namespace PhoneBookTestApp
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
               // DatabaseUtil.InitializeDatabase();
                IPhoneBook phoneBook = new PhoneBook.PhoneBook(new ApplicationDbContext());

                /* TODO: create person objects and put them in the PhoneBook and database
                * John Smith, (248) 123-4567, 1234 Sand Hill Dr, Royal Oak, MI
                * Cynthia Smith, (824) 128-8758, 875 Main St, Ann Arbor, MI
                */
                phoneBook.AddPerson(new Person
                {
                    Address = "1234 Sand Hill Dr, Royal Oak, MI",
                    Name = "John Smith",
                    PhoneNumber = "(248) 123-4567"

                });

                phoneBook.AddPerson(new Person
                {
                    Address = " 875 Main St, Ann Arbor, MI",
                    Name = "Cynthia Smith",
                    PhoneNumber = "(824) 128-8758"

                });


                // TODO: print the phone book out to System.out
                phoneBook.Print();

                // TODO: find Cynthia Smith and print out just her entry
                Person cynthia = phoneBook.FindPerson("Cynthia", "Smith");
                Trace.WriteLine(cynthia);


                // TODO: insert the new person objects into the database
                phoneBook.AddPerson(new Person
                {
                    Address = "3 Dorset Rise, London, EC4Y 8EN",
                    Name = "Rob Conklin",
                    PhoneNumber = "800 4997 4111"

                });

                phoneBook.AddPerson(new Person
                {
                    Address = "2411 Golf View Alley",
                    Name = "Dall Thebeau",
                    PhoneNumber = "(505) 3623608"

                });
            }
            finally
            {
                DatabaseUtil.CleanUp();
            }
        }
    }
}
