using PizzaLibrary.Data;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private Dictionary<string, Customer> _customers; 
        public int Count { get { return _customers.Count; } }

        public CustomerRepository()
        {
            //_customers = new Dictionary<string, Customer>();
            _customers = MockData.CustomerData;

        }

        public void PrintAllClubMembers()
        {
            foreach (Customer customer in _customers.Values)
            {
                if (customer.ClubMember == true)
                {
                    Console.WriteLine($"Customer {customer} is {customer.ClubMember}");
                }
            }
        }

        public void Print(List<Customer> list)
        {
            foreach (Customer customer in list)
            {
                Console.WriteLine(customer);
            }
        }

        

		public List<Customer> GetAllClubMembers()
		{
            List<Customer> clubMembers = new List<Customer>();
			foreach (Customer customer in _customers.Values)
			{
				if (customer.ClubMember)
				{
					clubMembers.Add(customer);
				}
			}
            return clubMembers;
		}

		public void AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
        
        public List<Customer> GetAll()
        {
            //List<Customer> returnList = new List<Customer>();
            //foreach(Customer c in _customers.Values)
            //{
            //    returnList.Add(c);
            //}
            //return returnList; 
            return _customers.Values.ToList();
        }

        public Customer GetCustomerByMobile(string mobile)
        {
            throw new NotImplementedException();
        }

        public void PrintAllCustomers()
        {
            throw new NotImplementedException();
        }

        public void RemoveCustomer(string mobile)
        {
            throw new NotImplementedException();
        }
    }
}
