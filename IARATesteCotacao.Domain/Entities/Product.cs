using System;
using System.Collections.Generic;
using System.Text;

namespace IARATesteCotacao.Domain.Entities
{
    public class Product : EntityBase
    {
        protected Product()
        {

        }

        public Product(string name, bool status)
        {
            Name = name;
            Status = status;
        }

        public int ProductId { get; private set; }
        public string Name { get; protected set; }
        public bool Status { get; protected set; }

        public void Update(string name, bool status)
        {
            this.Name = name;
            this.Status = status;
        }

    }
}
