This example demonstrates how to build aspects that automatically encrypt or decrypt parameter 
values. The only encryption algorithm implemented in this example is string reversal. This
is not real encryption, of course! In practice, you would probably use a format-preserving
encryption algorithm from a third party.

The `FilterAttribute` class is the abstract implementation of the aspect. It is not bound
to any encryption implementation algorithm. To implement a specific algorithm, you need
to derive a new class from `FilterAttribute` class. In this example, we just show
a `ReserseAttribute` aspect.

In some situations, for instance in ASP.NET MVC controllers, you may need to decrypt or
encrypt properties of a method parameter instead of the parameter itself (encrypting
an object is impossible; you can only either serialize its members with a format-preserving
algorithm, or the serialization of the object using binary encryption). For this scenario,
we have the `ApplyFiltersAttribute`, also derived from `FilterAttribute`. This custom
attribute causes the parameter value to be deeply decrypted or encrypted. You can apply
any filter attribute (either `[Reverse]` or `[ApplyFilters]` in this example) to
fields and properties of the parameter class.

## What is being demonstrated?

The `FilterAttribute` class is more complex than it appears because it must support
two cases: encryption of parameter values and deep encryption of object trees. Under
the cover, the job is done by two separate aspects: `FilterMethodArgumentsAspect` and
`FilterTypePropertiesAspect`. However, we don't want to ask developers to choose between
the aspects. All we want to show to developers are front-end attributes derived
from the `FilterAttribute` class. Therefore, we use `FilterAttribute` as an
umbrella, hiding the implementation complexity. The `FilterAttribute` class whether
it has to provide a  `FilterMethodArgumentsAspect` or
`FilterTypePropertiesAspect` aspect. This is done by implementing the `IAspectProvider`
interface.

The `FilterMethodArgumentsAspect` class is quite simple and is based on a 
`MethodInterceptionAspect`. It is worth noting that we want to have a single
instance of the `FilterMethodArgumentsAspect`  class per method, even if several parameters
are encrypted. The `FilterAttribute` has to provide the de-duplication. This is
done by using the `IAspectRepositoryService` service from PostSharp, which returns which
aspects have already been added to a declaration.

The `FilterTypePropertiesAspect` class is more complex. It introduces the `IFilterable`
interface into the target type, an interface which has a single method named `ApplyFilters`.
To have access to fields and properties at runtime without reflection, the aspect
relies on an `IAdviceProvider` which provides a set of `ImportLocationAdviceInstance`
advices: one for each encrypted property. At runtime, the `bindings` field of the aspect class
is populated with a `List<ILocationBinding>`, which gives access to all properties.



