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
                    "\n 2. Edit Contact phone by id" +
                    "\n 3. Delete Contact " +
                    "\n 4. Search a person in the city or state" +
                    "\n 5. View Person In The City Or State" +
                    "\n 6. CountOfContactPersons" +
                    "\n 7. Sort the Entries by Name" +
                    "\n 8. Sort Contact By City State Or Zip" +
                    "\n 9. Display Contacts" +
                    "\n 10. Retrive Records By Pesticular Date Range" +
                    "\n 11. Exit ");

                AddressBookMain addressBook = new AddressBookMain();
                Contacts contacts = new Contacts();

                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        addressBook.AddContact();
                        break;
                    case 2:
                        Console.WriteLine("Enter id ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Phone number to update ");
                        string phone = Console.ReadLine();
                        addressBook.EditContactPhoneById(id,phone);
                        break;
                    case 3:
                        addressBook.DeleteContact();
                        break;
                    case 4:
                        Console.WriteLine("Enter the first name of the person to search ");
                        string fname = Console.ReadLine();
                        addressBook.SearchPersonInTheCityOrState(fname);
                        break;
                    case 5:
                        Console.WriteLine("Enter the first name of the persion to view record");
                        string fname1 = Console.ReadLine();
                        addressBook.ViewPersonInTheCityOrState(fname1);
                        break;
                    case 6:
                        addressBook.CountOfContactPersons();
                        break;
                    case 7:
                        addressBook.SortContactByName();
                        break;
                    case 8:
                        Console.WriteLine("Enter City Or State Or zip to sort the contacts");
                        string getstring = Console.ReadLine();
                        addressBook.SortContactByCityStateOrZip(getstring);
                        break;
                    case 9:
                        addressBook.Display(contacts);
                        break;
                    case 10:
                        Console.WriteLine("Enter date 1:");
                        DateTime date1 = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Enter date 2:");
                        DateTime date2 = DateTime.Parse(Console.ReadLine());
                        addressBook.RetriveRecordsByPesticularDateRange(date1, date2);
                        break;
                    case 11:
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