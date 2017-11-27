
This example demonstrates how to build an aspect `RequiresTransactionAttribute` that forces the method to which it is applied
to execute into a transaction. The aspect relies on the `System.Transactions` namespace, which supports distributed transactions,
i.e. transactions involving several transactional services. 

You can add this aspect to any method that must run in a transaction, even a distibuted one. However, these methods should not
have non-transactionalside effects. Most importantly, transactional methods should not make changes to memory that may be visible
to other methods or threads.

You can use this aspect both in a desktop and server-side application. However, it is generally not recommended to 
manage distributed transactions on the client side.

The aspect opens a `TransactionScope` at the beginning of the target method and calls the 
`TransactionScope.Complete` method at the end of the target method. The aspect also adds a try/finally around the target method
so it can dispose the `TransactionScope` before the method exits.

The aspect demonstrates the use of `OnMethodBoundaryAspect` and `MethodExecutionTag`. `OnMethodBoundaryAspect` is responsible
for adding the try/catch block and injecting the code, and `MethodExecutionTag` allows you to store the `TransactionScope`
object between `OnEntry`, `OnSuccess` and `OnExit`.
