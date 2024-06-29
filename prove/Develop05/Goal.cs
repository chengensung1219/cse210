using System;
using Newtonsoft.Json;
abstract class Goal{

    public string Name { get; set; }
    public string Description { get; set; }
    public int Points { get; set; }
    public bool IsComplete { get; set; }  
    public string Type { get; set; }  
    public int RequiredCount { get; set; }
    public int CurrentCount { get; set; }
    public int ExtraBonus { get; set; }

    public Goal(string name, string description, int points, bool complete, string type)
    {
        Name = name;
        Description = description;
        Points = points;
        IsComplete = complete;
        Type = type;
    }
    public Goal(string name, string description, int points, bool complete, string type, int requiredcount, int currentcount, int extrabonus)
    {
        Name = name;
        Description = description;
        Points = points;
        IsComplete = complete;
        Type = type;
        RequiredCount = requiredcount;
        CurrentCount = currentcount;
        ExtraBonus = extrabonus;
    }
    public void Complete(){
        IsComplete = true;
    }
}

class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points, bool complete, string type) : base(name, description, points, complete, type)
    {

    }
}

class EternalGoal : Goal{

    public EternalGoal(string name, string description, int points, bool complete, string type) : base(name, description, points, complete, type)
    {
        
    }

}

class ChecklistGoal : Goal{

    public ChecklistGoal(string name, string description, int points, bool complete, string type, int requiredcount, int currentcount, int extrabonus) : base(name, description, points, complete, type, requiredcount, currentcount, extrabonus)
    {
        
    }
}
class NegativeGoal : Goal{
    public NegativeGoal (string name, string description, int points, bool complete, string type) : base(name, description, points, complete, type){

    }
}