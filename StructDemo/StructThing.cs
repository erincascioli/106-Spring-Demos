using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructDemo
{
    internal struct StructThing
    {
        private int x;
        private string word;

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public StructThing()
        {
            x = 100;
            word = "Game";
        }

        public StructThing(int x, string word)
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
