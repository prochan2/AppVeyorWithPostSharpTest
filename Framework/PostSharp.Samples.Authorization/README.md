This example demonstrates how to enforce a non-trivial security model with aspect-oriented programming. 

The `PostSharp.Samples.Authorization.Framework` defines the skeleton of an abstract security model. The key concept is represented the `IPermission` interface, with typical
values `Permission.Read` or `Permission.Write`, for instance. Permissions are things that the current `ISubject` need to be granted to be allowed to read or write a field
or execute a method. However

The `ApplyDefaultPermissionsAttribute` aspect automatically requires the `Permission.Read` or `Permission.Write` on public fields and properties.

You can use the `RequiresPermissionAttribute` aspect on fields, properties and methods to require a specific permission.

The abstract security framework does not specify how to determine whether the current `ISubject` has a given `IPermission`. This job is delegated to the `ISecurityPolicy` interface, 
which can have different implementations.

The `PostSharp.Samples.Authorization.RoleBased` namespace provides an example implementation of the role-based security model:

* Each business object has a list of assignments of users to roles (for instance Mikki is Sales Manager in the business unit).
* Each business object has a parent and inherits user-role assignments from its parent (for instance an Invoice inherits the role assignments from its parent business unit).
* For each class of business objects, there is a list of assignments of roles to permissions (for instance, Sale Managers have the Write permission on invoices).

The `RoleBasedSecurityPolicy` class implements the `ISecurityPolicy` interface for the role-based model.


## Limitations

* THIS EXAMPLE IS NOT SUFFICIENTLY TESTED FOR PRODUCTION USE. This is only a proof of concept.
* Performance is really poor because even evaluating a property causes the evaluation of complex policies and allocations of memory on the heap. A better implementation should cache permissions.
