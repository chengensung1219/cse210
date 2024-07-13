using System;

class Program
{
    static void Main(string[] args)
    {
        Customer customer1 = new Customer("Simon", new Address("650 S 1st W", "Rexburg", "Idaho", 83440, "USA"));
        Customer customer2 = new Customer("Cristy", new Address("No. 23, Ln. 10, Tianxiang 1st Rd.", "Sanmin Dist.", "Kaohsiung", 807074, "Taiwan(R.O.C.)"));

        Order order1 = new Order(customer1);
        Order order2 = new Order(customer2);

        order1.AddProduct(new Product("MacBook Pro 14-inch", "M001", 1599.00, 1));
        order1.AddProduct(new Product("iPad Pro 11-inch", "A001", 999.00, 2));
        order1.AddProduct(new Product("Polishing Cloth", "C001", 19.00, 5));

        order2.AddProduct(new Product("Apple Watch Series 9", "W001", 399.00, 2));
        order2.AddProduct(new Product("Apple Vision Pro", "V001", 3499.00, 1));
        order2.AddProduct(new Product("iPhone 15 Pro", "P001", 999.00, 1));

        Console.Clear();
        order1.GetPackingLabel();
        order1.GetShippingLabel();
        Console.WriteLine($"Total Cost: ${order1.GetTotalPrices()}\n");

        order2.GetPackingLabel();
        order2.GetShippingLabel();
        Console.WriteLine($"Total Cost: ${order2.GetTotalPrices()}\n");
    }
}