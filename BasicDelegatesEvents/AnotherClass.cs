using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDelegatesEvents
{
    internal class AnotherClass
    {
        // Field of the class
        private string word;

        /// <summary>
        /// Constructs an AnotherClass object
        /// </summary>
        public AnotherClass()
        {
            word = "boom boom";
        }

        /// <summary>
        /// Prints this class's word
        /// </summary>
        public void PrintWord()
        {
            Console.WriteLine("ANOTHER CLASS. My word is " + word);
        }
    }
}
