
// Erin Cascioli
// 2/14/2024
// Demo: Interfaces and their implementation

namespace InterfaceDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ----------------------------------------------------------------
            // Set up game
            // ----------------------------------------------------------------
            // Make two players
            Player p1 = new Player("Maverick", Weapon.Dagger);
            Player p2 = new Player("Nova", Weapon.Longsword);

            // Wooden door to a safe place
            Door lockedDoor = new Door(DoorMaterial.Wood);

            // Keep a list of all the things in the environment near Bad Guy 3 (Maverick and the door)
            List<IDamageable> currentArea = new List<IDamageable>();
            currentArea.Add(p1);
            currentArea.Add(lockedDoor);

            // Make some enemies
            Enemy badGuy1 = new Enemy(1, 50, Weapon.Crossbow);
            Enemy badGuy2 = new Enemy(2, 50, Weapon.ScorpionOnAStick);
            Enemy badGuy3 = new Enemy(3, 50, Weapon.Axe);
            // ----------------------------------------------------------------


            // ----------------------------------------------------------------
            // Print player data
            // ----------------------------------------------------------------
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("START OF GAME STATS: ");
            Console.WriteLine(" > " + p1);
            Console.WriteLine("   {0} has taken {1} damage", p1.Name, p1.CurrentDamage);
            Console.WriteLine(" > " + p2);
            Console.WriteLine("   {0} has taken {1} damage", p2.Name, p2.CurrentDamage);
            Console.WriteLine(" > Door: {0} damage/{1} HP",
                lockedDoor.CurrentDamage,
                lockedDoor.MaxHitPoints);
            Console.WriteLine("------------------------------------------");
            // ----------------------------------------------------------------


            // ----------------------------------------------------------------
            // Attacks!
            // ----------------------------------------------------------------
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("ATTACKS FROM ENEMIES: ");

            int attackValue = -1;

            // Guy #1 attacks the door.
            attackValue = badGuy1.Attack(lockedDoor); 
            Console.WriteLine(badGuy1 + $"\nAttacks Door for {attackValue}\n");

            // Guy #2 attacks second player
            attackValue = badGuy2.Attack(p2);
            Console.WriteLine(badGuy2 + $"\nAttacks {p2.Name} for {attackValue}\n");

            // Guy #3 rages and goes on a whirlwind attack, hitting everything in his current area.
            Console.WriteLine(badGuy3 + "\nRampages into a whirlwind attack!!!\n");
            foreach (IDamageable obj in currentArea)
            {
                attackValue = badGuy3.Attack(obj);

                if(obj is Player)
                {
                    Player player = (Player)obj;
                    Console.WriteLine(badGuy3 + $"\nAttacks {player.Name} for {attackValue}\n");
                }
                else
                {
                    Console.WriteLine(badGuy3 + $"\nAttacks door for {attackValue}\n");
                }
            }
            Console.WriteLine("------------------------------------------");
            // ----------------------------------------------------------------


            // ----------------------------------------------------------------
            // Check the damage that all have taken so far
            // ----------------------------------------------------------------
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("ATTACK RESULTS: \n");

            Console.WriteLine(" > " + p1);
            Console.WriteLine("   {0} has taken {1} damage", p1.Name, p1.CurrentDamage);
            Console.WriteLine("   Has the player died? " + p1.IsExpired);

            Console.WriteLine(" > " + p2);
            Console.WriteLine("   {0} has taken {1} damage", p2.Name, p2.CurrentDamage);
            Console.WriteLine("   Has the player died? " + p2.IsExpired);

            Console.WriteLine(" > Door: {0} damage/{1} HP",
                lockedDoor.CurrentDamage,
                lockedDoor.MaxHitPoints);
            Console.WriteLine("   Is the door broken yet? " + lockedDoor.IsExpired);
            Console.WriteLine("------------------------------------------");
            // ----------------------------------------------------------------


            // ----------------------------------------------------------------
            // Bad guy 3 REALLY wants to break the door...
            // ----------------------------------------------------------------
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("DOOR SMASH: ");

            // Smash the door again!
            attackValue = badGuy3.Attack(lockedDoor);
            Console.WriteLine(badGuy3 + $"\nAttacks door for {attackValue}\n");

            // Results of the attack
            Console.WriteLine(" > Door: {0} damage/{1} HP",
                lockedDoor.CurrentDamage,
                lockedDoor.MaxHitPoints);
            Console.WriteLine("   Is the door broken yet? " + lockedDoor.IsExpired);
            Console.WriteLine("------------------------------------------");

            // ----------------------------------------------------------------
        }
    }
}