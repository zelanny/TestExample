using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForLearningGit
{
    class Product
    {
        private Guid id;
        private string name;
        private double price;
        private DateTime expirationDate = DateTime.Today;

        public Product(Guid id, string name, double price, DateTime expirationDate)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.expirationDate = expirationDate;
        }
    }
}
