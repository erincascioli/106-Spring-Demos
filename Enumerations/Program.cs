
// Erin Cascioli
// 1/22/24
// Demo: Enumerations


namespace Enumerations
{
    internal class Program
    {
        // ------------------------------------------------------------------------
        // Enumerations
        // ------------------------------------------------------------------------
        // ** Enums are typically defined outside of a class, inside the namespace.
        // ** Typically public so all classes can use them.
        // ** Act like a set of constant integer variables, with readable values
        //    in words but integral values (for speed of comparison).
        // ** Members are separated by commas and start with capital letters.
        // ------------------------------------------------------------------------
        
        // ERIN defined this!
        public enum Donuts
        {
            Glazed,
            Powdered,
            Chocolate,
            CustardFilled,
            Jelly,
            PinkSprinkles,
            HalloweenSpider,
            Cake,
            Headlight,
            Mario,
            MapleBacon,
            Wario,
            Good,
            Evil
        }


        static void Main(string[] args)
        {
            // ------------------------------------------------------------------------
            // Enumerations and Variables
            // ------------------------------------------------------------------------
            // ** Once declared, any enum is now a valid data type.
            // ** Variables of those declared enums can be declared and initialized.

            // These 2 variables contain members of the Donuts enumeration.
            Donuts bestDonut = Donuts.PinkSprinkles;
            Donuts dangerous = Donuts.Evil;

            // WILL defines a new donut variable
            Donuts willDonut = Donuts.Good;

            // ** Members that are NOT included in the enumeration cannot be used.
            // This won't work because Coconut is not a member of Donuts.
            //Donuts doesntExist = Donuts.Coconut;


            // ------------------------------------------------------------------------
            // Integer values and enums
            // ------------------------------------------------------------------------
            // ** Variables of enum types can be cast to and from integers.
            // ** This is helpful if there is a relationship between the enum members's 
            //    value and the integer value.
            // ** Or when generating a random enum member.

            // Get a random valid enum member
            Random generator = new Random();
            Donuts myRandomDonut = (Donuts)generator.Next(0, 14);

            // However - BE CAREFUL when casting from int to an enum. Any integer value can be used!
            // What are numbers 14 throughy 99?  They are not one of the Donuts members!
            Donuts myUnknownDonut = (Donuts)generator.Next(14, 100);


            // ------------------------------------------------------------------------
            // Enum comparisons
            // ------------------------------------------------------------------------
            // ** Enums can be compared against the discrete set of members
            // ** This comparison is FAST! Has the speed of integer comparison.

            // See the PrintDonutMessage method below for enum comparisons
            PrintDonutMessage(myRandomDonut);
            PrintDonutMessage(myUnknownDonut);


            // ------------------------------------------------------------------------
            // String values and enums
            // ------------------------------------------------------------------------
            // ** Strings can be retrieved from any enum member with ToString.
            // ** Once a string has been retrieved, you can do anything you need with it,
            //    including using other string methods on it.

            string myRandomDonutString = myRandomDonut.ToString();
            Console.WriteLine("My random donut was a {0} donut.", myRandomDonutString.ToUpper());
        }


        /// <summary>
        /// Prints information about the randomly chosen donut that the user received.
        /// </summary>
        /// <param name="chosenDonut">Which donut did the user get?</param>
        public static void PrintDonutMessage(Donuts chosenDonut)
        {
            Console.WriteLine("------------------------------------------------");

            // If the donut is evil, print a special message and end the program.
            if (chosenDonut == Donuts.Evil)
            {
                Console.WriteLine("Oh no! Your donut was poisoned...");
                Console.WriteLine("Fear fills your eyes as you watch your human legs turn into frog legs...");
                Console.WriteLine("The world becomes much larger and you become much smaller...");
                Console.WriteLine("You try to speak but all that comes out is a faint \"ribbit\"");

                // Change console colors
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.DarkGreen;
            }
            // Otherwise, the game continues!
            else
            {
                switch (chosenDonut)
                {
                    case Donuts.Glazed:
                    case Donuts.Chocolate:
                        Console.WriteLine("Aah, the {0} donut...", chosenDonut.ToString().ToLower());
                        Console.WriteLine("You smile as the sweet, sticky glaze hits your lips.");
                        break;
                    case Donuts.CustardFilled:
                    case Donuts.Jelly:
                        Console.WriteLine("Good thing you love {0} donuts!", chosenDonut.ToString().ToLower());
                        Console.WriteLine("A bit of sweet filling hits your tongue. " +
                            "You think to yourself, 'Filled donuts are the best!'");
                        break;
                    case Donuts.PinkSprinkles:
                        // NOTE: This prints as "pinksprinkles"
                        // More work is needed to use the enum as a readable string!
                        Console.WriteLine("Everyone loves {0} donuts!", chosenDonut.ToString().ToLower());
                        Console.WriteLine("Crunchy sprinkles with swirly frosting is the only way to go.");
                        break;
                    case Donuts.Powdered:
                        Console.WriteLine("The {0} donut. Classic.", chosenDonut.ToString().ToLower());
                        break;
                    default:
                        Console.WriteLine("What is a {0} donut??", chosenDonut.ToString().ToLower());
                        Console.WriteLine("... Do you dare to try the unknown donut? ...");
                        break;
                }
            }

            Console.WriteLine("------------------------------------------------");
        }
    }
}