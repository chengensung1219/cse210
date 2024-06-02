using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;

class Scripture{

    private Reference reference;
    private List<Word> words;

    public Scripture (Reference reference, string content){
        this.reference = reference;
        words = [];
    }

    public void Split(string content){

        string[] splitWord = content.Split(" ");

        foreach (string item in splitWord){

            Word word = new Word(item);
            words.Add(word);
        }
    }

    public void Display(){
        
        string scripture = "";

        foreach (Word word in words){

            if (word.GetHide() == false){

                scripture += word.GetContent();

            }
            else{

                string hidenWord = word.GetContent();

                for (int i = 0; i < hidenWord.Length; i++){
                    scripture += "_";
                }
            }
                scripture += " ";
        }
        Console.WriteLine($"{reference.ToString()} {scripture}");
    }

    public void Hide(){

        Random random = new Random();
        int count = 0;
        int i = 0;

        while (count < 3){

            foreach (Word word in words){

                if (word.GetHide() == true){
                    i += 1;
                }
            }
        
            if (i == words.Count){
                return;
            }
        

            int randomIndex = random.Next(0, words.Count);
            if (words[randomIndex].GetHide() == false){
                words[randomIndex].Hide();
                count += 1;
            }
        }
    }

    public bool AllWordsHidden()
    {
        return words.All(word => word.GetHide());
    }
}
