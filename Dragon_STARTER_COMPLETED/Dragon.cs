using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dragon_STARTER
{
    /// <summary>
    /// Child of Monster
    /// Dragons have a resistance to certain Damage types.
    /// Resistances halve the incoming attack values.
    /// </summary>
    internal class Dragon : Monster
    {
        /// <summary>
        /// What is this Dragon resistant to?
        /// </summary>
        private Damage resistance;


        /// <summary>
        /// Instantiate a new Dragon object.
        /// </summary>
        /// <param name="name">Name of this Dragon</param>
        /// <param name="health">Starting health value</param>
        /// <param name="type">Type of damage this Dragon inflicts</param>
        /// <param name="resistance">Type of damage this Dragon is resistant to</param>
        public Dragon(string name, int health, Damage type, Damage resistance) :
            base(name, health, type)
        {
            this.resistance = resistance;
        }


        /// <summary>
        /// Attacks another Monster object for 10 - 20 hit points.
        /// </summary>
        /// <param name="target">Target of the attack</param>
        public override void Attack(Monster target)
        {
            // Dragons can attack for 10 - 20 damage
            int randomAttackValue = generator.Next(10, 21);

            // Print attack information to console
            string attackData = 
                String.Format("{0} attacks for {1} damage.",
                name,                                               // This Dragon's name
                randomAttackValue);                                 // Attack value

            // Hurt the opponent
            target.TakeDamage(randomAttackValue, this.attackDamage);
        }


        /// <summary>
        /// Reduce this Monster's health by a specific amount.
        /// </summary>
        /// <param name="hitPoints">Attack damage value</param>
        /// <param name="incomingDamage">Opponent's Damage type</param>
        public override void TakeDamage(int hitPoints, Damage incomingDamage)
        {
            // Get string ready for message about attack
            string attackMessage = null;

            // Does this Dragon have a resistance to the attack?
            // Take half the hit points.
            if (incomingDamage == resistance)
            {
                attackMessage =
                    String.Format("{0} takes {1} damage, halved to {2} due to a {3} resistance.",
                    name,                                           // 0 - This Dragon's name
                    hitPoints,                                      // 1 - Original HP
                    hitPoints /= 2,                                 // 2 - Halve the HP
                    resistance.ToString().ToLower());               // 3 - Resistance, lowercase
            }
            // Otherwise take full attack damage
            else
            {
                attackMessage =
                    String.Format("{0} takes {1} damage.",
                    name,                                           // 0 - This Dragon's name
                    hitPoints,                                      // 1 - Original HP
                    resistance.ToString().ToLower());               // 2 - Resistance, lowercase
            }

            // Hurt the dragon! Ensure value never goes below 0.  
            health -= hitPoints;
            if (health < 0)
            {
                health = 0;
            }

            // Confirm attack message for user.
            Console.WriteLine(attackMessage);
        }


        /// <summary>
        /// Returns a string representation of this Dragon class. 
        /// </summary>
        /// <returns>String discussing the name, health, damage, and resistance.</returns>
        public override string ToString()
        {
            // Format this Dragon's resistance information for console output
            string resistanceInformation = 
                String.Format(" {0} is resistant to {1} damage.",    
                name,                                               // 0 - This Dragon's name
                resistance.ToString().ToLower());                   // 1 - Resistance, lowercase

            return base.ToString() + resistanceInformation;
        }
    }
}
