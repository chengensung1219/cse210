using System;

class Product{
    private string Name { get; set; }
    private string ID { get; set; }
    private double UnitPrice { get; set; }
    private int Quantity { get; set; }

    public Product(string name, string id, double unitPrice, int quantity){

        Name = name;
        ID = id;
        UnitPrice = unitPrice;
        Quantity = quantity;
    }

    public string GetName(){
        return Name;
    }
    public string GetID(){
        return ID;
    }
    public double GetUnitPrice(){
        return UnitPrice;
    }
    public int GetQuantity(){
        return Quantity;
    }
    public double GetTotalPrices(){
        double totalPrices = UnitPrice * Quantity;
        return totalPrices;
    }
}