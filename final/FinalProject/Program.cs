using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;

namespace DeserializeExtra{
class Program
{
    private static Library[] bom = new Library[5];
    private static Biblioteca notes = new Biblioteca();
    private static Dictionary<string, int>[] bookNames = new Dictionary<string, int>[5];

    static void Main(string[] args)
    {
        //Read json files
        bom[0] = JsonSerializer.Deserialize<Library>(new StreamReader("old-testament.json").ReadToEnd());
        bom[1] = JsonSerializer.Deserialize<Library>(new StreamReader("new-testament.json").ReadToEnd());
        bom[2] = JsonSerializer.Deserialize<Library>(new StreamReader("book-of-mormon.json").ReadToEnd());
        bom[3] = JsonSerializer.Deserialize<Library>(new StreamReader("doctrine-and-covenants.json").ReadToEnd());
        bom[4] = JsonSerializer.Deserialize<Library>(new StreamReader("pearl-of-great-price.json").ReadToEnd());

        StreamReader sr = new StreamReader("notes.json");
        notes = JsonSerializer.Deserialize<Biblioteca>(sr.ReadToEnd());
        sr.Close();

        //Catalog book names
        for(int i = 0; i < 5; i++){
            bookNames[i] = new Dictionary<string, int>();
            for(int j = 0; j < bom?[i].books?.Count; j++){
                bookNames[i].Add(bom[i].books[j].book, j);
            }
        }
        Console.WriteLine(notes.notebooks[0].name);
        ChooseActivity();
        string jsonString = JsonSerializer.Serialize(notes, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("notes.json", jsonString);
    }

    public static string InterpretInput(string input){
        if(input.ToLower() == "random"){
            int library = new Random().Next(0, 4);
            int book = new Random().Next(0, bom[library].books.Count);
            int chapter = new Random().Next(0, bom[library].books[book].chapters.Count);
            input = bom[library].books[book].chapters[chapter].verses[new Random().Next(0, bom[library].books[book].chapters[chapter].verses.Count)].reference;
            Console.WriteLine(input);
        }
        string[] inputs = input.Split(new[] {' ', ':', '-'});
        string verses = "";
        if(inputs[0].Length == 1){
            inputs[0] += " " + inputs[1];
            inputs[1] = inputs[2];
            inputs[2] = inputs[3];
            if(input.Contains("-")) inputs[3] = inputs[4];
        }
        if(input.Contains("-")){
            for(int j = 0; j < 5; j++){
                if(bookNames[j].ContainsKey(inputs[0])){
                    for(int i = int.Parse(inputs[2]); i <= int.Parse(inputs[3]); i++){
                        verses += i.ToString() + ". " + bom?[j].books?[bookNames[j][inputs[0]]].chapters?[int.Parse(inputs[1]) - 1].verses?[i - 1].text + "\n";
                    }
                }
            }
        }
        else {
            for(int j = 0; j < 5; j++){
                if(bookNames[j].ContainsKey(inputs[0])){
                    verses += inputs[2] + ". " + bom?[j].books?[bookNames[j][inputs[0]]].chapters?[int.Parse(inputs[1]) - 1].verses?[int.Parse(inputs[2]) - 1].text;
                }
            }
        }
        return verses;
    }

    public static void ChooseActivity(){
        Console.WriteLine("Choose one of the following activities: ");
        Console.WriteLine("1. Open notebook");
        Console.WriteLine("2. Create new notebook");
        Console.WriteLine("3. Read scriptures");
        Console.WriteLine("4. Exit");

        int choice = int.Parse(Console.ReadLine());
        switch(choice){
            case 1:
                ChooseAction(ChooseNotebook());
                break;
            case 2:
                notes.CreateNotebook();
                ChooseAction(notes.notebooks.Count - 1);
                break;
            case 3:
                Console.WriteLine("What would you like to read? ");
                Console.WriteLine(InterpretInput(Console.ReadLine()));
                break;
            case 4:
                Console.WriteLine("Thanks for using NoteTaker2000™");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Please choose a valid option. ");
                ChooseActivity();
                break;
        }
    }

    public static int ChooseNotebook(){
        Console.WriteLine("Choose one of the following notebooks: ");
        int i = 1;
        foreach(Notebook book in notes.notebooks){
            Console.WriteLine(i++ + ". " + book.name);
        }
        return int.Parse(Console.ReadLine()) - 1;
    }

    public static void ChooseAction(int notebookChoice){
        Notebook notebook = notes.notebooks[notebookChoice];
        Console.WriteLine("What do you wish to do with \'" + notebook.name + "\'?");
        Console.WriteLine("1. Display notes");
        Console.WriteLine("2. Edit notes");
        Console.WriteLine("3. Create new note");
        Console.WriteLine("4. Delete notebook");
        Console.WriteLine("5. Return to main menu");
        int choice = int.Parse(Console.ReadLine());
        switch(choice){
            case 1:
                notebook.Display();
                break;
            case 2:
                notebook.Display();
                Console.WriteLine("Which of these would you like to edit? ");
                int editChoice = int.Parse(Console.ReadLine());
                notebook.notes[choice - 1].Edit();
                break;
            case 3:
                notebook.CreateNote();
                break;
            case 4:
                Console.WriteLine("Are you sure? This will be permanent when the program is closed, and really annoying to reverse before then. (y/n)");
                if(Console.ReadLine() == "y"){
                    Console.WriteLine("Deleting " + notebook.name + " forever and ever...");
                    notes.notebooks.Remove(notebook);
                    Console.WriteLine("It's one forever, hope you didn't forget anything important in there. \n\n");
                }
                else{
                    Console.WriteLine(notebook.name + " lives to see another day. \n");
                }
                ChooseActivity();
                break;
            case 5:
                ChooseActivity();
                break;
            default:
                Console.WriteLine("Please choose a valid option. ");
                break;
        }
        ChooseAction(notebookChoice);
    }
}
}
