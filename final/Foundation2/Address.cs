using System;

class Address{
    private string _street;
    private string _city;
    private string _state;
    private string _country;
    private int _zipCode;
    public Address(string street, string city, string state, int zipCode, string country){

        _street = street;
        _city = city;
        _state = state;
        _country = country;
        _zipCode = zipCode;
    }
    public string GetStreet(){
        return _street;
    }
    public string GetCity(){
        return _city;
    }
    public string GetState(){
        return _state;
    }
    public string GetCountry(){
        return _country;
    }
    public int GetZipCode(){
        return _zipCode;
    }
    public override string ToString(){
        return $"{_street} {_city}, {_state} {_zipCode}, {_country}";
    }

    public bool InUSA(){
        if (_country == "USA" || _country == "United States"){
            return true;
        } else {
            return false;
        }
    }   
}