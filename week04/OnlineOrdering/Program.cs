using System;

// NOTE TO INSTRUCTOR:
// I adapted the shipping logic to use Ghana as the base country 
// instead of USA to match my local context, since I live in Ghana.
// - Ghana shipping = $5
// - Non-Ghana shipping = $35
// All encapsulation principles are still demonstrated, with 
// private member variables and public methods for controlled access.

class Program
{
    static void Main(string[] args)
    {
        // ORDER 1: Ghana Customer
        Address address1 = new Address("123 Mensah Street", "Accra", "GR", "Ghana");
        Customer customer1 = new Customer("John Mahama", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "LP001", 399.99, 1));
        order1.AddProduct(new Product("Wireless Mouse", "WM002", 20.50, 2));
        order1.AddProduct(new Product("USB Cable", "UC003", 5.99, 3));

        // ORDER 2: Non-Ghana Customer (USA)
        Address address2 = new Address("123 Main Street", "New York", "NY", "USA");
        Customer customer2 = new Customer("Kanye West", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Smartphone", "SP004", 549.00, 1));
        order2.AddProduct(new Product("Phone Case", "PC005", 35.99, 1));

        // DISPLAY ORDER 1
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice():F2}");
        Console.WriteLine();

        // DISPLAY ORDER 2
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice():F2}");
        Console.WriteLine();
    }
}