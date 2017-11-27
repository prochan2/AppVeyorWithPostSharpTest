This example demonstrates how to use `LocationInterceptionAspect` to persist a field or property in the ASP.NET session state or page view state.

* The `SessionStateAttribute` class is a Aspect that persists a field or property into the session state. This attribute can be
added to any field or property. This aspect is a simple implementation of `LocationInterceptionAspect`.

* The `ViewStateAttribute` class is a Aspect that persists a field or property into the view state of the current page. This attribute should 
be added to an instance field or property of a type derived from `System.Web.UI.Control`. The `ViewStateAttribute` aspect is more complex because
it needs to access the `ViewState` property, a *protected* property of the `Control` class. Therefore, we have to use the `[ImportMember]` advice
and the `IInstanceScopedAspect` interface. 

