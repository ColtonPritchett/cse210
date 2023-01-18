using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job("Prairie Falls Golf Club", "Landscaper", 2018, 2018);
        Job job2 = new Job("Gun Fighters Inc.", "Assembly Line Worker", 2019, 2022);
        List<Job> jobs = new List<Job>();
        jobs.Add(job1);
        jobs.Add(job2);
        Resume resume = new Resume("Colton Pritchett", jobs);
        resume.Display();
    }
}

public class Job{
    string _company, _jobTitle, _position;
    int _startYear, _endYear;
    public Job(string company, string jobTitle, int startYear, int endYear){
        _company = company;
        _jobTitle = jobTitle;
        _startYear = startYear;
        _endYear = endYear;
        _position = _jobTitle + " (" + _company + ") " + _startYear + "-" + _endYear;
    }

    public void Display(){
        Console.WriteLine(_position);
    }
}

public class Resume{
    string _name;
    List<Job> _jobs;

    public Resume(string name, List<Job> jobs){
        _name = name;
        _jobs = jobs;
    }

    public void Display(){
        Console.WriteLine("Name: " + _name);
        Console.WriteLine("Jobs:");

        foreach(Job i in _jobs){
            i.Display();
        }
    }
}