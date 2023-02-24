using System;

class Program
{
    static void Main(string[] args)
    {
        MathAssignment ma = new MathAssignment("Colton Pritchett", "Fractions", "7.3", "8-19");
        WritingAssignment wa = new WritingAssignment("Colton Pritchett", "European History", "The Causes of World War II");
        Console.WriteLine(ma.GetSummary() + "\n" + ma.GetHomeworkList() + "\n\n" + wa.GetSummary() + "\n" + wa.GetWritingInformation());
    }
}