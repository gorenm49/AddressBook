using System;


namespace AddressBook
{
    public class AddressBookMain
    {

        List<Contacts> addrBook = new List<Contacts>();

      /*  public int AddAddressBook()
        {

            System.Console.WriteLine("Enter count for Address book:");
            int addCount = Convert.ToInt32(Console.ReadLine());

            Dictionary<addCount, addrBook> dict = new Dictionary<addCount,addrBook>();
            
            for (int i = 1; i <=addCount; i++)           {
            {
                return dict.Add(i,addrBook);
            }

        }*/

        public void AddContact()
        {
            //AddAddressBook();

            Contacts contacts = new Contacts();
            Console.WriteLine("Please the count of contact you want to create:");
            int contactsCount = Convert.ToInt32(Console.ReadLine());
            
            for (int i = 1; i <= contactsCount; i++)
            {
                System.Console.WriteLine("Enter details for "+i+" Contact");

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

                System.Console.WriteLine("Contact added Successfully....");
            }
        }

        public void EditContact(string fName)
        {
            Contacts c1 = new Contacts();

            foreach (var data in addrBook)
            {
                if (data.FirstName == fName)
                {
                    c1 = data;
                    return;
                }
            }
            System.Console.WriteLine("choose option:\n 1. Last Name\n 2. Address\n 3. City\n 4. State\n 5. Zip\n 6. Phone number\n 7. Email\n 8.Exit");
            bool flag = true;

            while (flag)
            {
                int num = int.Parse(Console.ReadLine());

                switch (num)
                {
                    case 1:
                        c1.LastName = Console.ReadLine();
                        break;
                    case 2:
                        c1.Address = Console.ReadLine();
                        break;
                    case 3:
                        c1.City = Console.ReadLine();
                        break;
                    case 4:
                        c1.State = Console.ReadLine();
                        break;
                    case 5:
                        c1.Zip = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 6:
                        c1.PhoneNumber = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 7:
                        c1.Email = Console.ReadLine();
                        break;
                    case 8:
                        flag = false;
                        break;
                    default:
                        System.Console.WriteLine("Choose right option..");
                        break;
                }
                
            }

        }

        public void DeleteContact(string fName)
        {
            Contacts c2 = new Contacts();
            
            foreach (var data in addrBook)
            {
                if (data.FirstName == fName)
                {
                    c2 = data;
                }
            }
            addrBook.Remove(c2);
    
        }

        public void Display()
        {

            foreach (var data in addrBook)
            {
                System.Console.WriteLine("Contact Data is: \n"+data.FirstName+"\n"+data.LastName+"\n"+data.Address+"\n"+data.City+"\n"+data.State+"\n"+data.Zip+"\n"+data.PhoneNumber+"\n"+data.Email);
                
            }
        }
    }
} 