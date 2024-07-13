using System;

class Customer{
    private string Name;
    private Address Address;
    public Customer(string name, Address address){

        Name = name;
        Address = address;
    }
    public string GetName(){
        return Name;
    }
    public Address GetAddress(){
        return Address;
    }
    public bool InUSA()
    {
        return Address.InUSA();
    }

}