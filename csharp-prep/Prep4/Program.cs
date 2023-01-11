using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        List<int> numbers = new List<int>();
        int input;

        //create list
        do{
            Console.WriteLine("Enter number: ");
            input = int.Parse(Console.ReadLine());
            numbers.Add(input);
        } while(input != 0);
        numbers.Remove(0);

        //find and print sum/average
        int sum = 0;
        int count = 0;
        int largest = numbers[0];
        int smallest = numbers[0];
        foreach(int i in numbers){
            sum += i;
            count ++;
            largest = Math.Max(largest, i);
            if(i > 0) smallest = Math.Min(smallest, i);
        }
        Console.WriteLine($"The sum is {sum}");
        Console.WriteLine($"The average is {(double)sum/(double)count}");
        Console.WriteLine($"The largest number is {largest}");
        if(smallest > 0) Console.WriteLine($"The smallest positive number is {smallest}");
        else Console.WriteLine("There is no positive number");

        Console.WriteLine("The sorted list is:");
        numbers.Sort();
        foreach(int i in numbers) Console.WriteLine(i);
    }
}