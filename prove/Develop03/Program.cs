using System;
using System.Text.Json;

namespace DeserializeExtra{
class Program
{
    static Library[] bom = new Library[5];
    static Dictionary<string, int>[] bookNames = new Dictionary<string, int>[5];

    static void Main(string[] args)
    {
        //Read json
        bom[0] = JsonSerializer.Deserialize<Library>(new StreamReader("old-testament.json").ReadToEnd());
        bom[1] = JsonSerializer.Deserialize<Library>(new StreamReader("new-testament.json").ReadToEnd());
        bom[2] = JsonSerializer.Deserialize<Library>(new StreamReader("book-of-mormon.json").ReadToEnd());
        bom[3] = JsonSerializer.Deserialize<Library>(new StreamReader("doctrine-and-covenants.json").ReadToEnd());
        bom[4] = JsonSerializer.Deserialize<Library>(new StreamReader("pearl-of-great-price.json").ReadToEnd());

        //Catalog book names
        for(int i = 0; i < 5; i++){
            bookNames[i] = new Dictionary<string, int>();
            for(int j = 0; j < bom?[i].books?.Count; j++){
                bookNames[i].Add(bom[i].books[j].book, j);
            }
        }

        GameLoop();
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

    public static string Mask(string verse, int difficulty){
        string[] split = verse.Split(" ");
        bool[] mask = new bool[split.Length];
        for(int i = 1; i < split.Length; i++){
            if(i <= (split.Length * difficulty) / 10) mask[i] = true;
            else mask[i] = false;
        }
        Random randomizer = new Random();
        for(int i = 1; i < split.Length; i++){
            int rand = randomizer.Next(0, split.Length);
            bool temp = mask[i];
            mask[i] = mask[rand];
            mask[rand] = temp;
        }
        verse = "";
        for(int i = 1; i < split.Length; i++){
            if(mask[i]){
                for(int j = 0; j < split[i].Length; j++){
                    verse += "_";
                }
            }
            else{
                verse += split[i];
            }
            verse += " ";
        }
        return verse;
    }

    public static bool Grade(string str, string guess){
        string[] splitStr = str.Split(new[] {' ', ',', '.', ';', ':', '-'}, System.StringSplitOptions.RemoveEmptyEntries);
        string[] splitGuess = guess.Split(new[] {' ', ',', '.', ';', ':', '-'}, System.StringSplitOptions.RemoveEmptyEntries);
        for(int i = 0; i < splitStr.Length - 2; i++){
            if(splitGuess[i].ToLower() != splitStr[i + 1].ToLower()) return false;
        }
        return true;
    }

    public static void GameLoop(){
        Console.Clear();
        Console.WriteLine("reference of verse(s): ");
        string str = InterpretInput(Console.ReadLine());
        Console.WriteLine("difficulty (0-10): ");
        int difficulty = int.Parse(Console.ReadLine());
        Console.WriteLine(Mask(str, difficulty));
        string guess = Console.ReadLine();
        Guess(str, guess);
    }

    public static void Guess(string str, string guess){
        if(Grade(str, guess)){
            Console.WriteLine("Correct! Do you want to try another verse? (y/n) ");
            if(Console.ReadLine() == "y") GameLoop();
        }
        else{
            Console.WriteLine("Try again, or type \"next\" to try another verse. ");
            guess = Console.ReadLine();
            if(guess == "next") GameLoop();
            else Guess(str, guess);
        }
    }
}



public class Library{
    public IList<Book>? books{get; set;}
}

public class Book{
    public string? book{get; set;}
    public IList<Chapter>? chapters{get; set;}
}

public class Chapter{
    public int? chapter{get; set;}
    public string? reference{get; set;}
    public IList<Verse>? verses{get; set;}
}

public class Verse{
    public string? reference{get; set;}
    public string? text{get; set;}
    public int? verse{get; set;}
}
}


/*
string[] split = str.Split(' ');
str = "";
for(int i = 1; i < split.Length; i++){
    str += split[i] + " ";
}
Console.WriteLine(guess + "\n" + str);
return string.Equals(guess.ToLower(), str.ToLower());
*/