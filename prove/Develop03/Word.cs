using System;
using System.IO.Compression;

class Word{

    private string content;
    private bool isHide;

    public Word(string content){

        this.content = content;
        isHide = false;

    }

    public void Hide(){

        isHide = true;
    }

    public void Show(){

        isHide = false;
    }

    public string GetContent(){
        return content;
    }

    public bool GetHide(){
        return isHide;
    }

}