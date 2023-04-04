using System;

abstract class Goal{
    protected int points;
    protected string name;
    protected string type = "g";

    public Goal(){

    }

    public Goal(int points, string name){
        this.points = points;
        this.name = name;
    }

    public Goal(string read){
        Load(read);
    }

    public int GetPoints(){
        return points;
    }

    public string GetName(){
        return name;
    }

    public virtual int Complete(){
        return 0;
    }

    public override string ToString(){
        return type + "," + name + "," + points;
    }

    public virtual void Load(string read){
        string[] inputs = read.Split(',');
        type = inputs[0];
        name = inputs[1];
        points = int.Parse(inputs[2]);
    }

    public virtual void Display(){
        Console.WriteLine("Goal: " + name + "\nPoints: " + points);
    }
}

class SimpleGoal : Goal{
    protected bool completed = false;

    public SimpleGoal(string read){
        Load(read);
        type = "s";
    }

    public override int Complete(){
        if(!completed) {
            completed = true;
            return points;
        }
        return 0;
    }

    public override string ToString(){
        return base.ToString() + "," + completed;
    }

    public override void Load(string read){
        base.Load(read);
        string[] inputs = read.Split(',');
        completed = bool.Parse(inputs[3]);
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine("Completed: " + completed);
    }
}

class EternalGoal : Goal{
    protected int timesCompleted = 0;

    public EternalGoal(string read){
        Load(read);
        type = "e";
    }

    public override int Complete(){
        timesCompleted++;
        return points;
    }

    public int GetTimesCompleted(){
        return timesCompleted;
    }

    public override string ToString()
    {
        return base.ToString() + "," + timesCompleted;
    }

    public override void Load(string read){
        base.Load(read);
        string[] inputs = read.Split(',');
        timesCompleted = int.Parse(inputs[3]);
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine("Times completed: " + timesCompleted);
    }
}

class ChecklistGoal : Goal{
    protected int timesCompleted = 0;
    protected int steps;
    protected int reward;

    public ChecklistGoal(string read){
        Load(read);
        type = "c";
    }

    public ChecklistGoal(int points, string name, int steps, int reward){
        this.points = points;
        this.name = name;
        this.steps = steps;
        this.reward = reward;
    }

    public override int Complete(){
        if(timesCompleted < steps) return points;
        else if (timesCompleted == steps) return reward;
        else return 0;
    }

    public override string ToString(){
        return base.ToString() + "," + timesCompleted + "," + steps + "," + reward;
    }

    public override void Load(string read){
        base.Load(read);
        string[] inputs = read.Split(',');
        timesCompleted = int.Parse(inputs[3]);
        steps = int.Parse(inputs[4]);
        reward = int.Parse(inputs[5]);
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine("\nProgress: " + timesCompleted + "/" + steps + "\nEnd reward: " + reward);
    }
}

class TimedGoal : Goal{
    protected DateTime start;
    protected DateTime end;
    protected TimeSpan duration;

    public override void Display()
    {
        base.Display();
        Console.WriteLine("\nStart date: " + start.Date + "\nEnd date: " + end.Date);
    }

    public TimedGoal(string read){
        Load(read);
        type = "t";
    }

    public TimedGoal(int points, string name){
        this.points = points;
        this.name = name;
        start = DateTime.Now;
        end = start.AddDays(7);
        duration = end.Subtract(start);
        type = "t";
    }

    public TimedGoal(int points, string name, int days){
        this.points = points;
        this.name = name;
        start = DateTime.Now;
        end = start.AddDays(days);
        duration = end.Subtract(start);
        type = "t";
    }

    public void DisplayTimeLeft(){
        TimeSpan timeLeft = GetTimeLeft();
        Console.WriteLine(timeLeft.Days + " days, " + timeLeft.Hours + " hours, " + timeLeft.Minutes + " minutes");
    }

    public TimeSpan GetTimeLeft(){
        return end.Subtract(DateTime.Now);
    }

    public override int Complete(){
        TimeSpan timeLeft = GetTimeLeft();
        //User gets double points if done in less than half of the given time. 
        if(timeLeft * 2 >= duration) return points * 2;
        else return points;
    }

    public override string ToString(){
        return base.ToString() + "," + start.ToString() + "," + end.ToString();
    }

    public override void Load(string read){
        base.Load(read);
        string[] inputs = read.Split(',');
        //TODO: load/save TimeSpan and DateTime objects as text
    }
}