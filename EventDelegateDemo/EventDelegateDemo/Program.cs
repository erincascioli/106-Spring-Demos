using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Erin Cascioli
// 3/28/22
// Demo: Events and Delegates

namespace EventDelegateDemo
{
	class Program
	{
		static void Main(string[] args)
		{
            // Characters that both buttons will affect
            Character dash = new Character(0, 0, "Dash");
            Character anna = new Character(50, 0, "Anna");

            // ----------------------------------------------------------------
            // TightlyCoupledButtons need access to objects they can affect.
            TightlyCoupledButton button1 = 
                new TightlyCoupledButton("Move Dash", dash);
            TightlyCoupledButton button2 = 
                new TightlyCoupledButton("Move Anna", anna);
            TightlyCoupledButton button3 = 
                new TightlyCoupledButton("Show Character Information", dash, anna);

            // Then they call special methods to affect those objects.
            button1.ClickDash();
            button2.ClickAnna();
            button3.ClickShowAllInfo();

            /*
            // ----------------------------------------------------------------
            // DecoupledButtons do NOT need references.
            // They can affect any object in the game.
            DecoupledButton button4 =
                new DecoupledButton("Move Dash");
            DecoupledButton button5 =
                new DecoupledButton("Move Anna");
            DecoupledButton button6 =
                new DecoupledButton("Show Character Information");

            // Decoupled Buttons need to know which methods to run when their
            // events are triggered.
            button4.ClickAction += dash.MoveCharacter;
            button5.ClickAction += anna.MoveCharacter;
            button6.ClickAction += dash.DisplayCharacterInfo;
            button6.ClickAction += anna.DisplayCharacterInfo;

            // Then we simply call the same method - Click - to affect the game.
            button4.Click();
            button5.Click();
            button6.Click();
            */          
        }
    }
}
