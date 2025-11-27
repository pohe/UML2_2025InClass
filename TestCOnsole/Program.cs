// See https://aka.ms/new-console-template for more information
using PizzaLibrary.Interfaces;
using PizzaLibrary.Services;

Console.WriteLine("Hello, World!");

ICustomerRepository repo = new CustomerRepository();
Console.WriteLine(repo.Count);