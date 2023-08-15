// Events enable a class or object to notify other classes or objects when something of interest occurs. 
// The class that sends (or raises) the event is called the publisher 
// and the classes that receive (or handle) the event are called subscribers.
// https://www.tutorialsteacher.com/csharp/csharp-event
// https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/events/
// https://learn.microsoft.com/en-us/dotnet/csharp/distinguish-delegates-events

// - When you add the event keyword before a delegate, it can only be invoked from the class.
// - You can only use `+=` and `-=` operators to subscribe/unsubscribe from an event. 
//   You cannot use `=` operator outside of the publisher class.
// - The publisher should never care about what the subscriber does when the event is raised.
// - We encapsulate the invocation of the event inside a protected virtual method, 
//   this will allow subclasses to override this method.

using System;

namespace EventHandlerTDelegates
{
    class DefiningEventDelegate
    {
        // public delegate void EventHandler(object? sender, EventArgs e);
        public event EventHandler<bool>? ProcessCompleted;

        public void StartProcess()
        {
            try
            {
                Console.WriteLine("Process Started!");
                
                // some code here..

                OnProcessCompleted(true);
            }
            catch(Exception)
            {
                OnProcessCompleted(false);
            }
        }

        protected virtual void OnProcessCompleted(bool isSuccessful)
        {
            ProcessCompleted?.Invoke(this, isSuccessful); 
        }
    }

    class Program
    {        
        public static void Main()
        {
            DefiningEventDelegate myClassWithDelegate = new DefiningEventDelegate();
            myClassWithDelegate.ProcessCompleted += MyMethod;
            myClassWithDelegate.StartProcess();
        }

        public static void MyMethod(object? sender, bool IsSuccessful)
        {
            Console.WriteLine("Process " + (IsSuccessful ? "Completed Successfully" : "failed"));
        }
    }
}