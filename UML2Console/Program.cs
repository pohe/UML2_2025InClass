// See https://aka.ms/new-console-template for more information
using PizzaLibrary.Models;
using PizzaLibrary.Services;

Console.WriteLine("Hello, World!");


CustomerRepository cRepo = new CustomerRepository();
Console.WriteLine("Antal kunder i kartoteket " +  cRepo.Count);

List<Customer> allCustomers= cRepo.GetAll();
foreach(Customer c in allCustomers)
{
    Console.WriteLine(c.ToString());
}
Console.WriteLine("Clubmembers");
//cRepo.PrintAllClubMembers();
cRepo.Print(cRepo.GetAllClubMembers());