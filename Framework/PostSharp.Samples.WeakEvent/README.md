This example demonstrates how to use the `EventInterceptionAspect` to implement a weak event pattern.

A weak event is an event that holds a weak reference to the delegate instead of a strong reference. 
Therefore, the weak event does not prevent the listener objects to be garbage collected.

Event handlers are often source of memory leaks in .NET. The reason is that the delegates registered as event handlers store a strong reference to the listener objects. 
The event source indirectly holds a strong reference to all listener objects.

Implementing the weak event pattern requires cooperation of the event source and the listener object. If the exposing object only stores weak references to the delegates, 
the delegates are immediately collected even while the consumer object is still alive. To prevent immediate garbage collection of delegates, 
the consumer must hold strong references to all delegates passed to the weak events.

The pattern is implemented by the following artefacts:

* The `[WeakEvent]` aspect can be applied to any event. The `[WeakEvent]` aspect is based on `EventInterceptionAspect` and implements the `IInstanceScopedAspect` interface to store instance-scoped data.
* The `[WeakEventClient]` aspect can be applied to any consumer of a weak event. The `[WeakEventClient]` aspect automatically implements the `IWeakEventClient` interface. The `[WeakEventClient]` aspect demonstrates the following features: `InstanceLevelAspect`, `IntroduceInterface`.
* The `WeakEventValidation` constraint is attached to the `WeakEvent` aspect. It validates, at build time, that clients of weak events are enhanced with the `[WeakEventClient]` aspect or manually implement the `IWeakEventClient` interface.
  Additionally to this build-time validation, the `[WeakEvent]` aspect throws an exception if the consumer class does not have the `[WeakEventClient]` aspect or does not manually implement the `IWeakEventClient` interface. 

To allow an event to store strong references when the client does not implement the `IWeakEventClient` interface, use the code `[WeakEvent(AllowStrongReferences=true)]`.

## Limitations

This example has not been sufficiently tested for production use.
