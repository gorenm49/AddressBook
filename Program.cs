using System;

namespace AddressBook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine("Welcome to Address Book Program!!!");

            System.Console.WriteLine("Select option: \n 1. Add Contact\n 2.Edit Contact\n 3.Exit");

            AddressBookMain addrMain = new AddressBookMain();
            int num1 = int.Parse(Console.ReadLine());

            switch (num1)
            {
                case 1:
                    addrMain.AddContact();
                    break;
                case 2:
                    addrMain.EditContact("Shree");
                    break;
                case 3:
                    break;
                default:
                    System.Console.WriteLine("invalid input");
                    break;
            }          
        }
    }
}