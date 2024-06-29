using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

class SettingGoal
{   
    private string name;
    private string description;
    private int points;
    private bool isComplete;
    private string type;
    private int requiredcount;
    private int currentcount;
    private int extrabonus;
    private List<Goal> goals = new List<Goal>();
    private List<Goal> notCompleteGoal = new List<Goal>();


    private string[] menuItems = {
        "Simple Goal",
        "Eternal Goal",
        "Checklist Goal",
        "Negative Goals",
        "Back to Menu"
    };

    public bool ChooseAndRun()
    {
        Console.Clear();
        Console.WriteLine("\nThe types of Goals are:");
        for (int i = 0; i < menuItems.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {menuItems[i]}");
        }
        
        Console.Write("Which type of goal would you like to create? : ");
        int choice = Convert.ToInt32(Console.ReadLine());
        Console.Clear();

        switch (choice)
        {
            case 1:
                CreateSimpleGoal();
                break;
            case 2:
                CreateEternalGoal();
                break;
            case 3:
                CreateChecklistGoal();
                break;
            case 4:
                CreateNegativeGoal();
                break;
            case 5:
                break;
            default:
                Console.WriteLine("Invalid option please try again.");
                break;
        }
        return true;
    }
    public int GetTotalpoints() {

        int totalpoints = 0;

        for (int i = 0; i < goals.Count; i++)
        {   
            Goal goal = goals[i];
            if (goal.IsComplete == true && goal.Type == "Checklist") {
                totalpoints += 0;
            } else if (goal.IsComplete == true && goal.Type != "Checklist"){
                int point = goal.Points;
                totalpoints += point;
            }
            if (goal.Type == "Eternal" && goal.CurrentCount > 0){
                int point = goal.Points * goal.CurrentCount;
                totalpoints += point;
            }
            if (goal.Type == "Checklist" && goal.CurrentCount > 0){
                int point = goal.Points * goal.CurrentCount;
                totalpoints += point;
                if (goal.CurrentCount == goal.RequiredCount) {
                    int bonus = goal.ExtraBonus;
                    totalpoints += bonus;
                }
            }
            if (goal.Type == "Negative" && goal.CurrentCount > 0){
                int minuspoint = goal.Points * goal.CurrentCount;
                totalpoints += minuspoint;
            }
        }
        return totalpoints;
    }

    public void CreateSimpleGoal()
    {
        Console.Write("What is the name of your goal? ");
        name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        points = int.Parse(Console.ReadLine());

        isComplete = false;

        type = "Simple";

        goals.Add(new SimpleGoal(name, description, points, isComplete, type));


    }
    public void CreateEternalGoal()
    {
        Console.Write("What is the name of your goal? ");
        name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        points = int.Parse(Console.ReadLine());

        isComplete = false;

        type = "Eternal";

        goals.Add(new EternalGoal(name, description, points, isComplete, type));


    }
    public void CreateChecklistGoal()
    {
        Console.Write("What is the name of your goal? ");
        name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        points = int.Parse(Console.ReadLine());
        Console.Write("How many times does this goal need to be accomplished for bonus? ");
        requiredcount = int.Parse(Console.ReadLine());
        Console.Write("What is the bonus for accomplishing it that many times? ");
        extrabonus = int.Parse(Console.ReadLine());

        currentcount = 0;

        isComplete = false;

        type = "Checklist";
        goals.Add(new ChecklistGoal(name, description, points, isComplete, type, requiredcount, currentcount, extrabonus));
    }
    public void CreateNegativeGoal()
    {
        Console.Write("What is the name of your goal? ");
        name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        description = Console.ReadLine();
        Console.Write("If you break or do this goal, how many points will be deducted? [Not include the minus sign] ");
        points = 0 - int.Parse(Console.ReadLine());

        currentcount = 0;

        isComplete = false;

        type = "Negative";
        goals.Add(new NegativeGoal(name, description, points, isComplete, type));
    }

    public void DisplayGoals(){

        for (int i = 0; i < goals.Count; i++)
        {
            Goal goal = goals[i];
            if (goal.Type == "Checklist") {

                if (goal.IsComplete == false) {
                    Console.WriteLine($"{i + 1}. [ ] {goal.Name} ({goal.Description}) -- Current completed: {goal.CurrentCount}/{goal.RequiredCount}");
                }
                else {
                    Console.WriteLine($"{i + 1}. [X] {goal.Name} ({goal.Description}) -- Current completed: {goal.CurrentCount}/{goal.RequiredCount}");
                }

            } else if (goal.Type == "Eternal") {

                Console.WriteLine($"{i + 1}. [∞] {goal.Name} ({goal.Description})");

            } else if (goal.Type == "Negative") {

                Console.WriteLine($"{i + 1}. [-] {goal.Name} ({goal.Description})");

            } else{

                if (goal.IsComplete == false) {
                    Console.WriteLine($"{i + 1}. [ ] {goal.Name} ({goal.Description})");
                }
                else {
                    Console.WriteLine($"{i + 1}. [X] {goal.Name} ({goal.Description})");
                }
            }
            
        }
    }
    public void SaveGoalsToJson(string name = "backup"){
        string filename = $"{name}.json";
        string json = JsonConvert.SerializeObject(goals, Formatting.Indented);
        File.WriteAllText(filename, json);
    }

