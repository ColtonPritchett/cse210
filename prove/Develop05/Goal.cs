using System;

abstract class Goal{
    protected int points;
    protected string name;

    public int GetPoints(){
        return points;
    }

    public string GetName(){
        return name;
    }

    public virtual void Display(){
        Console.WriteLine("Goal: " + name + "\nPoints: " + points);
    }
}

class SimpleGoal : Goal{
    protected bool completed = false;
}

class EternalGoal : Goal{
    protected int timesCompleted = 0;

    public void Complete(){
        timesCompleted++;
    }

    public int GetTimesCompleted(){
        return timesCompleted;
    }
}

class ChecklistGoal : Goal{
    protected int timesCompleted = 0;
    protected int steps;
    protected int reward;

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

    public TimedGoal(){
        start = DateTime.Now;
        end = start.AddDays(7);
        duration = end.Subtract(start);
    }

    public TimedGoal(int _end){
        start = DateTime.Now;
        end = _end;
        duration = end.Subtract(start);
    }

    public void DisplayTimeLeft(){
        TimeSpan timeLeft = new TimeSpan(DateTime.Now.Subtract(start));
        Console.WriteLine(timeLeft.Days + " days, " + timeLeft.Hours + " hours, " + timeLeft.Minutes + " minutes");
    }

    public TimeSpan GetTimeLeft(){
        return 
    }

    public int Complete(){
        TimeSpan timeLeft = new TimeSpan(DateTime.Now.Subtract(start));
        if(timeLeft * 2 >= duration){

        }
    }
}