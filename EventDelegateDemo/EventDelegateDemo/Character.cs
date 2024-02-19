using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDelegateDemo
{
    /// <summary>
    /// Represents a character in a side-scroller game
    /// </summary>
    class Character
    {
        private Vector2 location;
        private string characterName;

        public Character(Vector2 location, string name)
        {
            this.location = location;
            this.characterName = name;
        }

        public Character(int x, int y, string name)
        {
            this.location = new Vector2(x, y);
            this.characterName = name;
        }

        /// <summary>
        /// Moves a character' position 5 units to the right
        /// </summary>
        public void MoveCharacter()
        {
            location.X += 5;
        }

        /// <summary>
        /// Display information about this character's position
        /// </summary>
        public void DisplayCharacterInfo()
        {
            Console.WriteLine(
                "{0} is at position {1}", 
                characterName, 
                location);
        }
    }
}