    public void LoadGoalsToJson(string name = "backup"){
        
        string jsonFilePath = $"{name}.json";

        // Read the JSON file
        string jsonData = File.ReadAllText(jsonFilePath);

        // Deserialize the JSON data into the appropriate Goal objects
        goals = JsonConvert.DeserializeObject<List<Goal>>(jsonData, new GoalConverter());
    }

    public void RecordEvent(){
        int count = 0;
        notCompleteGoal.Clear();
        Console.WriteLine("The goals are:");
        foreach (Goal goal in goals){
            if (goal.IsComplete == false){
                notCompleteGoal.Add(goal);
            }
        }
        for (int i = 0; i < notCompleteGoal.Count; i++)
        {   
            Goal notComplete = notCompleteGoal[i];
            if (notComplete.IsComplete == false) {
                Console.WriteLine($"{count + 1}. {notComplete.Name}");
                count += 1;
            }
        }
        Console.WriteLine("<< If you want to go back to menu, please type '0' to go back >>");
        
        Console.Write("Which goal did you accomplish? ");
        int accomplishNum = int.Parse(Console.ReadLine()) - 1;
        if (accomplishNum >= 0 && accomplishNum < notCompleteGoal.Count)
        {
            Goal accomplishGoal = notCompleteGoal[accomplishNum];
            if (accomplishGoal.Type == "Checklist" && accomplishGoal.CurrentCount < accomplishGoal.RequiredCount){
                accomplishGoal.CurrentCount += 1;

                if (accomplishGoal.CurrentCount < accomplishGoal.RequiredCount){
                    Console.WriteLine($"Congratulations! You have earned {accomplishGoal.Points} point.");
                } 
                else if (accomplishGoal.CurrentCount == accomplishGoal.RequiredCount){
                    accomplishGoal.Complete();
                    Console.WriteLine($"Congratulations! You have earned {accomplishGoal.Points + accomplishGoal.ExtraBonus} point.");
                    notCompleteGoal.RemoveAt(accomplishNum);
                }

            } else if (accomplishGoal.Type == "Eternal"){
                Console.WriteLine($"Congratulations! You have earned {accomplishGoal.Points} point.");
                accomplishGoal.CurrentCount += 1;

            } else if (accomplishGoal.Type == "Negative"){
                Console.WriteLine($"Sorry! You have lost {0 - accomplishGoal.Points} point.");
                accomplishGoal.CurrentCount += 1;
            }else {
                accomplishGoal.Complete();
                Console.WriteLine($"Congratulations! You have earned {accomplishGoal.Points} point.");
                notCompleteGoal.RemoveAt(accomplishNum);
            }
        int currentpoints = GetTotalpoints();
        Console.WriteLine($"You now have {currentpoints} point.");

        } else if (accomplishNum == 0){
            Console.Clear();
        }
    }

    public void DeleteGoal() {

        Console.WriteLine("The goals are:");
        for (int i = 0; i < goals.Count; i++)
        {
            Goal goal = goals[i];
            Console.WriteLine($"{i + 1}. {goal.Name}");
        }
        Console.Write("Which goal do you want to delete? ");
        int deleteOption = int.Parse(Console.ReadLine()) - 1;
        goals.RemoveAt(deleteOption);
    }

    public void Loading(string status, int seconds = 3, int speed = 200) {
        string[] spinner = { "|", "/", "-", "\\" };
        int runTime = seconds * 1000;
        if (status == "load") {
            Console.WriteLine("Loading...");
        } else if (status == "save"){
            Console.WriteLine("Saving...");
        } else {
            Console.WriteLine("Automactivally saving...");
        }
        
        while (runTime > 0) {
            for (int i = 0; i < 3; i++) {
                Console.Write(spinner[i]);
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                System.Threading.Thread.Sleep(speed);
                runTime -= speed;
                Console.Write(" ");
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            }
        }
        Console.Clear();
        if (status == "load") {
            Console.WriteLine("Loading succcessfully!");
        } else {
            Console.WriteLine("Saved successfully!");
        }
    }

    public class GoalConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Goal);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            switch (jo["Type"].Value<string>())
            {
                case "Simple":
                    return jo.ToObject<SimpleGoal>(serializer);
                case "Eternal":
                    return jo.ToObject<EternalGoal>(serializer);
                case "Checklist":
                    return jo.ToObject<ChecklistGoal>(serializer);
                case "Negative":
                    return jo.ToObject<NegativeGoal>(serializer);
                default:
                    throw new Exception("Unknown goal type");
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JToken t = JToken.FromObject(value);
            t.WriteTo(writer);
        }
    }
}