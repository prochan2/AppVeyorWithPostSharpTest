When you want to validate values assigned to method parameters, the validation  is most often executed at runtime.
You do not get any warning that something is broken until you execute a method that is being validated during testing.
If you do not execute the method during testing then you are not notified about a possible bug at all.

It would be better to do the validation already at build time. Then you would not need do the testing at all
and there is no chance to miss any warning.

This example demonstrates how to use PostSharp Architecture Framework to validate, at build time,
that the value passed to a string parameter is a valid string in a managed resource.

The `ValidateResourceStringAttribute` implements the validation constraint. The `ValidateResourceStringAttribute`
inherits from `ReferentialConstraint` because you need to validate the *usage* of the method, not the method itself. 

The `ValidateConstraint` method validates that the `[ValidateResourceString(string resourceName)]` attribute is used on a parameter of type `string`,
and checks that the resource with `resourceName` exists in the current project. If the resource with `resourceName` does not exist in the current
project then the `ValidateConstraint` emits a build warning. 

The `ValidateCode` method first uses the `ReflectionSearch.GetMethodsUsingDeclaration` method to get a list of 
all methods invoking the validated method. Then, you use a `SyntaxTreeVisitor` to analyze bodies of these methods and to check
if values assigned to a validated parameter is a valid resource key. 

The `ValidateResourceStringAttribute` constraint can validate just literal or constants passed to a validated parameter.
If you pass an expression requiring runtime evaluation to a validate parameter, for example a variable or a method call expression
then the validation at the build time cannot work.