When you have a large object model, annotating it for the WCF serializer (`DataContractFormatter`)
can be tedious. All classes and derived classes need to be annotated with the `[DataContract]` custom
attribute, and all properties need the `[DataMember]` custom attribute. If you forget a single `[DataMember]` 
attribute, no build-time error or run-time will occur, but your program will behave incorrectly and the
defect may be difficult to diagnose.

In many cases, what you actually need is to serialize all classes derived from a common base class,
and by default all properties should be serialized. This example demonstrates how to address this situation.

The `AutoDataContractAttribute` aspect automatically adds custom attributes `DataContract`  
to the target and derives classes so they can be serialized by the WCF formatter. By default, the aspect
adds the `[DataMember]` custom attribute to all properties. Properties that must not be serialized must be 
annotated with the custom attribute `NotDataMemberAttribute`.

As a result of using `AutoDataContractAttribute`, you are not forced to pollute your code with
`[DataContract]` and `[DataMember]` attribute, and most importantly, you will never forget to 
add a `[DataMember]` attribute again.

## What is being demonstrated?

This example demonstrates the use of `IAspectProvider` and `CustomAttributeIntroductionAspect`. The
`AutoDataContractAttribute` aspect does not represent any code transformation in itself. Instead, it
provides instances of the `CustomAttributeIntroductionAspect` aspect through the `IAspectProvider`
interface.

Inheritance of the `AutoDataContractAttribute` aspect from the base class to derived classes is
implemented thanks to the `[MulticastAttributeUsage(Inheritance = MulticastInheritance.Strict)]`
custom attribute.
