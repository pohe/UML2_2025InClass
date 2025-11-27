// See https://aka.ms/new-console-template for more information
using PizzaLibrary.Exceptions;
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

CompanyInfo c1 = CompanyInfo.Instance;
c1.Name = "Big Mamma";

//CompanyInfo c2 = new CompanyInfo();

CompanyInfo c2 = CompanyInfo.Instance;
Console.WriteLine(c2.Name);
try
{
    VIPCustomer vipC = new VIPCustomer("Peter", "121212", "Vej 123", 25);
    vipC.Discount = 26;

}
catch(InvalidDiscountException ide)
{
    Console.WriteLine(ide.Message);
}
catch(Exception exp)
{
    Console.WriteLine(exp.Message);
}