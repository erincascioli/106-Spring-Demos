 
// Author:   Erin Cascioli
// Semester: Spring 2023

// STARTER CODE: Use this code for the File IO and Managers PE.
// Place this in your PE's folder in your local GitHub repository.


namespace Dragon_STARTER
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ----------------------------------------------------------------
            // Variables for the program
            Dragon guy1;                // Fighter #1
            Beholder guy2;              // Fighter #2
            int roundCounter = 1;       // Number of rounds
            MonsterManager manager = new MonsterManager();

            // ----------------------------------------------------------------
            // Battle!

            // Instantiate both fighters
            guy1 = manager.GetDragon();
            guy2 = manager.GetBeholderByType(Damage.Psychic);

            // Print their beginning statistics
            Console.WriteLine("MEET THE CHAMPIONS:");
            Console.WriteLine(guy1);
            Console.WriteLine(guy2);

            // While both Monsters are alive, fight!
            while (guy1.Health > 0 && guy2.Health > 0)
            {
                // Visual divider for spacing and output
                Console.WriteLine("\n----------------------------------------");

                // Give reader context with the round number
                Console.WriteLine($"Round {roundCounter}... Fight!");
                roundCounter++;

                // Attack the other Monster, then print each one's health values.
                guy1.Attack(guy2);
                guy2.Attack(guy1);
                Console.WriteLine($"\n{guy1.Name} is at {guy1.Health} health.");
                Console.WriteLine($"{guy2.Name} is at {guy2.Health} health.");
            }

            // ----------------------------------------------------------------
            // Determine winner!

            // Visual divider for spacing and output
            Console.WriteLine("\n------------ WINNER ------------");

            // Tie
            if (guy1.Health <= 0 && guy2.Health <= 0)
            {
                Console.WriteLine("Both fighters have succumbed to the battle.");
            }
            // Dragon wins
            else if (guy1.Health > 0)
            {
                Console.WriteLine($"{guy1.Name} is victorius!");
            }
            // Beholder wins
            else
            {
                Console.WriteLine($"{guy2.Name} is victorius!");
            }
        }
    }
}