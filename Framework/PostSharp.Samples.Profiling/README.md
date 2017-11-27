This example demonstrates how to build an aspect `ProfileAttribute` that you can apply to any method to measure 
its execution time.

The aspect measures a few key metrics:

 * *Wall Time* is the time between the start and the completion of the method.
 
 * *Synchronous Time* is the time when a method has been executed synchronously on a thread. For `async` methods, 
    the synchronous execution time is the wall time minus any time spent awaiting for another task.
    
 * *CPU Time* is the time that the method has effectively spent executing on the CPU. It does not include
   the time when the CPU was busy doing something else than executing the method (or children method). Time
   spent waiting for external resources, even synchronously, is not included. Time spent when the current
   thread is preempted is not included. Note that the timer resolution used to compute the CPU time is not
   as precise as the one used to compute the wall and synchronous times, so small inconsistencies may appear.
   
## Results

In this example, the aspect is applied to several methods, both synchronous and async. When you execute the
program, you should see something similar to the following output:

```
Program.GetRandomBytes - Wall time 4675 ms; Synchronous time 4675 ms; CPU time: 4109 ms
Program.SleepSync - Wall time 200 ms; Synchronous time 200 ms; CPU time: 0 ms
Program.SleepAsync - Wall time 206 ms; Synchronous time 5 ms; CPU time: 0 ms
Program.ReadAndHashSync - Wall time 3594 ms; Synchronous time 3594 ms; CPU time: 31 ms
Program.ReadAndHashAsync - Wall time 3431 ms; Synchronous time 113 ms; CPU time: 31 ms
```


## Limitations

You should not use the `ProfileAttibute` aspect on methods that are very fast because the aspect itself
adds some overhead and increases the load on Gen0 garbage collection.

The aspect does not show how to store, analyze or display the performance metrics. 

## Demonstrated techniques

The aspect demonstrates the use of `OnMethodBoundaryAspect` on async methods, especially the use of
the `OnYield` and `OnResume` advices. It also shows how to use `MethodExecutionTag` to share information between advices
in a way that is both thread-safe and reentrance-safe. 
