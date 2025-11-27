using PizzaLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Models
{
    public class VIPCustomer:Customer
    {
        private int _discount; 
        public int Discount
        {
            get { return _discount; }
            set
            {
                if (value > 25 || value < 1)
                {
                    throw new InvalidDiscountException("Ivalid discount");
                    //throw new InvalidDiscountException();
                }
                else
                {
                    _discount = value;
                }
            }
        }

        public VIPCustomer(string name, string mobile, string address, int discount)
            :base(name, mobile,address)
        {
            if (discount < 1 || discount >25)
            {
                throw new InvalidDiscountException("Illegal discount"); 
            }
            Discount = discount;
  
        }

        public override string ToString()
        {
            return base.ToString() + " Kundetype er VIPCustomer Discount=" + Discount;
        }

    }
}
