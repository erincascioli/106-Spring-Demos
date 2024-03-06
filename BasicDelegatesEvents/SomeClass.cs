using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDelegatesEvents
{
    internal class SomeClass
    {
        // Field of the class
        private string word;

        // Event of this class
        public event VoidMethod TriggerMe;

        /// <summary>
        /// Constructs a SomeClass object
        /// </summary>
        public SomeClass()
        {
            word = "banana";
        }

        /// <summary>
        /// Prints this class's word
        /// </summary>
        public void PrintWord()
        {
            Console.WriteLine("SOME CLASS. My word is " + word);
        }

        /// <summary>
        /// Invokes the TriggerMe event
        /// </summary>
        public void Trigger()
        {
            if(TriggerMe != null)
            {
                TriggerMe();
            }
        }
    }
}
