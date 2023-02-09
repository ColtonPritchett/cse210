using System;
using System.Text.Json;

namespace DeserializeExtra{
class Program
{
    static void Main(string[] args)
    {
        List<Library> bom = new List<Library>();
        bom.Add(JsonSerializer.Deserialize<Library>(new StreamReader("old-testament.json").ReadToEnd()));
        bom.Add(JsonSerializer.Deserialize<Library>(new StreamReader("new-testament.json").ReadToEnd()));
        bom.Add(JsonSerializer.Deserialize<Library>(new StreamReader("book-of-mormon.json").ReadToEnd()));
        bom.Add(JsonSerializer.Deserialize<Library>(new StreamReader("doctrine-and-covenants.json").ReadToEnd()));
        bom.Add(JsonSerializer.Deserialize<Library>(new StreamReader("pearl-of-great-price.json").ReadToEnd()));

        
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