// A delegate is a type that represents references to methods with a particular parameter list and return type. 
// When you instantiate a delegate, you can associate its instance with any method with a compatible signature 
// and return type. You can invoke (or call) the method through the delegate instance.
// https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/
// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/delegate-operator

using System;

namespace SimpleIntDelegates
{
    class DefiningDelegate
    {
        // delegate <return type> <delegate-name> <parameter list>
        public delegate int operationOf2Integers(int a, int b);

        public operationOf2Integers? adding;
        public operationOf2Integers? addingAndSubstracting;
    }

    class SomeMethods
    {
        public int sum(int a, int b)
        {
            Console.WriteLine($"Sum: {a} + {b} = {a+b}");
            return a+b;
        }

        public int substract(int a, int b)
        {
            Console.WriteLine($"Substraction: {a} + {b} = {a-b}");
            return a-b;
        }
    }

    public delegate int AnotherDelegate(int c, int d);
    public delegate int DelegateWithOneParam(int a);

    class Program
    {        
        public static void Main()
        {
            DefiningDelegate myClassWithDelegate = new DefiningDelegate();
            SomeMethods someMethods = new SomeMethods();

            myClassWithDelegate.adding = someMethods.sum;
            myClassWithDelegate.adding?.Invoke(2, 4);

            Console.WriteLine();

            myClassWithDelegate.addingAndSubstracting = someMethods.sum;
            myClassWithDelegate.addingAndSubstracting += someMethods.substract;
            myClassWithDelegate.addingAndSubstracting?.Invoke(10, 6);

            Console.WriteLine();

            // Once a delegate type is defined, you can also create an object of that delegate type.
            AnotherDelegate a1 = new AnotherDelegate(someMethods.sum);
            a1?.Invoke(3,3);

            Console.WriteLine();

            // You can also create the delegate by directly declaring a delegate
            AnotherDelegate a2 = delegate(int a, int b) { Console.WriteLine($"Sum: {a} + {b} = {a+b}"); return a+b; };
            a2?.Invoke(1,1);

            Console.WriteLine();

            // You can also create the delegate by directly declaring a delegate using a lambda expression
            AnotherDelegate a3 = (a,b) => { Console.WriteLine($"Sum: {a} + {b} = {a+b}"); return a+b; };
            a3?.Invoke(5,4);

            Console.WriteLine();

            // If the lamda expression has just one parameter, you can omit the parameter's parentheses
            DelegateWithOneParam a4 = s => { Console.WriteLine($"s squared is: {s} * {s} = {Math.Pow(s,2)}"); return s*s; };
            a4?.Invoke(7);
        }
    }
}