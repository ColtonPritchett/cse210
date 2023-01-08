using System;

class Program
{
    static void Main(string[] args)
    {
        bool seguir = true;
        while(seguir){
            Console.WriteLine("What was your grade? ");
            int grade = int.Parse(Console.ReadLine());
            string letter;
            if(grade >= 90){
                letter = "A";
            } else if(grade >= 80){
                letter = "B";
            } else if(grade >= 70){
                letter = "C";
            } else if(grade >= 60){
                letter = "D";
            } else {
                letter = "F";
            }
            if(grade % 10 >= 7 && grade <= 90){
                letter = letter + "+";
            } else if(grade % 10 <= 3){
                letter = letter + "-";
            }
            Console.WriteLine($"Letter grade: {letter}");
            Console.WriteLine("Do you wish to continue (y/n)? ");
            string answer = Console.ReadLine();
            if(answer == "n") seguir = false;
        }
    }
}