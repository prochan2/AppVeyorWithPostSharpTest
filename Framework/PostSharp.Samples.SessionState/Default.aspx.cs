using System;
using System.Web.UI;

namespace PostSharp.Samples.SessionState
{
  public partial class Default : Page
  {
    [SessionState] private int sessionCounter;

    [ViewState] private int viewStateCounter;

    protected void incrementButton_OnClick(object sender, EventArgs e)
    {
      sessionCounter++;
      viewStateCounter++;
    }

    protected override void OnPreRender(EventArgs e)
    {
      sessionCounterLabel.Text = sessionCounter.ToString();
      pageViewCounterLabel.Text = viewStateCounter.ToString();
    }
  }
}