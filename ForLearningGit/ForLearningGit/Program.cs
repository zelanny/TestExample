using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForLearningGit
{
    class Program
    {
        static void Main(string[] args)
        {
            var ListOfAdmins = new Dictionary<String, String>();
            ListOfAdmins.Add("Gosha", "777");
            ListOfAdmins.Add("Arkasha", "luckystrike");
            ListOfAdmins.Add("Deineris", "Drakaris");

            Console.WriteLine("Please, enter your Username");
            String Answer1 = Console.ReadLine();
            if (ListOfAdmins.ContainsKey(Answer1))
            {
                Console.WriteLine("Please, enter your password");
                for (int i = 0; i < 3; i++)
                {
                    String CheckAdmin = Console.ReadLine();
                    if (CheckAdmin == ListOfAdmins[Answer1])
                    {
                        break;
                    }
                    if (i == 2)
                    {
                        Console.WriteLine("Username and password did not match. Access denied.");
                        return;
                    }
                    Console.WriteLine("Password did not match, try again");
                }
            }
        }
    }
}
