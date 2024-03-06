namespace BasicDelegates
{
    internal class Program
    {
        // Delegates are usually declared as public fields of a class
        //   so that all classes can use them. 
        // A delegate is a CUSTOM data type that holds a reference to a method
        public delegate int UseTwoNumbersDelegate(int a, int b);

        // Can declare as many delegates as needed in your code
        public delegate void AnyVoidMethodDelegate();

        static void Main(string[] args)
        {
            // ----------------------------------------------------------------
            // Once a delegate exists, you can create VARIABLES of that delegate!
            // The variables hold references to individual methods.
            // Don't use () in the variable assignment --> we're not CALLING the method,
            //    we are telling the compiler what method to use when it sees this variable.
            UseTwoNumbersDelegate myMethodVariable = AddTwoNumbers;

            // How do you use the method stored in a variable?
            // Invoke the method via the variable!
            // Pass any necessary parameters into the invocation.
            int result = myMethodVariable(1, 2);

            // AddTwoNumbers can also be called like we're used to. 
            result = AddTwoNumbers(1, 2);

            // Both of these do the same thing! They both run the code inside the AddTwoNumbers
            //   method and print the sum to the console window. 
            Console.WriteLine(myMethodVariable(10, 300));
            Console.WriteLine(AddTwoNumbers(10, 300));
            // ----------------------------------------------------------------


            // ----------------------------------------------------------------
            // Use another variable of the same delegate type!
            UseTwoNumbersDelegate mySecondMethodVariable = MultiplyTwoNumbers;

            // result holds the product of 2 and 3. 
            // Both the method call and the invocation run all code inside of MultiplyTwoNumbers.
            result = MultiplyTwoNumbers(2, 3);
            result = mySecondMethodVariable(2, 3);
            // ----------------------------------------------------------------


            // ----------------------------------------------------------------
            // Use yet another variable of a different delegate type!
            AnyVoidMethodDelegate myMethodThatDoesSomething = DoAThing;

            // These 2 statements both run the code inside of the DoAThing method below.
            DoAThing();
            myMethodThatDoesSomething();
            // ----------------------------------------------------------------


            // Can assign class methods to a variable of delegate type, too!
            SomeClass someObject = new SomeClass(294732);
            someObject.PrintMyInformation();


            AnyVoidMethodDelegate classMethodVariable = someObject.PrintMyInformation;
            classMethodVariable();

        }

        public static int AddTwoNumbers(int a, int b)
        {
            return a + b;
        }

        public static int MultiplyTwoNumbers(int a, int b)
        {
            return (int)(a * b);
        }

        public static void DoAThing()
        {
            Console.WriteLine("Hi everyone! This is confusing but we'll do our best!");
        }
    }
}