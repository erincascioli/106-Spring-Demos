using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo
{
    /// <summary>
    /// Type of material a door is comprised of
    /// </summary>
    public enum DoorMaterial
    {
        Wood,
        Iron,
        Stone
    }

    /// <summary>
    /// Represents a barrier to a room or area in a game
    /// </summary>
    internal class Door : IDamageable
    {
        private DoorMaterial doorMaterial;
        private int damageThreshold;
        private int maxHitPoints;

        // *** Added this field after implementing the interface ***
        private int currentDamage;

        // *********************************
        // *** Required by the interface ***
        // *********************************
        /// <summary>
        /// What is the accumulative damage thus far?
        /// </summary>
        public int CurrentDamage
        {
            get
            {
                return currentDamage;
            }
        }

        // *********************************
        // *** Required by the interface ***
        // *********************************
        /// <summary>
        /// Determines if door is broken
        /// </summary>
        /// <returns>True if door is broken, false otherwise</returns>
        public bool IsExpired
        {
            get
            {
                return currentDamage >= maxHitPoints;
            }
        }


        /// <summary>
        /// What is the door's total armor?
        /// </summary>
        public int MaxHitPoints
        {
            get { return maxHitPoints; }
        }


        /// <summary>
        /// Barrier to a locked place 
        /// </summary>
        /// <param name="material">Type of building material door is made of</param>
        public Door(DoorMaterial material)
        {
            this.doorMaterial = material;

            // Set field values based on the door material
            switch (this.doorMaterial)
            {
                case DoorMaterial.Wood:
                    damageThreshold = 15;
                    maxHitPoints = 50;
                    break;
                case DoorMaterial.Iron:
                    damageThreshold = 25;
                    maxHitPoints = 150;
                    break;
                case DoorMaterial.Stone:
                    damageThreshold = 40;
                    maxHitPoints = 200;
                    break;
            }
        }

        // *********************************
        // *** Required by the interface ***
        // *********************************
        /// <summary>
        /// Increases the amount of damage this Door has taken
        /// if it surpasses this door's damage threshold
        /// </summary>
        /// <param name="amountOfDamage"></param>
        public void TakeDamage(int amountOfDamage)
        {
            if (amountOfDamage >= damageThreshold)
            {
                currentDamage += amountOfDamage;
            }
        }
    }
}
