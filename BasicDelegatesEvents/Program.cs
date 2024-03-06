namespace BasicDelegatesEvents
{
    // Delegates are generally public and declared/defined outside of classes,
    //   so they are usable in ALL classes in the namespace.
    public delegate int UseTwoNumbers(int a, int b);
    public delegate int UseThreeNumbers(int a, int b, int c);
    public delegate void VoidMethod();

    internal class Program
    {
        static void Main(string[] args)
        {
            // ----------------------------------------------------------------
            // Variables of delegate types
            // ----------------------------------------------------------------
            // A single variable can be declared of a matching delegate type
            // Do not put () after the method name - we're not calling it!
            // Just assigning it to the variable.
            UseTwoNumbers methodVariable = AddTwoNumbers;

            // ----------------------------------------------------------------
            // Invoking a method via its variable
            // ----------------------------------------------------------------
            // Invoke the method by using the variable as if it is the method.
            int result = methodVariable(2, 5);      // 7


            // ----------------------------------------------------------------
            // Another variable and invocation
            // ----------------------------------------------------------------
            // Another variable of a different delegate type
            UseThreeNumbers anotherVariable = AddThreeNumbers;
            result = anotherVariable(5, 10, 20);    // 35

            // Methods in classes can be stored in variables of a delegate type, too.
            // We're not limited to public static methods in the Program class.
            SomeClass aThing = new SomeClass();
            VoidMethod voidVariable = aThing.PrintWord;
            voidVariable();


            // ----------------------------------------------------------------
            // Event subscribing!
            // ----------------------------------------------------------------
            // Subscribing:  PrintSomething1 method "subscribes" to the TriggerMe event
            aThing.TriggerMe += PrintSomething1;

            // Subscribing:  PrintSomething2 method "subscribes" to the TriggerMe event
            aThing.TriggerMe += PrintSomething2;

            // Subscribing:  PrintSomething3 method "subscribes" to the TriggerMe event
            aThing.TriggerMe += PrintSomething3;

            // ----------------------------------------------------------------
            // Subscribing:  Another object subscribes to the event
            // ----------------------------------------------------------------
            AnotherClass another = new AnotherClass();
            aThing.TriggerMe += another.PrintWord;

            // ----------------------------------------------------------------
            // Event Invocation
            // ----------------------------------------------------------------
            // Invoke the event!
            aThing.Trigger();

            // ----------------------------------------------------------------
            // Subscribing:  PrintSomething1 method no longer wants to subscribes
            //   to the TriggerMe event after it subscribed the first time.
            // ----------------------------------------------------------------
            aThing.TriggerMe -= PrintSomething1;

            // Invoke again!  (Only PrintSomething2 and 3 run this time.)
            aThing.Trigger();
        }

        public static int AddTwoNumbers(int xfghhxfcjy, int fctyjchf)
        {
            return xfghhxfcjy + fctyjchf;
        }

        public static int MultiplyTwoNumbers(int a, int b)
        {
            return a * b;
        }

        public static int DivideTwoNumbers(int a, int b)
        {
            return a/b;
        }

        public static int AddThreeNumbers(int a, int b, int c)
        {
            return a + b + c;
        }

        public static void PrintSomething1()
        {
            Console.WriteLine("Rip and tear until it's done");
        }

        public static void PrintSomething2()
        {
            Console.WriteLine("I need a weapon");
        }

        public static void PrintSomething3()
        {
            Console.WriteLine("Ya ha ha, you found me!");
        }
    }
}