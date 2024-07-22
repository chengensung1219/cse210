using System;

class Product{
    private string _name;
    private string _id;
    private double _unitPrice;
    private int _quantity;

    public Product(string name, string id, double unitPrice, int quantity){

        _name = name;
        _id = id;
        _unitPrice = unitPrice;
        _quantity = quantity;
    }

    public string GetName(){
        return _name;
    }
    public string GetID(){
        return _id;
    }
    public double GetUnitPrice(){
        return _unitPrice;
    }
    public int GetQuantity(){
        return _quantity;
    }
    public double GetTotalPrices(){
        double totalPrices = _unitPrice * _quantity;
        return totalPrices;
    }
}