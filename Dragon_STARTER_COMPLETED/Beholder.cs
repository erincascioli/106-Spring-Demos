using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dragon_STARTER
{

    /// <summary>
    /// Child of Monster
    /// Beholders have a vulnerability to certain Damage types.
    /// Vulnerabilities increase the incoming attack values.
    /// </summary>

    internal class Beholder : Monster
    {
        /// <summary>
        /// What is this Beholder vulnerable to?
        /// </summary>
        private Damage vulnerability;


        /// <summary>
        /// Instantiate a new Beholder object.
        /// </summary>
        /// <param name="name">Name of this Beholder</param>
        /// <param name="health">Starting health value</param>
        /// <param name="type">Type of damage this Beholder inflicts</param>
        /// <param name="vulnerability">Type of damage this Beholder is vulnerable to</param>
        public Beholder(string name, int health, Damage type, Damage vulnerability) :
            base(name, health, type)
        {
            this.vulnerability = vulnerability;
        }


        /// <summary>
        /// Attacks another Monster object for 10 - 20 hit points.
        /// </summary>
        /// <param name="target">Target of the attack</param>
        public override void Attack(Monster target)
        {
            // Beholders can attack for 5 - 25 damage
            int randomAttackValue = generator.Next(5, 26);

            // Print attack information to console
            string attackData =
            String.Format("{0} attacks for {1} damage.",
                name,                                               // This Beholder's name
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

            // Does this Beholder have a vulnerability to the attack?
            // Take twice the amount of hit points.
            if (incomingDamage == vulnerability)
            {
                attackMessage =
                    String.Format("{0} takes {1} damage, doubled to {2} due to a {3} vulnerability.",
                    name,                                           // 0 - This Beholder's name
                    hitPoints,                                      // 1 - Original HP
                    hitPoints *= 2,                                 // 2 - Twice the HP
                    vulnerability.ToString().ToLower());            // 3 - Vulnerability, lowercase
            }
            // Otherwise take full attack damage
            else
            {
                attackMessage =
                String.Format("{0} takes {1} damage.",
                name,                                               // 0 - This Beholder's name
                hitPoints,                                          // 1 - Original HP
                vulnerability.ToString().ToLower());                // 2 - Vulnerability, lowercase
            }

            // Hurt the Beholder! Cap health at 0.
            health -= hitPoints;
            if (health < 0)
            {
                health = 0;
            }

            // Confirm attack message for user.
            Console.WriteLine(attackMessage);
        }


        /// <summary>
        /// Returns a string representation of this Beholder class. 
        /// </summary>
        /// <returns>String discussing the name, health, damage, and vulnerability.</returns>
        public override string ToString()
        {
            // Format this Beholder's vulnerability information for console output
            string vulnerableInformation =
                String.Format(" {0} is vulnerable to {1} damage.",
                name,                                               // 0 - This Beholder's name
                vulnerability.ToString().ToLower());                // 1 - Vulnerability, lowercase

            return base.ToString() + vulnerableInformation;
        }
    }
}
