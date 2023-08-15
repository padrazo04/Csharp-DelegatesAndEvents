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
    class ProcessEventArgs : EventArgs
    {
        public bool IsSuccessful { get; set; }
        public DateTime CompletionTime { get; set; }
    }

    class DefiningEventDelegate
    {
        // public delegate void EventHandler(object? sender, EventArgs e);
        public event EventHandler<ProcessEventArgs>? ProcessCompleted;

        public void StartProcess()
        {
            var data = new ProcessEventArgs();
		
            try
            {
                Console.WriteLine("Process Started!");
                
                // some code here..
                
                data.IsSuccessful = true;
                data.CompletionTime = DateTime.Now;
                OnProcessCompleted(data);
            }
            catch(Exception ex)
            {
                data.IsSuccessful = false;
                data.CompletionTime = DateTime.Now;
                OnProcessCompleted(data);
            }
        }

        protected virtual void OnProcessCompleted(ProcessEventArgs e)
        {
            ProcessCompleted?.Invoke(this, e); 
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

        public static void MyMethod(object? sender, ProcessEventArgs e)
        {
            Console.WriteLine("Process " + (e.IsSuccessful? "Completed Successfully": "failed"));
        C   onsole.WriteLine("Completion Time: " + e.CompletionTime.ToLongDateString());
        }
    }
}