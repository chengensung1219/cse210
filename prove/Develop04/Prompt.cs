using System;
class Prompt{
    private string prompt;
    private bool isUsed;
    public Prompt(string prompt){

        this.prompt = prompt;
        isUsed = false;
    }
    public void Used(){

        isUsed = true;
    }
    public string GetPrompt(){
        return prompt;
    }
    public bool GetUsed(){
        return isUsed;
    }
}
