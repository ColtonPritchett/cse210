using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using DeserializeExtra;

public class Biblioteca{
    public IList<Notebook>? notebooks{get; set;}

    public void CreateNotebook(){
        notebooks.Add(new Notebook());
        Console.WriteLine("What would you like to name this notebook? ");
        notebooks[notebooks.Count - 1].name = Console.ReadLine();
        notebooks[notebooks.Count - 1].CreateNote();
    }
}

public class Notebook{
    public List<Note>? notes{get; set;}
    public string? name{get; set;}

    public void Display(){
        int i = 1;
        foreach(Note note in notes){
            Console.WriteLine(i++ + ". ");
            note.Display();
        }
    }

    public void CreateNote(){
        if(notes == null) notes = new List<Note>();
        Console.WriteLine("What kind of note do you wish to create? ");
        Console.WriteLine("1. Note");
        Console.WriteLine("2. Scripture Note");
        int choice = int.Parse(Console.ReadLine());
        Note note;
        switch(choice){
            case 1:
                notes.Add(new Note());
                break;
            case 2:
                notes.Add(new VerseNote());
                break;
            default:
                Console.WriteLine("Please choose a valid option. ");
                CreateNote();
                break;
        }
        notes[notes.Count - 1].Write();
    }
}

[JsonDerivedType(derivedType: typeof(Note), typeDiscriminator: "base")]
[JsonDerivedType(derivedType: typeof(VerseNote), typeDiscriminator: "verse")]
public class Note{
    public string? topic{get; set;}
    public string? note{get; set;}
    public List<string> attributes = new List<string>();
    public List<string> attributeNames = new List<string>();

    public Note(){
        attributes.Add(topic);
        attributeNames.Add("Topic");
        attributes.Add(note);
        attributeNames.Add("Note");
    }

    public void Display(){
        Console.WriteLine("Topic: " + topic + "\nNote: " + note + "\n");
    }

    public virtual void Write(){
        Console.WriteLine("About what topic will you write? ");
        topic = Console.ReadLine();
        Console.WriteLine("You may begin typing. You may add paragraphs by hitting enter, or exit by entering a \'0\'.");
        string input = Console.ReadLine();
        while(input != "0"){
            note += input + "\n";
            input = Console.ReadLine();
        }
    }

    public void Edit(){
        Console.WriteLine("Which part of this note do you wish to edit? ");
        int i = 1;
        foreach(string attributeName in attributeNames){
            Console.WriteLine(i++ + ". " + attributeName);
        }

        int choice = int.Parse(Console.ReadLine());
        Console.WriteLine("This is the current " + attributeNames[choice - 1] + ": \n" + attributes[choice - 1]);
        Console.WriteLine("Please enter what you wish to replace this with: ");
        attributes[choice - 1] = Console.ReadLine();
        CleanUp();

        Console.WriteLine("Do you wish to continue editing this note? (y/n)");
        if(Console.ReadLine() == "y") Edit();
    }

    public virtual void CleanUp(){
        topic = attributes[0];
        note = attributes[1];
    }
}

public class VerseNote : Note{
    public string? reference{get; set;}

    public VerseNote() : base(){
        attributes.Add(reference);
        attributeNames.Add("Reference");
    }

    public override void CleanUp(){
        base.CleanUp();
        reference = attributes[2];
    }

    public override void Write(){
        Console.WriteLine("About which verses will you write? ");
        reference = Console.ReadLine();
        Console.WriteLine(Program.InterpretInput(reference));
        base.Write();
    }
}
