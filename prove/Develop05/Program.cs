using System;
using Internal;

class Program
{
    public static string filename = "file.txt";
    protected static int score = 0;
    protected static List<Goal> goals;

    static void Main(string[] args)
    {
        List<string> usernames = new List<string>();
        Menu menu = new Menu();
        Load();
    }

    static void Save(){
        using(StreamWriter writer = new StreamWriter(filename)){
            writer.Write("");
            
        }
    }

    static void Load(){
        List<string> read = new List<string>();
        using(StreamReader reader = new StreamReader(filename)){
            read.Add(reader.ReadLine());
        }
        score = int.Parse(read[0]);
        for(int i = 1; i < read.Count; i++){
            switch(read[i]){
                case "s":
                    goals.Add(new SimpleGoal(read[i]));
                    break;
                case "e":
                    goals.Add(new EternalGoal(read[i]));
                    break;
                case "c":
                    goals.Add(new ChecklistGoal(read[i]));
                    break;
                case "t":
                    goals.Add(new TimedGoal(read[i]));
                    break;
            }
        }
    }
}

public class Menu{
    
}