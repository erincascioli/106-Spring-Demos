using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo
{
    /// <summary>
    /// Describes the type of weapon that a Player holds
    /// </summary>
    public enum Weapon
    {
        Longsword,
        Shortsword,
        Axe,
        Dagger,
        Crossbow,
        Stick,
        Fist,
        ScorpionOnAStick
    }

    /// <summary>
    /// User-driven character
    /// </summary>
    internal class Player : IDamageable
    {
        private const int MaxHealth = 25;
        private int health;
        private string name;
        private Weapon weapon;


        /// <summary>
        /// Name of this Player. Needed in Main.
        /// </summary>
        public string Name
        {
            get { return name; }
        }


        // *********************************
        // *** Required by the interface ***
        // *********************************
        /// <summary>
        /// How much damage has this player received thus far?
        /// </summary>
        public int CurrentDamage
        {
            get
            {
                // You're not required to make a matching backing field
                //   and return it - sometimes it makes more sense
                //   to use the fields you already have.
                return MaxHealth - health;
            }
        }

        // *********************************
        // *** Required by the interface ***
        // *********************************
        /// <summary>
        /// Determines if player has succumbed yet
        /// </summary>
        /// <returns>True if player is dead, false otherwise</returns>
        public bool IsExpired
        {
            get
            {
                return health <= 0;
            }
        }


        /// <summary>
        /// Creates a player with the specified name and no damage
        /// </summary>
        /// <param name="name">The name of the player</param>
        /// <param name="weapon">Type of weapon player utilizes</param>
        public Player(string name, Weapon weapon)
        {
            this.name = name;
            this.weapon = weapon;
            this.health = MaxHealth;
        }


        /// <summary>
        /// Summary of this player's stats
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Player {name} is using the {weapon} and has {health} hit points left.";
        }

        // *********************************
        // *** Required by the interface ***
        // *********************************
        /// <summary>
        /// Reduces a player's health when hit
        /// </summary>
        /// <param name="amountOfDamage">Number of hit points</param>
        public void TakeDamage(int amountOfDamage)
        {
            // Negative damage should not heal the player
            // Only receive positive damage instead
            if (amountOfDamage > 0)
            {
                health -= amountOfDamage;
            }
        }
    }
}
