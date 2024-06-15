using System;
class Topic{
    private string topic;
    private bool isUsed;
    public Topic(string topic){

        this.topic = topic;
        isUsed = false;
    }
    public void Used(){

        isUsed = true;
    }
    public string GetTopic(){
        return topic;
    }
    public bool GetUsed(){
        return isUsed;
    }
}
