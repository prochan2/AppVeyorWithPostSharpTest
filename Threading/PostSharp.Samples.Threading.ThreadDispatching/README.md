This example demonstrates how to execute some methods in the background and some other methods in the UI thread using just custom attributes.

The `DoStuff` method has the `[Background]` aspect and therefore will be executed in the thread pool. This method invokes the `SetProgress` and `EnableControls` methods,
which update the UI and therefore must be executed on the UI thread. Without PostSharp, the background method should call `Dispatcher.BeginInvoke()`. With PostSharp,
methods requiring to be dispatched onto the UI thread must be annotated with the [Dispatched] custom attribute.

By using `[Background]` and `[Dispatched]`, you can write multi-threaded code without cluttering it with calls to the `ThreadPool` or the `Dispatcher`. Your code remains clean.
