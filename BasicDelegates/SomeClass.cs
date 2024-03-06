using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDelegates
{
    internal class SomeClass
    {
        private int number;


        public SomeClass(int number)
        {
            this.number = number;
        }

        public void PrintMyInformation()
        {
            Console.WriteLine($"My number is {number}!");
        }
    }
}
