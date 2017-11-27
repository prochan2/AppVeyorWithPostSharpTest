Exception handling is one of the most common sources of boilerplate code and makes the business logic less readable. With PostSharp, you can
define exception handling policies centrally and apply them to your business logic from a single point.

This example implements two aspects:

* `AddContextOnExceptionAttribute` is meant to be added to all methods in the assembly using the one-liner `[assembly:AddContextOnException]`. Its role is 
   to add the parameter values of the current value to the `Exception.Data["Context"]` object. Since the aspect is supposed to be applied to all 
   user-written methods, the aspect will gather the parameter values of all user-written methods in the call stack, and it will be a great help for 
   debugging. This aspect does not suppress the exception.
   
* `ReportAndSwallowExceptionAttribute` writes the exception to the console (including the data collected by  `AddContextOnExceptionAttribute`) and 
   suppresses the exception. Suppressing exceptions is dangerous and you cannot do that on each method. You would typically use this kind of aspects 
   on an event handler (such as WPF and WinForms ones) or a thread entrypoint.

By combining these two aspects, you can achieve better maintainability of your application without making the code unreadable and thus unmanageable.


## What is being demonstrated?

This example demonstrates the following techniques:

* The `OnExceptionAspect` aspect.
* Multicasting the `AddContextOnExceptionAttribute` aspect to all methods in the assembly thanks to `[assembly: AddContextOnException]` (see `Program.cs`).

Now you know how to use PostSharp to handle exceptions from one place, with good separation of concerns.
 The logic you implement this way makes your code much more maintainable and easier to read.


## Limitations

This example is not concerned with many details you are concerned with in your production code:

* Not thread-safe.
* Not optimized.
* Not having robust logging of exception.
