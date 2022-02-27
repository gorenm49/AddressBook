using System;
using System.Collections.Generic;

namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {

            System.Console.WriteLine("Welcome to Address Book Program!!!");

            Console.WriteLine("***********************************************************************************");
            while (true)
            {
                System.Console.WriteLine("\nSelect Operation: " +
                    "\n 1. Add Contact" +
                    "\n 2. Edit Contact" +
                    "\n 3. Delete Contact " +
                    "\n 4. Search a person in the city or state" +
                    "\n 5. Exit");

                AddressBookMain addressBook = new AddressBookMain();

                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        addressBook.AddContact();
                        break;
                    case 2:
                        addressBook.EditContact();
                        break;
                    case 3:
                        addressBook.DeleteContact();
                        break;
                    case 4:
                        Console.WriteLine("Enter the first name of the persion ");
                        string fname = Console.ReadLine();
                        addressBook.SearchPersonInTheCityOrState(fname);
                        break;
                    case 5:
                        Console.WriteLine("Application will exit");
                        return;
                    default:
                        System.Console.WriteLine("invalid input");
                        break;
                }
            } 
        }
    }
}
