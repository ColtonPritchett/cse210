using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        shapes.Add(new Square("white", 5.1));
        shapes.Add(new Rectangle("orange", 42, 8.626));
        shapes.Add(new Circle("greenish", 3.14159265));
        foreach(Shape shape in shapes){
            Console.WriteLine(shape.GetColor());
            Console.WriteLine(shape.GetArea() + "\n");
        }
    }
}