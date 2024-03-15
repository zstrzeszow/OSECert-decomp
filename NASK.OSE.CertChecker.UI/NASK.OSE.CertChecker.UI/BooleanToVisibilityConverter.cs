using System.Windows;

namespace NASK.OSE.CertChecker.UI;

public sealed class BooleanToVisibilityConverter : BooleanConverter<Visibility>
{
	public BooleanToVisibilityConverter()
		: base(Visibility.Visible, Visibility.Collapsed)
	{
	}
}
