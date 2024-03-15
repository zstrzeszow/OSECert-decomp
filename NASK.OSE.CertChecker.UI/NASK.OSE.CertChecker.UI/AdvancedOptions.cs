using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;

namespace NASK.OSE.CertChecker.UI;

public partial class AdvancedOptions : Window, IComponentConnector
{
	public AdvancedOptions()
	{
		InitializeComponent();
		base.Style = (Style)FindResource(typeof(Window));
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		base.DialogResult = true;
		Close();
	}

	private void Button_Click_1(object sender, RoutedEventArgs e)
	{
		base.DialogResult = false;
		Close();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
