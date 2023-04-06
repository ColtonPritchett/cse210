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