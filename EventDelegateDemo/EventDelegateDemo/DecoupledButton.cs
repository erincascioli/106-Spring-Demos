using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDelegateDemo
{
    // ************************************************************************
    // ***** Declare a Delegate for use in class ******************************
    // Declared outside class so the entire program can use this delegate.
    // Much like enums!
    public delegate void OnClickDelegate();
    // ************************************************************************


    class DecoupledButton
    {
        private string buttonText;

        // ************************************************************************
        // ***** Declare an event that uses any method of the delegate type *******
        public event OnClickDelegate ClickAction;
        // ************************************************************************

        #region Constructor
        /// <summary>
        /// Creates a Button.
        /// </summary>
        /// <param name="text">Text displayed on the button.</param>
        public DecoupledButton(string text)
        {
            this.buttonText = text;
            DrawButton();
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
        /// <param name="length">Number of characters to draw; 
        /// length of characters in the button's text + 4</param>
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

        // ************************************************************************
        // ***** Write method to trigger event ************************************
        // Write a method in THIS class that, when ran, triggers the event.
        // When this Click method runs, all methods in the ClickAction event
        //   are invoked in the order they were added.
        // ************************************************************************
        public void Click()
        {
            // // Description of the action occurring when this method runs.
            Console.WriteLine("Clicked the " + buttonText + " button!");

            // Trigger the event.
            // Ensure that there are subscribers first!
            if (ClickAction != null)
            {
                ClickAction();
            }
        }
        #endregion

        #region Decoupled Button Methods
        //---------------------------------------------------------------------
        /* 
         * None! :)
         * 
         * Since this button uses an event, all is needs is a Click method
         *   that can run different methods from OTHER classes or instances of
         *   OTHER objects.  
         * This Button no longer needs to have a reference to objects in order
         *   to communicate with them.
         * 
         * "I am a Button. It's my job to be clicked. No more, no less.
         *  When I am clicked, I will inform you that I have been clicked
         *  so that YOU can do your task."
         *
         */
        //---------------------------------------------------------------------
        #endregion
    }
}
