using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo
{
    internal interface IDamageable
    {
        // FYI: COMMENT your interfaces with basic, general outcomes!!!!

        // Return the total amount of damage an object has taken so far
        int CurrentDamage { get; }

        // Determine if the object will remain in the game
        bool IsExpired { get; }

        // Harm the object by a set amount
        void TakeDamage(int amount);
    }
}
