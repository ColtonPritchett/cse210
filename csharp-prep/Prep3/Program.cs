using System;

class Program
{
    static void Main(string[] args)
    {
        bool play = true;
        Console.WriteLine("Welcome to Guess That Number!");

        //each round
        do{
            int magicNumber = new Random().Next(1, 100);
            int guesses = 0;
            bool correct = false;

            //each guess
            do{
                Console.WriteLine("What is your guess? ");
                int guess = int.Parse(Console.ReadLine());
                if(guess == magicNumber) correct = true;
                else if(guess > magicNumber) Console.WriteLine("Lower");
                else Console.WriteLine("Higher");
                guesses++;
            } while(!correct);
            
            //post round
            if(guesses == 1) Console.WriteLine($"Congratulations! You guessed the number in 1 guess!");
            else Console.WriteLine($"Congratulations! You guessed the number in {guesses} guesses!");
            Console.WriteLine("Do you wish to continue (y/n)? ");
            string seguir = Console.ReadLine();
            if(seguir == "n") play = false;
        } while(play);
    }
}