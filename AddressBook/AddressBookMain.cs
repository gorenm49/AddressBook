using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AddressBook
{
    public class AddressBookMain
    {
        public List<Contacts> contact = new List<Contacts>();
        Contacts addressBook = new Contacts();

        int counter = 0;
        public void AddContact()
        {
            Console.WriteLine("Enter the count of the contact you want to create:");
            int contactCount = Convert.ToInt32(Console.ReadLine());

            for (int j = 1; j <= contactCount; j++)
            {
                Console.WriteLine("\nEnter the details for " + j + " contact");

                Console.WriteLine("Enter First Name");
                addressBook.fname = Console.ReadLine();

                Console.WriteLine("Enter Last Name");
                addressBook.lname = Console.ReadLine();

                Console.WriteLine("Enter Address");
                addressBook.address = Console.ReadLine();

                Console.WriteLine("Enter a City");
                addressBook.city = Console.ReadLine();

                Console.WriteLine("Enter a State");
                addressBook.state = Console.ReadLine();

                Console.WriteLine("Enter a Zip");
                addressBook.zip = Console.ReadLine();

                Console.WriteLine("Enter a PhoneNumber");
                addressBook.phone = Console.ReadLine();

                Console.WriteLine("Enter an Email");
                addressBook.email = Console.ReadLine();

                var checkDuplicate = contact.GroupBy(x => x.fname, StringComparer.OrdinalIgnoreCase)
                         .Where(y => y.Count() > 1)
                         .Select(z => z.Key)
                         .ToList();
                if (checkDuplicate.Equals(addressBook.fname))
                {
                    Console.WriteLine("Record is already present in the addrebook");

                }
                else
                {
                    contact.Add(addressBook);
                    ReadWriteContactIntoCSVFile();
                    ReadWriteContactIntoTextFile();

                }
            }
        }

        public void DeleteContact()
        {
            Console.WriteLine("Enter First Name to delete the record");
            string fname = Console.ReadLine();

            foreach (var item in contact)
            {
                if (item.fname.Equals(fname))
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
                "\nFirst Name - " + contact.fname +
                "\nLast Name - " + contact.lname +
                "\nAddress - " + contact.address +
                "\nCity - " + contact.city +
                "\nState - " + contact.state +
                "\nZip - " + contact.zip +
                "\nPhone Number - " + contact.phone +
                "\nEmail Id - " + contact.email);

        }

        public void EditContact()
        {
            Console.WriteLine("Enter The First Name");
            string Fname = Console.ReadLine();

            foreach (var item in contact)
            {
                if (item.fname == Fname)
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
                            item.fname = getString;
                            break;
                        case 2:
                            Console.WriteLine("Enter Last Name to Update");
                            getString = Console.ReadLine();
                            item.lname = getString;
                            break;
                        case 3:
                            Console.WriteLine("Enter Address to Update");
                            getString = Console.ReadLine();
                            item.address = getString;
                            break;
                        case 4:
                            Console.WriteLine("Enter City Name to Update");
                            getString = Console.ReadLine();
                            item.city = getString;
                            break;
                        case 5:
                            Console.WriteLine("Enter State Name to Update");
                            getString = Console.ReadLine();
                            item.state = getString;
                            break;
                        case 6:
                            Console.WriteLine("Enter Zip code to Update");
                            getString = Console.ReadLine();
                            item.zip = getString;
                            break;
                        case 7:
                            Console.WriteLine("Enter Phone Number to Update");
                            getString = Console.ReadLine();
                            item.phone = getString;
                            break;
                        case 8:
                            Console.WriteLine("Enter E-mail id to Update");
                            getString = Console.ReadLine();
                            item.email = getString;
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

        public void SearchPersonInTheCityOrState(string fname)
        {
            foreach (Contacts item in contact)
            {
                if (contact.Any(x => x.fname == fname))
                {
                    Console.WriteLine("Person Found!!");
                }
                else
                {
                    Console.WriteLine("Person not found");
                }
            }

        }

        public void ViewPersonInTheCityOrState(string fname)
        {
            foreach (Contacts item in contact)
            {
                if (contact.Any(x => x.fname == fname))
                {
                    Console.WriteLine("Person Found!!");
                }
                else
                {
                    Console.WriteLine("Person not found");
                }
            }
        }

        public void CountOfContactPersons()
        {
            Console.WriteLine("Number of contact Persons" + counter);
        }

        public void SortContactByName()
        {
            try
            {
                contact = contact.OrderBy(x => x.fname).ToList();
                Display(addressBook);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }

        public void SortContactByCityStateOrZip(string input)
        {
            try
            {
                if (input != null)
                {
                    contact = contact.OrderBy(x => x.city).ToList();
                    Display(addressBook);
                }
                if (input != null)
                {
                    contact = contact.OrderBy(x => x.state).ToList();
                    Display(addressBook);
                }
                if (input != null)
                {
                    contact = contact.OrderBy(x => x.zip).ToList();
                    Display(addressBook);
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }

        public void ReadWriteContactIntoTextFile()
        {
            try
            {
                string filePath = @"C:\Users\Nityanand Gore\source\repos\AddressBook\AddressBook\AddDataFile.txt";
                using (StreamWriter sw = File.AppendText(filePath))
                {
                    foreach (Contacts item in contact)
                    {
                        sw.WriteLine("Address Book Details Added For " + item.fname + " Contact");
                        sw.WriteLine(item.fname +
                            "\t" + item.lname +
                            "\t" + item.address +
                            "\t" + item.city +
                            "\t" + item.state +
                            "\t" + item.zip +
                            "\t" + item.phone +
                            "\t" + item.email);
                        sw.Close();
                    }
                }

                using (StreamReader sr = File.OpenText(filePath))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ReadWriteContactIntoCSVFile()
        {
            try
            {
                string filePath = @"C:\Users\Nityanand Gore\source\repos\AddressBook\AddressBook\AddDataFile.csv";
                using (StreamWriter sw = File.AppendText(filePath))
                {
                    sw.WriteLine("FirstName,\t" +
                        "Last Name,\t" +
                        "Address,\t" +
                        "City,\t" +
                        "State,\t" +
                        "Zip,\t" +
                        "Phone Number,\t" +
                        "Email");
                    foreach (Contacts item in contact)
                    {
                        sw.WriteLine(item.fname +
                            ",\t" + item.lname +
                            ",\t" + item.address +
                            ",\t" + item.city +
                            ",\t" + item.state +
                            ",\t" + item.zip +
                            ",\t" + item.phone +
                            ",\t" + item.email);
                        sw.Close();
                    }
                }

                using (StreamReader sr = File.OpenText(filePath))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}