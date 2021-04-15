using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppFirstTimeMVC.Models
{
    public class FileMessagesService : IMessagesService
    {
        public List<string[]> GetAll()
        {
            List<string[]> listOfContacts = new List<string[]>(); // Create an empty list and try to read the file "messages.txt"

            try
            {
                using (StreamReader reader = new StreamReader("messages.txt"))
                {
                    while (true)
                    {
                        string name = reader.ReadLine();
                        if (name == null)
                        {
                            break;
                        }
                        string email = reader.ReadLine();
                        string message = reader.ReadLine();
                        listOfContacts.Add(new string[] { name, email, message });
                    }
                }
            }
            catch (Exception)
            {
                using (var writer = new StreamWriter("messages.txt")) { };  // Create an empty file with nothing in it
            }

            return listOfContacts;
        }

        public bool Save(string name, string email, string message)
        {
            try
            {
                // Use var type which is shorter.
                using (var writer = new StreamWriter("messages.txt", true))     // Writing the file "messages.txt"
                {
                    // Write format string to file.
                    writer.WriteLine(name);
                    writer.WriteLine(email);
                    writer.WriteLine(message);
                }
                return true;
            }
            catch (Exception)       // If the memory is full or similar
            {
                return false;
            }
        }
    }
}