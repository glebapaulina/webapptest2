using System.Linq;
using NUnit.Framework;
using PhoneBookTestApp.DataAccess;
using PhoneBookTestApp.Model;
using PhoneBookTestApp.PhoneBook;

namespace PhoneBookTestAppTests.Tests
{
    [TestFixture]
    public class PhoneBookTest
    {
        [TearDown]
        public void Dispose()
        {
            DatabaseUtil.CleanUp();
        }

        [Test]
        public void Should_AddPersonToDatabase()
        {
            //arrange
            ApplicationDbContext context = new ApplicationDbContext();
            IPhoneBook phoneBook = new PhoneBook(context);

            //act
            phoneBook.AddPerson(new Person
            {
                Address = "1234 Sand Hill Dr, Royal Oak, MI",
                Name = "John Smith",
                PhoneNumber = "(248) 123-4567"
            });

            //assert
            Assert.AreEqual("John Smith", context.PhoneBook.OrderByDescending(x => x.Id).FirstOrDefault()?.Name);
        }

        [Test]
        public void Should_ReturnPerson_When_PersonInDatabase()
        {
            //arrange
            ApplicationDbContext context = new ApplicationDbContext();
            IPhoneBook phoneBook = new PhoneBook(context);

            context.PhoneBook.Add(new Person
            {
                Address = "1234 Sand Hill Dr, Royal Oak, MI",
                Name = "Jooon Smith",
                PhoneNumber = "(248) 123-4567"

            });
            context.SaveChanges();

            //act
            Person foundPerson = phoneBook.FindPerson("Jooon", "Smith");

            //assert
            Assert.AreEqual("Jooon Smith", foundPerson.Name);
        }


        [Test]
        public void Should_ReturnNull_When_PersonNotInDatabase()
        {
            //arrange
            ApplicationDbContext context = new ApplicationDbContext();
            IPhoneBook phoneBook = new PhoneBook(context);

            context.PhoneBook.RemoveRange(context.PhoneBook);
            context.SaveChanges();

            //act
            Person foundPerson = phoneBook.FindPerson("Jon", "Smith");

            //assert
            Assert.IsNull(foundPerson);
        }

    }
}