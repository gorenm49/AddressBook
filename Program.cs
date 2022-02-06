using System;
using System.Collections.Generic;

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
            int count =0;

            switch (num1)
            {
                case 1:
                    System.Console.WriteLine("Enter count for Address book:");
                    int addCount = Convert.ToInt32(Console.ReadLine());

                    Dictionary<int, string> dict = new Dictionary<int,string>();
            
                    for (int i = 1; i <=addCount; i++)           
                    {
                        count++;
                        List<AddressBookMain> newAdd = new List<AddressBookMain>();
                        dict.Add(i,"NewDict");
                    }

                    System.Console.WriteLine(count+" Address Book Created..");
                    addrMain.AddContact();
                    break;
                case 2:
                    System.Console.WriteLine("Enter Name for perform Edit Operation:");
                    string n1 = Console.ReadLine();
                    addrMain.EditContact(n1);
                    addrMain.Display();
                    break;
                case 3:
                    System.Console.WriteLine("Enter Name for perform Delete Operation:");
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