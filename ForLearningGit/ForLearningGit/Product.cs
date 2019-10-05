using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForLearningGit
{
    class Product
    {
        public Guid id { get; private set; }
        public string name { get; private set; }
        private decimal price;
        private DateTime expirationDate = DateTime.Today;

        public Product(string name, decimal price, DateTime? expirationDate = null, Guid? id = null)
        {
            this.id = id ?? Guid.NewGuid();
            this.name = name;
            this.price = price;
            this.expirationDate = expirationDate ?? DateTime.Today;
        }
        
    }
}
