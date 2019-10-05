using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForLearningGit
{
    class Program
    {
        static Repository _repository;
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

            _repository = new Repository();
            var userResponse = string.Empty;

            while (userResponse != "stop")
            {
                InteractWithUser(userResponse);
                Console.WriteLine("What do you want to do?");
                userResponse = Console.ReadLine();
            }
        }

        static void InteractWithUser(string userResponse)
        {
            UserActions action;

            while (!Enum.TryParse(userResponse, true, out action))
            {
                Console.WriteLine("Such action is not available");
                Console.WriteLine("What do you want to do?");
                userResponse = Console.ReadLine();
            }

            switch (action)
            {
                case UserActions.SetupDummyProducts:
                {
                    _repository.SetupDummyProducts();
                    break;
                }
                case UserActions.AddProduct:
                {
                    AddProduct();
                    break;
                }
                case UserActions.DeleteProduct:
                {
                    DeleteProduct();
                    break;
                }
                case UserActions.ListAllProducts:
                {
                    foreach (var name in _repository.ListAllProductNames())
                    {
                        Console.WriteLine(name);
                    }

                    break;
                }
                case UserActions.FindProduct:
                {
                    break;
                }
            }
        }

        static void AddProduct()
        {
            Console.WriteLine("Enter product name");
            var name = Console.ReadLine();
            Console.WriteLine("Enter price");
            var price = decimal.Parse(Console.ReadLine());
            _repository.AddProduct(new Product(name, price));
        }

        static void DeleteProduct()
        {
            Console.WriteLine("Enter product id/name");
            var name = Console.ReadLine();
            if (Guid.TryParse(name, out var id))
                _repository.DeleteProduct(id);
            else
                _repository.DeleteProduct(name);
        }
    }

    enum UserActions
    {
        CalculateTotalPrice,
        FindProduct,
        CheckProductExpirationDate,
        ListAllProducts,
        SetupDummyProducts,
        AddProduct,
        DeleteProduct
    }

    enum AdminActions
    {
        SetupDummyProducts,
        AddProduct,
        DeleteProduct
    }
}