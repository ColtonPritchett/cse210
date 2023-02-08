using System;

class Program
{
    static Journal journal = new Journal();

    static void Main(string[] args)
    {
        int choice = 0;
        while(choice != 6){
            choice = getChoice();
            menu(choice);
        }
    }

    public static int getChoice(){
        int choice;
        do { 
            Console.WriteLine("Please select one of the following choices\n1. Write\n2. Display\n3. Load\n4. Save\n5. Clear\n6. Quit\nWhat  would you like to do?");
            choice = int.Parse(Console.ReadLine());
        } while(choice < 0 && choice > 6);
        return choice;
    }

    public static void menu(int choice){
        Medium medium = new Medium();
        switch (choice) {
            case 1:
                journal.Add(medium.Prompt());
                break;
            case 2:
                journal.Display();
                break;
            case 3:
                journal.Add(medium.Read());
                break;
            case 4:
                medium.Write(journal);
                break;
            case 5:
                medium.Clear();
                break;
            case 6:
                Console.WriteLine("Goodbye!");
                break;
            default:
                Console.WriteLine("Please select a valid option");
                choice = getChoice();
                break;
        }
    }
}

class Journal{
    private string entries = "";

    public Journal(){

    }

    public Journal(string entries){
        this.entries = entries;
    }

    public void Add(string entry){
        
        entries += "" + DateTime.Today + " " + entry;
    }

    public void Display(){
        Console.WriteLine(toString());
    }

    public string toString(){
        return entries;
    }
}

class Medium{
    StreamReader sr;
    StreamWriter sw;
    private string[] prompts = {"Who was the most interesting person I interacted with today?", "What was the best part of my day?", "How did I see the hand of the Lord in my life today?", "What was the strongest emotion I felt today?", "If I had one thing I could do over today, what would it be?"};


    public string Prompt(){
        Random rand = new Random();
        Console.WriteLine(prompts[rand.Next(0, prompts.Length)]);
        return Console.ReadLine() + "\n";
    }

    public string Read(){
        Console.WriteLine("What is the name of the file you wish to load?");
        string filename = Console.ReadLine();
        sr = new StreamReader(filename);
        string line = sr.ReadLine();
        string text = "";
        while(line != null){
            text += line + "\n";
            line = sr.ReadLine();
        }
        Console.WriteLine("Loaded!");
        sr.Close();
        return text;
    }

    public void Write(Journal journal){
        Console.WriteLine("What is the name of the file you wish to save?");
        string filename2 = Console.ReadLine();
        sw = new StreamWriter(filename2);
        sw.WriteLine(journal.toString());
        Console.WriteLine("Saved!");
        sw.Close();
    }

    public void Clear(){
        Console.WriteLine("What is the name of the file you wish to clear?");
        string filename2 = Console.ReadLine();
        File.Create(filename2);
        Console.WriteLine("Cleared!");
    }
}