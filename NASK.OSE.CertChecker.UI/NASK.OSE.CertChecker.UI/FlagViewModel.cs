namespace NASK.OSE.CertChecker.UI;

internal class FlagViewModel
{
	public bool Flag { get; set; }

	public FlagViewModel(CheckerViewModel vm)
	{
		Flag = vm.Model.Flag;
	}
}
