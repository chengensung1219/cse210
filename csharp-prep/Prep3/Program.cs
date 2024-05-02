using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int answer = random.Next(1, 101);
        int response = -1;

        while (response != answer){
            Console.Write("What is your guess? ");
            response = int.Parse(Console.ReadLine());

            if (response == answer)
            {
                Console.WriteLine("You guessed it!");
            }
            else if (response > answer)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("Higher");
        }
        }
        
    }
}