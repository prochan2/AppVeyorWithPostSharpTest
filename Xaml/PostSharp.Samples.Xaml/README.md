Very often, an application seems to have only simple requirements from a user's point of view, for instance just a few forms with a few actions.
However, users may have implicit requirements and they won't be happy until these requirements are not only identified, but also implemented.
Undo/redo, automatic UI refresh and input validation are a few of those.

These expectations can complicate a fairly simple application and add a load of unappreciated work. PostSharp can help you to avoid this camouflaged complexity by
implementing several complex patterns. These monsters made hair of many of your fellow programmers turn gray. You can see their basic usage in this example,
 a small WPF application.

NotifyPropertyChanged
---------------------

The user expects to see changes immediately after they make a modification to the form. The refresh button is no longer welcome.

You probably heard `INotifyPropertyChanged` interface and its extensive use in architectural patterns such as MVVM. You may even have implemented this interface
for several classes. It is pain. Sure, C# 6.0 relieved us of mentioning properties via literal string by instroducing `nameof` and similar features. 
But still, it remains a pain. There are few libraries that does a lot for you, but they don't completely relieve you from boilerplate code.

That's why we built the `[NotifyPropertyChanged]` aspect. It implements data binding automatically, without pollution from boilerplate code.
 Your business logic remains clean. 

In the code of this example, you can see the `[NotifyPropertyChanged]` aspect applied to both a view and the view model to implement `INotifyPropertyChanged`. The 
aspect will raise change notifications for all properties without manual code, even for composite properties referencing children objects, like 
`CustomerViewModel.FullName`.


Undo/Redo
---------

When the user does something wrong, they expect a quick way to fix it. 
The more advanced ones will press `Ctrl+Z`, others will look for an undo button. If there is none, they will blame it to the application
developer, because they deeply expect undo/redo in all applications.

What users don't know is that undo/redo is very cumbersome to implement using pure C# or VB. But it does not need to be.

PostSharp provides you with `Recordable` aspect that records changes made to the object. You can group multiple changes into operations and
then go back and forth, restoring old state of the application.

In the code of this example, you can see the `[Recordable]` aspect applied on the `ModelBase` class. By inheritance, all model classes will get the aspect. 
We had to annotate a few fields with `[Child]` and `[Reference]` custom attributes, and to change collections to `AdvisableCollection` so that changes to these collections are also recorded.

`MainWindow.xaml` contains the Undo and Redo buttons provided by the `PostSharp.Patterns.Model.Controls` package.

The `MyOperationFormatter` class shows how to customize the name of operations as they appear under the Undo expandable button.  


Code Contracts
--------------

PostSharp's Code Contracts allow you to validate that the value assigned to a field or property, or passed to a parameter, is valid - just
by adding a custom attribute.  For instance,
the `[Required]` attribute checks that the value is not null and not empty. PostSharp provides several code contract custom attributes. 
Because the con

In the code of this example, you may see `[Required]` aspects to a few properties of the `CustomerModel` and `AddressModel` classes, which causes these properties
to throw an exception when someone attempts to set them to a null or empty string.

In `MainWindow.xaml`, we enabled the `ValidatesOnExceptions` feature of data bindings to display red borders when a property setter throws an exception.


Multithreading
--------------

To make things a bit more complex, let's add a Save button and let's suppose that saving the model to a file can be a time-consuming operation. In this example, we will
take the unrealistic assumption that serializing the object model itself, not just storing it on disk, it expensive. 

One of the worse things that can happen to your UI is to *freeze*. Users just hate it. Your UI will give the feeling to freeze when you perform a long-running operation in the
UI thread. For instance, when you save a complex object model directly from the UI thread. Therefore, we will need to save from a background thread. Technically, this is not
difficult: just add the `[Background]` aspect to the `Save` method. 

Now that we have a background thread, we also have a data race problem. What is the object model is changed while we are serializing it to disk? One idea is to disable the
UI during the operation. This is done through the  `[DisableUI]` custom aspect, which is pretty simple, as you will see.

Suppose that our application is more complex than this tiny example. How can we be sure that another thread is not modifying the object model while we are serializing it? 
The only way to be really sure is to synchronize access to the object model from different threads. A convenient model here is the *Reader-Writer Synchronized* threading model,
which allows the model to be read by several concurrent threads (for instance the UI and the background thread), but prevents writing during reading. We're doing
that by adding the `[ReaderWriterSynchronized]` aspect to the `ModelBase` class.  The good thing is that all the work we did to implement undo/redo, i.e. adding `[Child]`
and `[Reference]` to a few fields and change collections to `AdvisableCollection`, all this is also required by the `[ReaderWriterSynchronized]` and is already done! The next
step is to add `[Reader]` to the `Save` method in the model, to say that this method requires read-only access.

And we're done! We now have a multi-threaded *but* thread-safe application. 



In the end...
--------------

You see that you have quite extensive toolset for handling complexity of UI apps that is not perceived by users and your boss. 
You can handle automatic notification of property changes, undo-redo operations and use code contracts for form validations. 

