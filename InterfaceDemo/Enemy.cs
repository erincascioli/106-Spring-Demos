using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo
{
    /// <summary>
    /// Enemy that will auto-attack a player
    /// </summary>
    internal class Enemy
    {
        private int identificationNumber;
        private int health;
        private Weapon weapon;

        /// <summary>
        /// Creates an enemy with a health and chosen weapon
        /// </summary>
        /// <param name="health">Starting health value</param>
        /// <param name="weapon">Choice of weapon</param>
        public Enemy(int idNumber, int health, Weapon weapon)
        {
            this.identificationNumber = idNumber;
            this.health = health;
            this.weapon = weapon;
        }

        // Becauce Player and Door implement the same interface, 
        //   we no longer need separate methods for attacking
        //   Player objects and Door objects

        public int Attack(Player player)
        {
            switch (weapon)
            {
                case Weapon.Axe:
                    player.TakeDamage(35);
                    return 35;

                case Weapon.Crossbow:
                    player.TakeDamage(10);
                    return 10;

                case Weapon.ScorpionOnAStick:
                    player.TakeDamage(1);
                    return 1;
            }

            return -1;
        }

        public int Attack(Door door)
        {
            switch (weapon)
            {
                case Weapon.Axe:
                    door.TakeDamage(35);
                    return 35;

                case Weapon.Crossbow:
                    door.TakeDamage(10);
                    return 10;

                case Weapon.ScorpionOnAStick:
                    door.TakeDamage(1);
                    return 1;
            }

            return -1;
        }


        /// <summary>
        /// Causes harm to any object implementing the IDamageable interface
        /// </summary>
        /// <param name="obj">Object to damage</param>
        public int Attack(IDamageable obj)
        {
            switch (weapon)
            {
                case Weapon.Axe:
                    obj.TakeDamage(35);
                    return 35;

                case Weapon.Crossbow:
                    obj.TakeDamage(10);
                    return 10;

                case Weapon.ScorpionOnAStick:
                    obj.TakeDamage(1);
                    return 1;
            }

            return -1;
        }


        public override string ToString()
        {
            return $"Enemy {identificationNumber}.  HP: {health}.  Weapon: {weapon}";
        }

    }
}
