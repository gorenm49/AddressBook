using System;

namespace AddressBook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine("Welcome to Address Book Program!!!");

            System.Console.WriteLine("Select option: \n 1. Add Contact\n 2.Edit Contact\n 3.Delete Contact\n 4. Exit");

            AddressBookMain addrMain = new AddressBookMain();
            int num1 = int.Parse(Console.ReadLine());

            switch (num1)
            {
                case 1:
                    addrMain.AddContact();
                    break;
                case 2:
                    System.Console.WriteLine("Enter Name for perform Edit Operation:\n");
                    string n1 = Console.ReadLine();
                    addrMain.EditContact(n1);
                    addrMain.Display();
                    break;
                case 3:
                    System.Console.WriteLine("Enter Name for perform Delete Operation:\n");
                    string n2 = Console.ReadLine();
                    addrMain.DeleteContact(n2);
                    addrMain.Display();
                    break;
                case 4:
                    break;
                default:
                    System.Console.WriteLine("invalid input");
                    break;
            }   

            addrMain.Display();
        }
    }
}