using System.ComponentModel;
using System.Windows.Input;
using NASK.OSE.CertChecker.Library;
using NASK.OSE.CertChecker.ServiceLibrary;
using NASK.OSE.CertChecker.TrayLibrary;

namespace NASK.OSE.CertChecker.UI;

internal class CheckerViewModel
{
	private OseCertUtils cert_utils;

	private OseCertServiceUtils service_utils;

	private OseCertTrayUtils tray_utils;

	private ICommand _checkCommand;

	private ICommand _installCommand;

	private ICommand _uninstallCommand;

	private ICommand _toggleAccordingToFlagCommand;

	public CheckerModel Model { get; }

	public ICommand CheckCommand => _checkCommand ?? (_checkCommand = new CommandHandler(delegate
	{
		Check();
	}, canExecute: true));

	public ICommand InstallCommand => _installCommand ?? (_installCommand = new CommandHandler(delegate
	{
		Install();
	}, canExecute: true));

	public ICommand UninstallCommand => _uninstallCommand ?? (_uninstallCommand = new CommandHandler(delegate
	{
		Uninstall();
	}, canExecute: true));

	public ICommand ToggleAccordingToFlagCommand => _toggleAccordingToFlagCommand ?? (_toggleAccordingToFlagCommand = new CommandHandler(delegate
	{
		ToggleAccordingToFlag();
	}, canExecute: true));

	public CheckerViewModel()
	{
		Model = new CheckerModel();
		Model.PropertyChanged += Model_PropertyChanged;
		cert_utils = new OseCertUtils();
		service_utils = new OseCertServiceUtils();
		tray_utils = new OseCertTrayUtils();
		Check();
	}

	private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "Flag")
		{
			ToggleAccordingToFlag();
		}
	}

	private void Check()
	{
		Model.IsCertInstalled = cert_utils.IsInstalled();
		Model.IsServiceInstalled = service_utils.IsInstalled();
		Model.IsServiceRunning = Model.IsServiceInstalled && service_utils.IsRunning();
		Model.IsTrayRunning = tray_utils.IsRunning();
		Model.Flag = tray_utils.IsAutostart() && service_utils.IsAutostart();
		Model.UserName = cert_utils.GetUserName();
	}

	private void Install()
	{
		cert_utils.Install();
		if (Model.Flag)
		{
			AddMonitors();
		}
		Check();
	}

	private void Uninstall()
	{
		cert_utils.Uninstall();
		DeleteMonitors();
		Check();
	}

	private void ToggleAccordingToFlag()
	{
		if (Model.Flag)
		{
			AddMonitors();
		}
		else
		{
			DeleteMonitors();
		}
		Check();
	}

	private void AddMonitors()
	{
		service_utils.Start();
		tray_utils.Run();
	}

	private void DeleteMonitors()
	{
		service_utils.Stop();
		tray_utils.Stop(withKill: false);
	}
}
