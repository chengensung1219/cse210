using System;

class Address{
    private string Street;
    private string City;
    private string State;
    private string Country;
    private int ZipCode;
    public Address(string street, string city, string state, int zipCode, string country){

        Street = street;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipCode;
    }
    public string GetStreet(){
        return Street;
    }
    public string GetCity(){
        return City;
    }
    public string GetState(){
        return State;
    }
    public string GetCountry(){
        return Country;
    }
    public int GetZipCode(){
        return ZipCode;
    }
    public override string ToString(){
        return $"{Street} {City}, {State} {ZipCode}, {Country}";
    }

    public bool InUSA(){
        if (Country == "USA" || Country == "United States"){
            return true;
        } else {
            return false;
        }
    }   
}