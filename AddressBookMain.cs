using System;

namespace AddressBook
{
    public class AddressBookMain
    {
        List<Contacts> addrBook = new List<Contacts>();

        public void AddContact()
        {

            Contacts contacts = new Contacts();
            System.Console.WriteLine("Enter First Name: ");
            contacts.FirstName = Console.ReadLine();

            System.Console.WriteLine("Enter Last Name: ");
            contacts.LastName = Console.ReadLine();

            System.Console.WriteLine("Enter Adress: ");
            contacts.Address = Console.ReadLine();

            System.Console.WriteLine("Enter City: ");
            contacts.City = Console.ReadLine();

            System.Console.WriteLine("Enter State: ");
            contacts.State = Console.ReadLine();

            System.Console.WriteLine("Enter Zip: ");
            contacts.Zip = Convert.ToInt32(Console.ReadLine());

            System.Console.WriteLine("Phone Number: ");
            contacts.PhoneNumber = Convert.ToInt32(Console.ReadLine());

            System.Console.WriteLine("Enter Email-Id: ");
            contacts.Email = Console.ReadLine();

            addrBook.Add(contacts);
        }
    }
}