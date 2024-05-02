using System;

class Greeter
{

    public string name;

    public Greeter(string name)
    {
        this.name = name;
    }
    public void Greet()
    {
        Console.WriteLine($"Hello, {this.name}!");
    }
}

Greeter g = new Greeter("Steve")
Greeter c = new Greeter("Bob")

g.Greet()
c.Greet()