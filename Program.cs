using System;

namespace AddressBook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine("Welcome to Address Book Program!!!");

           AddressBookMain addrMain = new AddressBookMain();
           addrMain.AddContact();
            
        }
    }
}