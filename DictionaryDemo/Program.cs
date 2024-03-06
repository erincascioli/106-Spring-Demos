using System.Collections.Generic;

namespace DictionaryDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // "mapping a string to a string"
            //Dictionary<string, string> faveFoods = new Dictionary<string, string>();
            Dictionary<string, string> faveFoods = new();

            faveFoods.Add("Will H", "Texas Barbecue");
            faveFoods.Add("Benjamin", "Bacon mac + cheese");
            faveFoods.Add("Dalton", "Uni");
            faveFoods["Erin"] = "cake";
            faveFoods.Add("Will D", "Anything Will's aunt cooks");

            if(faveFoods.ContainsKey("Will"))
            {
                Console.WriteLine(faveFoods["Will"]);
                faveFoods["Will"] = "something else";
            }

            // Avoid KNF exception
            if(faveFoods.ContainsKey("Eric"))
            {
                Console.WriteLine(faveFoods["Eric"]);
            }

            // Does anyone like cake?
            if(faveFoods.ContainsValue("cake"))
            {
                Console.WriteLine("Woooo cake!");
            }

            // Find all the keys in my dictionary
            foreach (KeyValuePair<string, string> kvp in faveFoods)
            {
                Console.WriteLine($"Key is {kvp.Key} and value is {kvp.Value}");
            }


            Dictionary<double, int> numberFloor = new();
            numberFloor.Add(2.3856253, 2);
            numberFloor.Add(5928.1324, 5928);

            numberFloor[2.3856253]++;
        }
    }
}