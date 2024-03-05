using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDelegateDemo
{
    class TightlyCoupledButton
    {
        private string buttonText;
        private List<Character> chars;

        #region Constructors
        /// <summary>
        /// Creates a Button with no reference to anything.
        /// </summary>
        /// <param name="text">Text displayed on the button.</param>
        public TightlyCoupledButton(string text)
        {
            this.buttonText = text;
            DrawButton();
        }

        /// <summary>
        /// Creates a Button with a reference to one character. 
        /// This Button controls that single character.
        /// </summary>
        /// <param name="text">Text displayed on the button.</param>
        /// <param name="charToMove">Reference to a Character</param>
        public TightlyCoupledButton(string text, Character characterRef)
        {
            this.buttonText = text;
            DrawButton();
            chars = new List<Character>();
            chars.Add(characterRef);
        }

        /// <summary>
        /// Creates a Button with a reference to two characters.
        /// This Button can control either character.
        /// </summary>
        /// <param name="text">Text displayed on the button.</param>
        /// <param name="characterRef1">Reference to first character</param>
        /// <param name="characterRef2">Reference to second character</param>
        public TightlyCoupledButton(string text, Character characterRef1, Character characterRef2)
        {
            this.buttonText = text;
            DrawButton();
            chars = new List<Character>();
            chars.Add(characterRef1);
            chars.Add(characterRef2);
        }
        #endregion

        #region Methods specific to Button attributes
        /// <summary>
        /// Draws a visual representation of this button in a Console window.
        /// </summary>
        public void DrawButton()
        {
            ButtonBorderLine(buttonText.Length + 4);
            Console.WriteLine("| " + buttonText + " |");
            ButtonBorderLine(buttonText.Length + 4);
        }

        /// <summary>
        /// Helper method that draws a top or bottom line of a Button.
        /// </summary>
        /// <param name="length">Number of characters to draw; length of characters in the button's text + 4</param>
        public void ButtonBorderLine(int length)
        {
            for (int i = 0; i < length; i++)
            {
                Console.Write("-");
                if (i == length - 1)
                {
                    Console.Write("\n");
                }
            }
        }
        #endregion

        #region Tightly Coupled Button Methods
        //---------------------------------------------------------------------
        /* These methods would need to be in the Button class if no
            *   delegates or events are utilized.
            * Every Button would need to have alllll of the possible abilities of
            *   every single thing that it could possibly do.
            * The Button would also need a reference to every single object that
            *   its clicking would affect.  
            * Does a button change the background color of the window?
            *    - It needs a reference to the Game window.
            *  Does a button increase a player's score?
            *    - It needs a reference to that player.
            *  Are there more than one players it can have?
            *    - Now it needs a separate reference, or a list of references,
            *      to every single one of those players.
            *  Does a button increase or decrease the game's volume?
            *    - The button must have a way to access the volume.
            *  Get it?
            *  The button class is then "tightly-coupled" to the Game window,
            *    Player class, and the volume system.
            *  Events in conjunction with delegates allow us to "uncouple" the
            *    architecture.  A button class should hold only the information
            *    that a button needs: color, size, text, images, etc.
            *  A button shouldn't also need to have methods that could do 
            *    basically everything it could possibly do...
            * */
        //---------------------------------------------------------------------

        // The button class would have a way of knowing it was "clicked"
        // If this was a visual program, I might want to check the bounds
        //   of the button to determine if a mouse cursor is within those
        //   bounds.

        /// <summary>
        /// Some action will occur when this button is clicked
        /// </summary>
        public void ClickDash()
        {
            // Description of the action occurring when this method runs.
            Console.WriteLine("Clicked the " + buttonText + " button!");
            
            // Move the Dash character that this Button has a reference to.
            chars[0].MoveCharacter();
        }

        public void ClickAnna()
        {
            // Description of the action occurring when this method runs.
            Console.WriteLine("Clicked the " + buttonText + " button!");

            // Move the Anna character that this Button has a reference to.
            chars[0].MoveCharacter();
        }

        /// <summary>
        /// Click to display all information of all characters
        /// </summary>
        public void ClickShowAllInfo()
        {
            // Description of the action occurring when this method runs.
            Console.WriteLine("Clicked the " + buttonText + " button!");

            // Display every character's info to the console window.
            foreach (Character character in chars)
            {
                character.DisplayCharacterInfo();
            }
        }
        #endregion
    }
}
