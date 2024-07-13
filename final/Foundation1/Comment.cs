using System;
using System.Runtime.CompilerServices;

class Comment{
    private string Name;
    private string Text;

    public Comment(string name, string text){

        Name = name;
        Text = text;
    }

    public string GetName(){

        return Name;
    }

    public string GetText(){
        
        return Text;
    }
}