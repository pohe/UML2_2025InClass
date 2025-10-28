using PizzaLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Models
{
    public class Customer : ICustomer
    {
        public string Address { get; set; }
        public bool ClubMember { get ; set ; }

        public int Id => throw new NotImplementedException();

        public string Mobile { get; set; }
        public string Name { get; set; }

        public Customer(string name, string mobile, string address)
        {
            
        }
    }
}
