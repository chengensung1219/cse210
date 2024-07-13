using System;

class Order{
    private List<Product> Products;
    private Customer Customer;
    public Order(Customer customer){

        Customer = customer;
        Products = new List<Product>();
    }
    public void AddProduct(Product product){
        Products.Add(product);
    }
    public double GetTotalPrices(){

        double productsPrices = 0;
        int shippingPrices;
        for (int i = 0; i < Products.Count; i++)
        {   
            Product product = Products[i];
            productsPrices += product.GetTotalPrices();
        }

        if (Customer.InUSA() == true){
            shippingPrices = 5;
        } else {
            shippingPrices = 35;
        }
        return productsPrices + shippingPrices;
    }

    public void GetPackingLabel(){
        Console.WriteLine("Packing Label:");
        for (int i = 0; i < Products.Count; i++)
        {   
            Product product = Products[i];
            Console.WriteLine($"{product.GetID()} - {product.GetName()}");
        }
    }
    public void GetShippingLabel(){
        Console.WriteLine("Shipping Label:");
        Console.WriteLine($"Name: {Customer.GetName()}");
        Address address = Customer.GetAddress();
        Console.WriteLine($"Address: {address.ToString()}");
    }
}