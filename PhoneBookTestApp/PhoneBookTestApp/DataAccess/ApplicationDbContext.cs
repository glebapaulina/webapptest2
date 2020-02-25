using System.Data.Entity;
using System.Data.SQLite;
using PhoneBookTestApp.Model;

namespace PhoneBookTestApp.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        private static SQLiteConnection connection = DatabaseUtil.GetConnection();
        public ApplicationDbContext() : base(connection, true)
        {
            DatabaseUtil.InitializeDatabase();
        }

        public DbSet<Person> PhoneBook { get; set; }


    }
}
