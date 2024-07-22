using System;

class Order{
    private List<Product> _products;
    private Customer _customer;
    public Order(Customer customer){

        _customer = customer;
        _products = new List<Product>();
    }
    public void AddProduct(Product product){
        _products.Add(product);
    }
    public double GetTotalPrices(){

        double productsPrices = 0;
        int shippingPrices;
        for (int i = 0; i < _products.Count; i++)
        {   
            Product product = _products[i];
            productsPrices += product.GetTotalPrices();
        }

        if (_customer.InUSA() == true){
            shippingPrices = 5;
        } else {
            shippingPrices = 35;
        }
        return productsPrices + shippingPrices;
    }

    public void GetPackingLabel(){
        Console.WriteLine("Packing Label:");
        for (int i = 0; i < _products.Count; i++)
        {   
            Product product = _products[i];
            Console.WriteLine($"{product.GetID()} - {product.GetName()}");
        }
    }
    public void GetShippingLabel(){
        Console.WriteLine("Shipping Label:");
        Console.WriteLine($"Name: {_customer.GetName()}");
        Address address = _customer.GetAddress();
        Console.WriteLine($"Address: {address.ToString()}");
    }
}