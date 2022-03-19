using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;

namespace AddressBook
{
    public class AddressBookMain
    {
        public static string connectionstr = "Data Source=(localDB)\\MSSQLLocalDB;Initial Catalog=Address_BOOK_Service_DB;Integrated Security=True;";
        SqlConnection connection = new SqlConnection(connectionstr);

        public List<Contacts> contact = new List<Contacts>();
        Contacts addressBook = new Contacts();

        int counter = 0;
        public bool AddContact()
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
                    //ReadWriteContactIntoCSVFile();
                    //ReadWriteContactIntoTextFile();
                }
            }

            SqlCommand com = new SqlCommand("InsertDataInAddressBook", connection);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@fname", addressBook.fname);
            com.Parameters.AddWithValue("@lname", addressBook.lname);
            com.Parameters.AddWithValue("@address", addressBook.address);
            com.Parameters.AddWithValue("@city", addressBook.city);
            com.Parameters.AddWithValue("@state", addressBook.state);
            com.Parameters.AddWithValue("@zip", addressBook.zip);
            com.Parameters.AddWithValue("@phone", addressBook.phone);
            com.Parameters.AddWithValue("@email", addressBook.email);

            connection.Open();
            int i = com.ExecuteNonQuery();
            connection.Close();
            if (i >= 1)
            {
                Console.WriteLine("Record has bees added in Database");
                return true;

            }
            else
            {

                return false;
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
            try
            {
                using (this.connection)
                {

                    SqlCommand command = new SqlCommand("ShowAddressBook", this.connection);

                    this.connection.Open();

                    SqlDataReader dataReader = command.ExecuteReader();
                    Console.WriteLine("\nAll Empoyees record is:\n");
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            contact.id = dataReader.GetInt32(0);
                            contact.fname = dataReader.GetString(1);
                            contact.lname = dataReader.GetString(2);
                            contact.address = dataReader.GetString(3);
                            contact.city = dataReader.GetString(4);
                            contact.state = dataReader.GetString(5);
                            contact.zip = dataReader.GetString(6);
                            contact.phone = dataReader.GetString(7);
                            contact.email = dataReader.GetString(8);



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
                    }
                    else
                    {
                        Console.WriteLine("No records available");
                    }
                    dataReader.Close();
                    this.connection.Close();
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }

        public bool EditContactPhoneById(int id, string phone)
        {
            try
            {
                Contacts contacts = new Contacts();

                SqlCommand com = new SqlCommand("UpdatePesonsPhoneNumberById", connection);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", id);
                com.Parameters.AddWithValue("@phone", phone);

                connection.Open();
                int i = com.ExecuteNonQuery();
                connection.Close();
                if (i >= 1)
                {
                    Console.WriteLine("Record updated Successfully!!");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
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

        public void ReadWriteInJsonFIle()
        {
            try
            {
                string path = @"C:\Users\Nityanand Gore\source\repos\AddressBook\AddressBook\AddFileData.json";
                foreach (Contacts item in contact)
                {
                    string data_write = JsonConvert.SerializeObject(item);
                    File.WriteAllText(path, data_write);
                }

                string data_read = File.ReadAllText(path);

                var jsonResult = JsonConvert.DeserializeObject<List<Contacts>>(data_read).ToList();
                Console.WriteLine("Reading from json");
                foreach (Contacts item in jsonResult)
                {
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public void RetriveRecordsByPesticularDateRange(DateTime date1, DateTime date2)
        {
            try
            {
                Contacts contact = new Contacts();


                using (this.connection)
                {

                    SqlCommand command = new SqlCommand("RetriveContactInperticularDateRange", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@date1", date1);
                    command.Parameters.AddWithValue("@date2", date2);

                    this.connection.Open();

                    SqlDataReader dataReader = command.ExecuteReader();
                    Console.WriteLine("\nAll Address Book contact Between date range  " + date1 + " and " + date2 + " Are:");
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            contact.id = dataReader.GetInt32(0);
                            contact.fname = dataReader.GetString(1);
                            contact.lname = dataReader.GetString(2);
                            contact.address = dataReader.GetString(3);
                            contact.city = dataReader.GetString(4);
                            contact.state = dataReader.GetString(5);
                            contact.zip = dataReader.GetString(6);
                            contact.phone = dataReader.GetString(7);
                            contact.email = dataReader.GetString(8);

                            Console.WriteLine("Contact Details " +
                            "\nId - " + contact.id +
                           "\nFirst Name - " + contact.fname +
                           "\nLast Name - " + contact.lname +
                           "\nAddress - " + contact.address +
                           "\nCity - " + contact.city +
                           "\nState - " + contact.state +
                           "\nZip - " + contact.zip +
                           "\nPhone Number - " + contact.phone +
                           "\nEmail Id - " + contact.email);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No records found!!");
                    }

                    dataReader.Close();
                    this.connection.Close();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}