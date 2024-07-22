using System;

class Product{
    private string Name;
    private string ID;
    private double UnitPrice;
    private int Quantity;

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