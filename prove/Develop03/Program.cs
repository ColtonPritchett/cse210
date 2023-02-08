using System;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        Book bom;
        using (StreamReader r = new StreamReader("book-of-mormon-flat.json")) {  
            string json = r.ReadToEnd();  
            bom = JsonSerializer.Deserialize<Book>(json);  
        }
    }
}

class Verses{
    public string reference{get; set;}
    public string text{get; set;}

    public Verses(){

    }
    public Verses(string Reference, string Text){
        reference = Reference;
        text = Text;
    }
}

class Book{
    List<Verses> verses{get; set;}
}