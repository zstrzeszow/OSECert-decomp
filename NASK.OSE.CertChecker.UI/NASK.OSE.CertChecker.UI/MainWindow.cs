using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Threading;

namespace NASK.OSE.CertChecker.UI;

public partial class MainWindow : Window, IComponentConnector
{
	public MainWindow()
	{
		InitializeComponent();
		base.Style = (Style)FindResource(typeof(Window));
		CheckerViewModel dataContext = new CheckerViewModel();
		base.DataContext = dataContext;
		DispatcherTimer dispatcherTimer = new DispatcherTimer();
		dispatcherTimer.Tick += DispatcherTimer_Tick;
		dispatcherTimer.Interval = new TimeSpan(0, 0, 10);
		dispatcherTimer.Start();
	}

	private void DispatcherTimer_Tick(object sender, EventArgs e)
	{
		((CheckerViewModel)base.DataContext).CheckCommand.Execute(null);
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
	}

	private void Button_Click_1(object sender, RoutedEventArgs e)
	{
		AdvancedOptions advancedOptions = new AdvancedOptions
		{
			Owner = this,
			DataContext = new FlagViewModel(base.DataContext as CheckerViewModel)
		};
		bool? flag = advancedOptions.ShowDialog();
		if (flag.HasValue)
		{
			bool valueOrDefault = flag.GetValueOrDefault();
			if (valueOrDefault && valueOrDefault)
			{
				((CheckerViewModel)base.DataContext).Model.Flag = ((FlagViewModel)advancedOptions.DataContext).Flag;
			}
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
