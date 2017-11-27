MiniProfiler from the makers of StackOverflow is one of the most popular and most useful libraries for 
ASP.NET developers. Thanks to MiniProfiler, you can easily track the execution time of selected methods.

Contrarily to normal profilers that track the execution time of all methods, MiniProfiler tracks only
the time of methods you specifically select.

The problem with MiniProfiler is that you have to modify your code to add a call to the 
`MiniProfiler.Step` method. This can be cumbersome if you have dozens or even hundreds of them.

PostSharp offers a convenient way to add MiniProfiler to a large set of methods without having
to modify the source code of these methods. 

In this example, the `MiniProfilerStepAttribute` aspect is responsible for calling the `MiniProfiler.Step`
method before method executions, and closing the step after execution. This aspect uses the 
`OnMethodBoundaryAspect` class and is very simple.

We want to measure the execution time off public methods all controllers and services. This is implemented
by the following two lines in `AssemblyInfo.cs`:

```
[assembly: MiniProfilerStep(AttributeTargetTypes = "*Service", AttributeTargetMemberAttributes = MulticastAttributes.Public)]
[assembly: MiniProfilerStep(AttributeTargetTypes = "*Controller", AttributeTargetMemberAttributes = MulticastAttributes.Public)]
```

Note how this example relies on naming conventions to identify service and controller classes.

Let's go back to the `MiniProfilerStepAttribute` class. Note that the `methodName` name is initialized
at build time in the `CompileTimeInitialize` method. This is a performance optimization trick.
At runtime, there is no need for reflection, and no need to allocate new strings at each method call.


## What is being demonstrated?

This example demonstrates the following techniques:

* The `OnMethodBoundaryAspect` aspect.
* Multicasting the aspect to several methods by filtering on type name and method attributes.

Thanks to this aspect, you can add MiniProfiler to dozens of methods in just a few lines of code.
