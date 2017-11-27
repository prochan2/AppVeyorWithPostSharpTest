using System;
using System.Windows.Controls;
using System.Windows.Threading;
using PostSharp.Aspects;
using PostSharp.Aspects.Dependencies;
using PostSharp.Patterns.Threading;
using PostSharp.Serialization;

namespace PostSharp.Samples.Xaml
{
  [PSerializable]
  [AspectTypeDependency(AspectDependencyAction.Require, AspectDependencyPosition.After, typeof(BackgroundAttribute))]
  [LinesOfCodeAvoided(4)]
  public sealed class DisableUIAttribute : OnMethodBoundaryAspect
  {
    public override void OnEntry(MethodExecutionArgs args)
    {
      SetEnabled((Control) args.Instance, false);
    }

    public override void OnExit(MethodExecutionArgs args)
    {
      SetEnabled((Control) args.Instance, true);
    }

    private static void SetEnabled(Control control, bool enabled)
    {
      control.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => control.IsEnabled = enabled));
    }
  }
}