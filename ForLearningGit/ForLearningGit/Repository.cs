using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForLearningGit
{
    class Repository
    {
        private List<Product> ProductAssorty;

        public Repository()
        {
            ProductAssorty = new List<Product>();
            SetupDummyProducts();
        }

        public void SetupDummyProducts()
        {
            AddProduct("Iron", 160, new DateTime(2019, 10, 04));
            AddProduct("Ore",   80, new DateTime(2019, 10, 03));
            AddProduct("Steel",170, new DateTime(2019, 09, 27));
        }

        public void AddProduct(Product product)
        {
            if (ProductAssorty.Exists(x => x.name == product.name))
            {
                throw new ArgumentException("The item with such name is already exist");
            }
            ProductAssorty.Add(product);
        }

        public List<string> ListAllProductNames()
        {
            return ProductAssorty.Select(x => x.name).ToList();
        }

        public List<Product> FindProductsByPattern(string pattern)
        {
            return ProductAssorty.Where(x => x.name.ToLower().Contains(pattern.ToLower())).ToList();
        }

        public void AddProduct(string name, decimal price, DateTime expirationDate)
        {
            if (ProductAssorty.Exists(x => x.name == name))
            {
                throw new ArgumentException("The item with such name is already exist");
            }
            ProductAssorty.Add(new Product(name, price, expirationDate));
        }

        public void DeleteProduct(string name)
        {
            ProductAssorty.Remove(ProductAssorty.Find(x => string.Equals(x.name, name, StringComparison.CurrentCultureIgnoreCase)));
        }

        public void DeleteProduct(Guid id)
        {
            ProductAssorty.Remove(ProductAssorty.Find(x => x.id == id));
        }
    }
}
