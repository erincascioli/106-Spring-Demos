using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructDemo
{
    internal class ClassThing
    {
        private int x;
        private string word;

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public ClassThing()
        {
            x = 100;
            word = "Game";
        }

        public ClassThing(int x, string word)
        {
            this.x = x;
            this.word = word;
        }

        public override string ToString()
        {
            return "X: " + x + "   Word: " + word;
        }

        public void DisplayInfo()
        {
            Console.WriteLine("X: " + x);
            Console.WriteLine("Word: " + word);
        }
    }
}
