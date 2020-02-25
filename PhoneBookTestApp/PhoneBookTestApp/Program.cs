﻿using PhoneBookTestApp.DataAccess;

namespace PhoneBookTestApp
{
    class Program
    {
        private PhoneBook.PhoneBook _phonebook = new PhoneBook.PhoneBook();
        static void Main(string[] args)
        {
            try
            {
                DatabaseUtil.InitializeDatabase();
                /* TODO: create person objects and put them in the PhoneBook and database
                * John Smith, (248) 123-4567, 1234 Sand Hill Dr, Royal Oak, MI
                * Cynthia Smith, (824) 128-8758, 875 Main St, Ann Arbor, MI
                */

                // TODO: print the phone book out to System.out
                // TODO: find Cynthia Smith and print out just her entry
                // TODO: insert the new person objects into the database

            }
            finally
            {
                DatabaseUtil.CleanUp();
            }
        }
    }
}
