using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBook
{
    public class AddressBookMain
    {
        public List<Contacts> contact = new List<Contacts>();
        Contacts addressBook = new Contacts();
        public void AddContact()
        {
            Console.WriteLine("Enter the count of the contact you want to create:");
            int contactCount = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= contactCount; i++)
            {
                Console.WriteLine("\nEnter the details for " + i + " contact");

                Console.WriteLine("Enter First Name");
                addressBook.FirstName = Console.ReadLine();

                Console.WriteLine("Enter Last Name");
                addressBook.LastName = Console.ReadLine();

                Console.WriteLine("Enter Address");
                addressBook.Address = Console.ReadLine();

                Console.WriteLine("Enter a City");
                addressBook.City = Console.ReadLine();

                Console.WriteLine("Enter a State");
                addressBook.State = Console.ReadLine();

                Console.WriteLine("Enter a Zip");
                addressBook.Zip = Console.ReadLine();

                Console.WriteLine("Enter a PhoneNumber");
                addressBook.Phonenumber = Console.ReadLine();

                Console.WriteLine("Enter an Email");
                addressBook.Email = Console.ReadLine();

                var checkDuplicate = contact.GroupBy(x => x.FirstName, StringComparer.OrdinalIgnoreCase)
                         .Where(y => y.Count() > 1)
                         .Select(z => z.Key)
                         .ToList();
                if (checkDuplicate.Equals(addressBook.FirstName))
                {
                    Console.WriteLine("Record is already present in the addrebook");

                }
                else
                {
                    contact.Add(addressBook);
                    Display(addressBook);
                }
            }
        }

        public void DeleteContact()
        {
            Console.WriteLine("Enter First Name to delete the record");
            string fname = Console.ReadLine();

            foreach (Contacts item in contact)
            {
                if (item.FirstName == fname)
                {
                    contact.Remove(item);
                    Console.WriteLine("Record Deleted Sucessfully");
                }
                else
                {
                    Console.WriteLine("Record not found");
                }
            }

        }
        public void Display(Contacts contact)
        {
            Console.WriteLine("Contact Details " +
                "\nFirst Name - " + contact.FirstName +
                "\nLast Name - " + contact.LastName +
                "\nAddress - " + contact.Address +
                "\nCity - " + contact.City +
                "\nState - " + contact.State +
                "\nZip - " + contact.Zip +
                "\nPhone Number - " + contact.Phonenumber +
                "\nEmail Id - " + contact.Email);

        }

        public void EditContact()
        {
            Console.WriteLine("Enter The First Name");
            string Fname = Console.ReadLine();

            foreach (var item in contact)
            {
                if (item.FirstName == Fname)
                {

                    Console.WriteLine("\nEnter the details to update contact:" +
                        "\n1. First Name" +
                        "\n2. Last Name" +
                        "\n3. Address" +
                        "\n4. city" +
                        "\n5. State" +
                        "\n6. Zip" +
                        "\n7. PhoneNumber" +
                        "\n8. Email");

                    int option = Convert.ToInt32(Console.ReadLine());
                    String getString;
                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("Enter first Name to Update");
                            getString = Console.ReadLine();
                            item.FirstName = getString;
                            break;
                        case 2:
                            Console.WriteLine("Enter Last Name to Update");
                            getString = Console.ReadLine();
                            item.LastName = getString;
                            break;
                        case 3:
                            Console.WriteLine("Enter Address to Update");
                            getString = Console.ReadLine();
                            item.Address = getString;
                            break;
                        case 4:
                            Console.WriteLine("Enter City Name to Update");
                            getString = Console.ReadLine();
                            item.City = getString;
                            break;
                        case 5:
                            Console.WriteLine("Enter State Name to Update");
                            getString = Console.ReadLine();
                            item.State = getString;
                            break;
                        case 6:
                            Console.WriteLine("Enter Zip code to Update");
                            getString = Console.ReadLine();
                            item.Zip = getString;
                            break;
                        case 7:
                            Console.WriteLine("Enter Phone Number to Update");
                            getString = Console.ReadLine();
                            item.Phonenumber = getString;
                            break;
                        case 8:
                            Console.WriteLine("Enter E-mail id to Update");
                            getString = Console.ReadLine();
                            item.Email = getString;
                            break;
                        default:
                            Console.WriteLine("Invalid Choice");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Record not found.");
                }

                Display(item);
            }
        }
    }
}
