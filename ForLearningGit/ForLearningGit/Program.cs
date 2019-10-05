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

            _repository = new Repository();

            var listOfAdmins = new Dictionary<string, string>
            {
                {"Gosha", "777"}, {"Arkasha", "luckystrike"}, {"admin", "1q2w3e4r"}
            };

            Console.WriteLine("Please, enter your Username");
            var userName = Console.ReadLine();
            if (listOfAdmins.ContainsKey(userName))
            {
                Console.WriteLine("Please, enter your password");
                for (var i = 0; i < 3; i++)
                {
                    var checkAdmin = Console.ReadLine();
                    if (checkAdmin == listOfAdmins[userName])
                    {
                        break;
                    }
                    if (i == 2)
                    {
                        Console.WriteLine("Username and password did not match. Access denied.");
                        Console.ReadKey();
                        return;
                    }
                    Console.WriteLine("Password did not match, try again");
                }
            }

            var userResponse = string.Empty;

            while (userResponse != "stop")
            {
                if (!listOfAdmins.ContainsKey(userName) && Enum.TryParse(userResponse, true, out AdminActions _))
                    Console.WriteLine("Access to this action is denied");
                else
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
                Console.WriteLine("What do you want to do?");
                userResponse = Console.ReadLine();
            }

            switch (action)
            {
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
                    FindProductByPattern();
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

        static void FindProductByPattern()
        {
            Console.WriteLine("Enter pattern for name");
            var pattern = Console.ReadLine();
            var result = _repository.FindProductsByPattern(pattern);
            if(result.Count == 0)
                Console.WriteLine("No such products found");
            else
                foreach (var item in result)
                {
                    Console.WriteLine($"Name: {item.name}");
                }
        }
    }

    enum UserActions
    {
        CalculateTotalPrice,
        FindProduct,
        CheckProductExpirationDate,
        ListAllProducts,
        AddProduct,
        DeleteProduct
    }

    enum AdminActions
    {
        AddProduct,
        DeleteProduct
    }
}