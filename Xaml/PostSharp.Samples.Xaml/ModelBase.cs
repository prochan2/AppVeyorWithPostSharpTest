using PostSharp.Patterns.Model;
using PostSharp.Patterns.Recording;
using PostSharp.Patterns.Threading;

namespace PostSharp.Samples.Xaml
{
  // We're adding two aspects to the base class of all Model classes and the aspects
  // will be automatically added by all children classes.

  [NotifyPropertyChanged]
  [Recordable(ProvideMethodContext = true)]
  [ReaderWriterSynchronized]
  public abstract class ModelBase
  {
  }
}