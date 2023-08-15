// Actions encapsulate a method that has a single parameter and does not return a value.
// https://learn.microsoft.com/en-us/dotnet/api/system.action-1?view=net-7.0

using System;

namespace ActionDelegates
{
    class DefiningDelegate
    {
        // An Action is a type of delegate that hasn't got a return value.
        // public delegate void Action<in T>(T obj);
        public Action<int, int>? operationOf2Integers;
        public Action<int, int>? AnotherDelegate;
        public Action<int>? DelegateWithOneParam;

        // The types inside the <> define the parameters of the delegate. You can have up to 16 parameters
        // public Action<int,int,int,int,int,int,int,int,int,int,int,int,int,int,int,int>? DelegateWith16Params;
    }

    class SomeMethods
    {
        public void sum(int a, int b)
        {
            Console.WriteLine($"Sum: {a} + {b} = {a+b}");
        }

        public void substract(int a, int b)
        {
            Console.WriteLine($"Substraction: {a} + {b} = {a-b}");
        }
    }

    class Program
    {        
        public static void Main()
        {
            DefiningDelegate myClassWithDelegate = new DefiningDelegate();
            SomeMethods someMethods = new SomeMethods();

            myClassWithDelegate.operationOf2Integers = someMethods.sum;
            myClassWithDelegate.operationOf2Integers?.Invoke(2, 4);
            myClassWithDelegate.operationOf2Integers -= someMethods.sum;

            Console.WriteLine();

            myClassWithDelegate.operationOf2Integers = someMethods.sum;
            myClassWithDelegate.operationOf2Integers += someMethods.substract;
            myClassWithDelegate.operationOf2Integers?.Invoke(10, 6);

            Console.WriteLine();

            // Once a delegate type is defined, you can also create an object of that delegate type.
            myClassWithDelegate.AnotherDelegate = new Action<int, int>(someMethods.sum);
            myClassWithDelegate.AnotherDelegate?.Invoke(3,3);

            Console.WriteLine();

            // You can also create the delegate by directly declaring a delegate
            myClassWithDelegate.AnotherDelegate = delegate(int a, int b) { Console.WriteLine($"Sum: {a} + {b} = {a+b}"); };
            myClassWithDelegate.AnotherDelegate?.Invoke(1,1);

            Console.WriteLine();

            // You can also create the delegate by directly declaring a delegate using a lambda expression
            myClassWithDelegate.AnotherDelegate = (a,b) => Console.WriteLine($"Sum: {a} + {b} = {a+b}");
            myClassWithDelegate.AnotherDelegate?.Invoke(5,4);

            Console.WriteLine();

            // If the lamda expression has just one parameter, you can omit the parameter's parentheses
            myClassWithDelegate.DelegateWithOneParam = s => Console.WriteLine($"s squared is: {s} * {s} = {Math.Pow(s,2)}");
            myClassWithDelegate.DelegateWithOneParam?.Invoke(7);
        }
    }
}