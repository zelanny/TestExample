using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForLearningGit
{
    class Program
    {
        static Repository repository;
        static void Main(string[] args)
        {
            string userName = "admin";

            repository = new Repository();
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
                    repository.SetupDummyProducts();
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
                    foreach (var name in repository.ListAllProductNames())
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
            repository.AddProduct(new Product(name, price));
        }

        static void DeleteProduct()
        {
            Console.WriteLine("Enter product id/name");
            var name = Console.ReadLine();
            if (Guid.TryParse(name, out var id))
                repository.DeleteProduct(id);
            else
                repository.DeleteProduct(name);
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