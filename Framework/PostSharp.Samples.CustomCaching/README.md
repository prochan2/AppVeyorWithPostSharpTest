Caching your method's return value makes the method execution faster, trading memory for time by storing the return value in a cache.
If you call the method again then you can return a value stored in the cache, instead of doing time consuming calculation
all over again.

Typical candidates for caching are methods talking to snail-paced counterparts like databases or web services.

You can add the `Cache` aspect to any method with a return value.

When you call a method decorated by the `Cache` for the first time then the method calculates a return value and the `Cache` aspect stores
the return value in a cache. The execution flow looks like this:

1. `OnEntry` method calculates a cache key and stores the cache key in `MethodExecutionTag`.
2. `Cache` aspect passes the execution to the decorated method which calculates the return value.
3. `OnSuccess` method reads the cache key from `MethodExecutionTag` and stores the return value in the cache. 

When you call the method for the second time then the `Cache` aspect returns the cached return value. The execution flow looks like this:

1. `OnEntry` method reads the return value from the cache, stores the value `ReturnValue`
and sets `FlowBehavior` to `FlowBehavior.Return`.
2. `FlowBehavior.Return` terminates decorated method execution without doing the time consuming calculation.
3. The decorated method returns the cached value.  

`MethodExecutionTag` provides a communication channel between different events (`OnEntry`, `OnSuccess` in this example). You can store
any state information `MethodExecutionTag`. Both `OnEntry` and `OnSuccess` methods requires the cache key.  The `Cache` uses `MethodExecutionTag` to pass cache key from `OnEntry` method to `OnSuccess` method
and to avoid calculating the cache key twice.

## Limitations

This example is purely educational. It has the following limitations:

* Simplistic algorithm to compute the cache key.
* No cache eviction.
* Not optimized for run-time performance.
* MemoryCache only.
* No dependency management.
