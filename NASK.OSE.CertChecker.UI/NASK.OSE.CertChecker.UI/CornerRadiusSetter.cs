using System;
using System.Windows;
using System.Windows.Controls;

namespace NASK.OSE.CertChecker.UI;

public class CornerRadiusSetter
{
	public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(CornerRadiusSetter), new UIPropertyMetadata(default(CornerRadius), CornerRadiusChangedCallback));

	public static CornerRadius GetCornerRadius(DependencyObject obj)
	{
		return (CornerRadius)obj.GetValue(CornerRadiusProperty);
	}

	public static void SetCornerRadius(DependencyObject obj, CornerRadius value)
	{
		obj.SetValue(CornerRadiusProperty, value);
	}

	public static void CornerRadiusChangedCallback(object sender, DependencyPropertyChangedEventArgs e)
	{
		if (sender is Control control)
		{
			control.Loaded -= Control_Loaded;
			control.Loaded += Control_Loaded;
		}
	}

	private static void Control_Loaded(object sender, EventArgs e)
	{
		if (sender is Control { Template: not null } control)
		{
			control.ApplyTemplate();
			if (control.Template.FindName("border", control) is Border border)
			{
				border.CornerRadius = GetCornerRadius(control);
			}
		}
	}
}
