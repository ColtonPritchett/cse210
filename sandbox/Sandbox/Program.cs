using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        Entry input = new Entry();
        int choice = getChoice();
        switch (choice) {
            case 1:
                input.listen();
                journal.Add(input);
                input.clear();
                break;
            case 2:
                journal.Display();
                break;
            case 3:
                
                break;
            case 4:

                break;
            case 5:
                
                break;
            default:
                Console.WriteLine("Please select a valid option");
                break;
        }
    }

    public static int getChoice(){
        int choice;
        do { 
            Console.WriteLine("Please select one of the following choices\n1. Write\n2. Display\n3. Load\n4. Save\n5. Quit\nWhat  would you like to do?");
            choice = int.Parse(Console.ReadLine());
        } while(choice > 0 && choice < 5);
        return choice;
    }
}

class Journal{
    private List<Entry> entries = new List<Entry>();

    public Journal(){

    }

    public Journal(List<Entry> entries){
        this.entries = entries;
    }

    public void Add(Entry entry){
        entries.Add(entry);
    }

    public void RemoveAt(int i){
        entries.RemoveAt(i);
    }

    public void Display(){
        foreach(Entry entry in entries){
            entry.Display();
        }
    }
}

class Entry{
    private string text;

    public Entry(){
        
    }

    public Entry(string text){
        this.text = text;
    }

    public void listen(){
        text = Console.ReadLine();
    }

    public void clear(){
        text = "";
    }

    public void Display(){
        Console.WriteLine(text);
    }
}