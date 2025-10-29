// See https://aka.ms/new-console-template for more information
using PizzaLibrary.Services;

Console.WriteLine("Hello, World!");


CustomerRepository cRepo = new CustomerRepository();
Console.WriteLine("Antal kunder i kartoteket " +  cRepo.Count);