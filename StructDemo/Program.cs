using System.Diagnostics;

namespace StructDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Objects from Classes

            // Objects of classes
            ClassThing myClassThing1 = new ClassThing();
            ClassThing myClassThing2 = new ClassThing(99999, "ABC");

            // Calling ToString Method - Pass into C.WL
            Console.WriteLine(myClassThing1.ToString());
            Console.WriteLine(myClassThing2);

            // Error! Logic.
            //myClassThing1.ToString();

            // DisplayInfo method is printing inside the method
            //myClassThing1.DisplayInfo();
            //myClassThing2.DisplayInfo();

            // List of class objects
            List<ClassThing> classList = new List<ClassThing>();
            classList.Add(myClassThing1);
            classList.Add(myClassThing2);

            // Change a value by accessing the class object from the list
            Console.WriteLine("Value before " + classList[0]);
            classList[0].X = 11111;
            Console.WriteLine("The values are now " + classList[0]);
            #endregion

            Console.WriteLine("-------------------------------------------");

            #region Objects from Structs
            /*
            // Objects of structs
            StructThing myStructThing1 = new StructThing();
            StructThing myStrictThing2 = new StructThing(99999, "ABC");

            // Calling ToString Method - Pass into C.WL
            //Console.WriteLine(myStructThing1.ToString());
            //Console.WriteLine(myStrictThing2);

            // Error! Logic.
            //myClassThing1.ToString();

            // DisplayInfo method is printing inside the method
            myStructThing1.DisplayInfo();
            myStrictThing2.DisplayInfo();

            // List of classes
            List<StructThing> structList = new List<StructThing>();
            structList.Add(myStructThing1);
            structList.Add(myStrictThing2);

            // Working with properties in LOCAL structs:
            //myStructThing1.X = 123456;

            // Change a value by accessing the class object from the list
            //Console.WriteLine("Value before " + classList[0]);
            //structList[0].X = 11111;
            //Console.WriteLine("The values are now " + classList[0]);
            */
            #endregion

            Console.WriteLine("-------------------------------------------");

            #region Performance Test
            /*
            // Performance test!

            Stopwatch timer = new Stopwatch();
            int number = 1000;
            timer.Start();

            for (int i = 0; i < number; i++)
            {
                ClassThing classObj = new ClassThing();
            }

            timer.Stop();
            Console.WriteLine("Classes are done! It took " + timer.Elapsed.TotalMilliseconds);

            timer.Reset();
            timer.Start();
            for (int i = 0; i < number; i++)
            {
                StructThing structObj = new StructThing();
            }

            timer.Stop();
            Console.WriteLine("Structs are done! It took " + timer.Elapsed.TotalMilliseconds);
            */
            #endregion

        }
    }
}