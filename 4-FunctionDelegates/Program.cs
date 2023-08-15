// Encapsulates a method that has one parameter and returns a value of the type specified by the TResult parameter.
// https://learn.microsoft.com/en-us/dotnet/api/system.func-2?view=net-7.0

using System;

namespace FunctionDelegates
{
    class DefiningDelegate
    {
        // public delegate TResult Func<in T,out TResult>(T arg);
        public Func<int,int,int>? operationOf2Integers;
        public Func<int,int,int>? AnotherDelegate;
        public Func<int,int>? DelegateWithOneReturnedParam;

        // The last type inside the <> defines the return type. 
        // If there are two or more types inside the <>, the first ones are the paramenters.
        // You can have up to 16 parameters and the result value.
        // public Func<int,int,int,int,int,int,int,int,int,int,int,int,int,int,int,int, bool>? DelegateWith16ParamsAnd1ReturnValue;
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
            myClassWithDelegate.AnotherDelegate = new Func<int,int,int>(someMethods.sum);
            myClassWithDelegate.AnotherDelegate?.Invoke(3,3);

            Console.WriteLine();

            // You can also create the delegate by directly declaring a delegate
            myClassWithDelegate.AnotherDelegate = delegate(int a, int b) { Console.WriteLine($"Sum: {a} + {b} = {a+b}"); return a+b; };
            myClassWithDelegate.AnotherDelegate?.Invoke(1,1);

            Console.WriteLine();

            // You can also create the delegate by directly declaring a delegate using a lambda expression
            myClassWithDelegate.AnotherDelegate = (a,b) => { Console.WriteLine($"Sum: {a} + {b} = {a+b}"); return a+b; };
            myClassWithDelegate.AnotherDelegate?.Invoke(5,4);

            Console.WriteLine();

            // If the lamda expression has just one parameter, you can omit the parameter's parentheses
            myClassWithDelegate.DelegateWithOneReturnedParam = s => { Console.WriteLine($"s squared is: {s} * {s} = {Math.Pow(s,2)}"); return s*s; };
            myClassWithDelegate.DelegateWithOneReturnedParam?.Invoke(7);
        }
    }
}