using System;

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        menu.Display();
        menu.Choose();
    }
}

class Menu{
    private string[] options = new[] {"Breathing", "Reflection", "Listing", "Quit"};
    private BreathingActivity ba = new BreathingActivity();
    private ReflectionActivity ra = new ReflectionActivity();
    private ListingActivity la = new ListingActivity();

    public Menu(){

    }

    public void Display(){
        Console.WriteLine("Choose one of the following activities: ");
        for(int i = 0; i < options.Length; i++){
            Console.WriteLine((i + 1) + ". " + options[i]);
        }
        
    }

    public void Choose(){
        int choice = int.Parse(Console.ReadLine());
        Console.Clear();
        switch(choice){
            case 1:
                ba.Start();
                break;
            case 2:
                ra.Start();
                break;
            case 3:
                la.Start();
                break;
            default:
                Console.WriteLine("Have a great day! ");
                break;
        }
        Console.Clear();
        if(choice > 3){
            Display();
            Choose();
        }
    }
}

class Activity{
    protected string name;
    protected string description;
    protected int duration = 1;
    protected string endMessage = "Great job!";
    protected DateTime dt = new DateTime();
    protected string write = "";

    public void Display(){
        write = "Welcome to the " + name + "\n\n" + description + "\n\n";
        Console.WriteLine(write);
    }

    public void AskDuration(){
        write += "For how long do you want to do this activity (in seconds)? ";
        Console.Clear();
        Console.Write(write);
        duration = int.Parse(Console.ReadLine());
    }

    public virtual void Do(){}

    public void Start(){
        Display();
        AskDuration();
        Console.Clear();
        write = "Great ready...";
        Pause(5);
        write += "\n\n";
        Do();
        Write(endMessage + "\n");
        Pause(5);
        Write("You have completed another " + duration  + " seconds of the " + name + "\n");
        Pause(10);
    }

    public void Pause(int reps){
        for(int i = 0; i < reps; i++){
            Write("|", false);
            Thread.Sleep(100);
            Write("/", false);
            Thread.Sleep(100);
            Write("-", false);
            Thread.Sleep(100);
            Write("\\", false);
            Thread.Sleep(100);
        }
    }

    public void Write(string str){
        write += str;
        Console.Clear();
        Console.WriteLine(write);
    }

    public void Write(string str, bool t){
        Console.Clear();
        Console.WriteLine(write + str);
    }
}

class BreathingActivity : Activity{
    public BreathingActivity(){
        name = "Breathing Activity";
        description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public override void Do(){
        int breathCount = (int) (double.Round((double) duration / 12));
        double breathDuration = (double) duration / breathCount;
        Console.Clear();
        write = "";
        for(int i = 0; i < breathCount; i++){
            write += "Breath in...";
            for(int j = (int) breathDuration / 2; j > 0; j--) {
                Write("" + j, false);
                Thread.Sleep(1000);
            }
            write += "\nNow breath out...";
            for(int j = (int) breathDuration / 2; j > 0; j--) {
                Write("" + j, false);
                Thread.Sleep(1000);
            }
            write += "\n\n";
        }
    }
}

class ReflectionActivity: Activity{
    protected string[] prompts = new[] {"Think of a time when you stood up for someone else.", "Think of a time when you did something really difficult.", "Think of a time when you helped someone in need.", "Think of a time when you did something truly selfless."};
    protected string[] questions = new[] {"Why was this experience meaningful to you?", "Have you ever done anything like this before?", "How did you get started?", "How did you feel when it was complete?", "What made this time different than other times when you were not as successful?", "What is your favorite thing about this experience?", "What could you learn from this experience that applies to other situations?", "What did you learn about yourself through this experience?", "How can you keep this experience in mind in the future?"};

    public ReflectionActivity(){
        name = "Reflection Activity";
        description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
    }

    public string ChoosePrompt(){
        return prompts[new Random().Next(0, prompts.Length)];
    }

    public override void Do(){
        Write("Consider the following prompt: \n\n" + ChoosePrompt() + "\n\nWhen you have something in mind, press enter to continue. \n\n");
        Console.ReadLine();

        List<int> asked = new List<int>();
        int questionCount = (int) (double.Round((double) duration / 10));
        double questionDuration = (double) duration / questionCount;
        Random rand = new Random();
        int temp = 0;

        Write("Now ponder each of the following questions as they relate to this experience. \nYou may begin in ");

        for(int i = 0; i < 5; i++){
            Write("" + (5 - i), false);
            Thread.Sleep(1000);
        }

        for(int i = 0; i < questions.Length; i++){
            asked.Add(i);
        }

        write = "";

        for(int i = 0; i < questionCount; i++){
            temp = rand.Next(0, questionCount - i);
            Write(questions[asked[temp]] + "\n\n");
            asked.RemoveAt(temp);
            Thread.Sleep((int) (1000 * questionDuration));
        }
    }
}

class ListingActivity : Activity{
    protected string[] prompts = new[] {"Who are people that you appreciate?", "What are personal strengths of yours?", "Who are people that you have helped this week?", "When have you felt the Holy Ghost this month?", "Who are some of your personal heroes?"};
    
    public ListingActivity(){
        name = "Listing";
        description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    public override void Do(){
        Write(prompts[new Random().Next(0, prompts.Length)] + "\nYou may begin in: ");
        for(int i = 0; i < 5; i++){
            Write("" + (5 - i), false);
            Thread.Sleep(1000);
        }
        int start = DateTime.Now.Second, count = 0;
        while(start + duration > DateTime.Now.Second){
            Console.ReadLine();
            count++;
        }
        Write("The number of items that you wrote was " + count + ".\n");
    }
}