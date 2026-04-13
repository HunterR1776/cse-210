using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Boise", "ID", "USA");
        Customer customer1 = new Customer("Dylan Rhoads", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Revex Prime, Compound Bow", "P100", 899.99, 1));
        order1.AddProduct(new Product("Arrows", "P101", 125.50, 2));
        order1.AddProduct(new Product("Archery release", "P102", 145.00, 1));

        Address address2 = new Address("456 temple ave", "Toronto", "Ontario", "Canada");
        Customer customer2 = new Customer("Lynae Rhoads", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Hunting Blind", "P200", 199.99, 1));
        order2.AddProduct(new Product("Turkey Decoy", "P201", 45.99, 3));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.CalculateTotalCost():0.00}");
        Console.WriteLine();

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.CalculateTotalCost():0.00}");
    }
}