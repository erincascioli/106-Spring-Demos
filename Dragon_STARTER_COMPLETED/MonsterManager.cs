using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Dragon_STARTER
{
    internal class MonsterManager
    {
        private List<Monster> monsterList;
        private Random generator;

        /// <summary>
        /// Returns the total number of Dragons in the game.
        /// </summary>
        public int NumberDragons
        {
            get
            {
                return FindAllDragons().Count;
            }
        }

        /// <summary>
        /// Returns the total number of Beholders in the game.
        /// </summary>
        public int NumberBeholders
        {
            get
            {
                return FindAllBeholders().Count;
            }
        }

        /// <summary>
        /// Instantiates a new Manager. 
        /// Reads all necessary data and instantiates Dragon and Beholder objects, 
        /// then stores them in a list.
        /// </summary>
        public MonsterManager()
        {
            // Init fields
            generator = new Random();
            monsterList = new List<Monster>();

            // Read all data. Instantiate Dragons and Beholders.
            ReadDragonData();
            ReadBeholderData();
        }


        // --------------------------------------------------------------------
        // ---------- REQUIRED METHODS ----------------------------------------
        // --------------------------------------------------------------------

        /// <summary>
        /// Reads Beholder data from a text file and instantiates Beholders using the data.
        /// </summary>
        public void ReadDragonData()
        {
            StreamReader reader = null;
            string lineOfText = null;

            try
            {
                reader = new StreamReader("../../../dragonData.txt");

                while((lineOfText = reader.ReadLine()) != null)
                {
                    // Split line of text upon pipe
                    string[] splitData = lineOfText.Split('|');

                    // Find the enum value associated with this dragon
                    string dragonName = splitData[0];
                    Damage dragonDamageType = ConvertStringToDamage(splitData[1]);

                    // OR
                    //Damage dragonDamageType = (Damage)Enum.Parse(typeof(Damage), splitData[1]);

                    // Instantiate a Dragon with this data
                    Dragon newDragon = new Dragon(dragonName, 100, dragonDamageType, Damage.Fire);
                    monsterList.Add(newDragon);
                }
            }
            catch(Exception error)
            {
                Console.WriteLine("Error in file reading of Dragons: " + error.Message);
            }
            finally
            {
                if(reader != null)
                {
                    reader.Close();
                }
            }
        }


        /// <summary>
        /// Reads Beholder data from a text file and instantiates Beholders using the data.
        /// </summary>
        public void ReadBeholderData()
        {
            StreamReader reader = null;
            string lineOfText = null;

            try
            {
                reader = new StreamReader("../../../beholderData.txt");

                while ((lineOfText = reader.ReadLine()) != null)
                {
                    // Split line of text upon pipe
                    string[] splitData = lineOfText.Split('|');

                    // Find the enum value associated with this beholder
                    string beholderName = splitData[0];
                    Damage beholderDamageType = ConvertStringToDamage(splitData[1]);

                    // OR
                    //Damage beholderDamageType = (Damage)Enum.Parse(typeof(Damage), splitData[1]);

                    // Instantiate a Beholder with this data
                    Beholder newBeholder = new Beholder(beholderName, 100, beholderDamageType, Damage.Ice);
                    monsterList.Add(newBeholder);
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Error in file reading of Beholders: " + error.Message);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        /// <summary>
        /// Retrieves a randomly chosen Dragon from the list of Monsters
        /// </summary>
        /// <returns>Dragon object</returns>
        public Dragon GetDragon()
        {
            // Temporary list to contain all Dragons
            List<Dragon> dragonsOnly = FindAllDragons();

            // Get a random Dragon from that list and return the reference
            int randomValue = generator.Next(0, dragonsOnly.Count);
            return dragonsOnly[randomValue];
        }


        /// <summary>
        /// Retrieves a randomly chosen Dragon from the list of Monsters with a particular damage subtype.
        /// </summary>
        /// <param name="chosenDamageType">Specified Damage type</param>
        /// <returns>Dragon object</returns>
        public Dragon GetDragonByType(Damage chosenDamageType)
        {
            // Temporary list to contain all Dragons
            List<Dragon> dragonsOnly = FindAllDragons();

            // Get a random index value
            int randomValue = generator.Next(0, dragonsOnly.Count);

            // Is that Dragon of this chosen type?  If not, try again.
            while (dragonsOnly[randomValue].AttackDamage != chosenDamageType)
            {
                randomValue = generator.Next(0, dragonsOnly.Count);
            }

            return dragonsOnly[randomValue];
        }


        /// <summary>
        /// Retrieves a randomly chosen Beholder from the list of Monsters
        /// </summary>
        /// <returns>Beholder object</returns>
        public Beholder GetBeholder()
        {
            // Temporary list to contain all Dragons
            List<Beholder> beholdersOnly = FindAllBeholders();

            // Get a random Dragon from that list and return the reference
            int randomValue = generator.Next(0, beholdersOnly.Count);
            return beholdersOnly[randomValue];
        }


        /// <summary>
        /// Retrieves a randomly chosen Beholder from the list of Monsters with a particular damage subtype.
        /// </summary>
        /// <param name="chosenDamageType">Specified Damage type</param>
        /// <returns>Beholder object</returns>
        public Beholder GetBeholderByType(Damage chosenDamageType)
        {
            // Temporary list to contain all Beholders
            List<Beholder> beholdersOnly = FindAllBeholders();

            // Get a random index value
            int randomValue = generator.Next(0, beholdersOnly.Count);

            // Is that Beholder of this chosen type?  If not, try again.
            while (beholdersOnly[randomValue].AttackDamage != chosenDamageType)
            {
                randomValue = generator.Next(0, beholdersOnly.Count);
            }

            return beholdersOnly[randomValue];
        }

        // --------------------------------------------------------------------
        // ---------- HELPER METHODS ------------------------------------------
        // --------------------------------------------------------------------

        public Damage ConvertStringToDamage(string damageTypeAsString)
        {
            switch(damageTypeAsString)
            {
                case "Lightning":
                    return Damage.Lightning;
                case "Ice":
                    return Damage.Ice;
                case "Piercing":
                    return Damage.Piercing;
                case "Fire":
                    return Damage.Fire;
                case "Psychic":
                    return Damage.Psychic;
                default:
                    return Damage.Lightning;
            }
        }

        public List<Dragon> FindAllDragons()
        {
            // Temporary list to contain all Dragons
            List<Dragon> dragonsOnly = new List<Dragon>();
            for (int i = 0; i < monsterList.Count; i++)
            {
                if (monsterList[i] is Dragon)
                {
                    dragonsOnly.Add((Dragon)monsterList[i]);
                }
            }

            return dragonsOnly;
        }

        public List<Beholder> FindAllBeholders()
        {
            // Temporary list to contain all Beholders
            List<Beholder> beholdersOnly = new List<Beholder>();
            for (int i = 0; i < monsterList.Count; i++)
            {
                if (monsterList[i] is Beholder)
                {
                    beholdersOnly.Add((Beholder)monsterList[i]);
                }
            }

            return beholdersOnly;
        }
    }
}
