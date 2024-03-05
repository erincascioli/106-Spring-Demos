using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 3/4/2020
// Demo: Generics and Indexers

namespace GenericDemo
{
	class Program
	{
		static void Main(string[] args)
		{
            // -------------- Use a generic data structure -------------------
			// Make a data structure to hold strings
			MyDataStructure<string> myStuff = 
				new MyDataStructure<string>();

            // Add some stuff to it
            myStuff.Add("some string");

            // -------------- Use indexer property -------------------
            // Use the indexer "set" to change the data
            myStuff[0] = "something else";

            // Use the indexer "get" to retrieve data
            Console.WriteLine(myStuff[0]);

            // -------------- Use another generic data structure -------------------
            // Make another data structure to hold integers
            MyDataStructure<int> myOtherStuff =
                new MyDataStructure<int>();

            myOtherStuff.Add(34543);
            myOtherStuff.Add(345);
            myOtherStuff.Add(123);
            myOtherStuff.Add(85746);

            // -------------- NO NO NO -------------------
            // DON'T DO THIS!!!!!!
            //int[] dataFromTheDS = myOtherStuff.Data;
            /*
            dataFromTheDS[0] = 0;
            dataFromTheDS[1] = 0;
            dataFromTheDS[2] = 0;
            dataFromTheDS[3] = 0;
            Console.WriteLine(dataFromTheDS[0]);
            Console.WriteLine(dataFromTheDS[1]);
            Console.WriteLine(dataFromTheDS[2]);
            Console.WriteLine(dataFromTheDS[3]);
            */


            // This data structure could also hold classes
            //MyDataStructure<Thing> myReallyOtherStuff =
            //    new MyDataStructure<Thing>();
        }
    }
}
