using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dragon_STARTER
{
    /// <summary>
    /// Type of damage that any Monster can influct upon another Monster.
    /// Damages come from D&D 5e system.
    /// </summary>
    public enum Damage
    {
        Fire,
        Ice,
        Lightning,
        Piercing,
        Psychic
    }


    /// <summary>
    /// Parent class to Beholder and Dragon.
    /// </summary>
    internal abstract class Monster
    {
        // Monster class fields
        protected string name;
        protected int health;
        protected Damage attackDamage;
        protected Random generator;

        /// <summary>
        /// Returns the health (current hit points left) .
        /// </summary>
        public int Health
        {
            get { return health; }
        }

        /// <summary>
        /// Returns the name of this Monster.
        /// </summary>
        public string Name
        {
            get { return name; }
        }

        // ********************************************************************
        /// <summary>
        /// Returns this monster's attack damage.
        /// </summary>
        public Damage AttackDamage
        {
            get { return attackDamage; }
        }
        // ********************************************************************


        /// <summary>
        /// Initialize a Monster object
        /// As Monster is abstract, this constructor can never be called on its own.
        /// </summary>
        /// <param name="name">Name of the Monster</param>
        /// <param name="health">Current hit points left.</param>
        /// <param name="attackDamage">Number of hit points inflicted upon an enemy.</param>
        public Monster(string name, int health, Damage attackDamage)
        {
            this.name = name;
            this.health = health;
            this.attackDamage = attackDamage;
            generator = new Random();
        }


        /// <summary>
        /// Child classes must implement this method to inflict damage upon an enemy.
        /// </summary>
        /// <param name="target">Reference to the enemy.</param>
        public abstract void Attack(Monster target);


        /// <summary>
        /// Child classes must implement this method to apply attack damage to their hit point total.
        /// </summary>
        /// <param name="hitPoints">Number of hit points of damage dealt.</param>
        /// <param name="incoming">Type of damage dealt.</param>
        public abstract void TakeDamage(int hitPoints, Damage incoming);


        /// <summary>
        /// Returns a string representation of this class.
        /// </summary>
        /// <returns>String detailing the name and current health of a Monster, 
        /// including the type of attack damage this Monster inflicts.</returns>
        public override string ToString()
        {
            string monsterInformation = 
                String.Format("{0} has {1} health ",
                name,
                health);

            // Include custom message about type of damage this Monster deals to others.
            switch (attackDamage)
            {
                case Damage.Fire:
                    monsterInformation += "and breathes fire.";
                    break;
                case Damage.Ice:
                    monsterInformation += "and freezes enemies.";
                    break;
                case Damage.Lightning:
                    monsterInformation += "and shocks his opponent.";
                    break;
                case Damage.Piercing:
                    monsterInformation += "and punctures his adversary.";
                    break;
                case Damage.Psychic:
                    monsterInformation += "whose psychic damage agonizes his combatant.";
                    break;
            }

            return monsterInformation;
        }
    }
}
