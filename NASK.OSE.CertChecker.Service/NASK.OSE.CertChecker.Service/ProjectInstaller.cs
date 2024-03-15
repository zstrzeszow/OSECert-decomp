using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace NASK.OSE.CertChecker.Service;

[RunInstaller(true)]
public class ProjectInstaller : Installer
{
	private IContainer components;

	private ServiceProcessInstaller serviceProcessInstaller1;

	private ServiceInstaller serviceInstaller1;

	public ProjectInstaller()
	{
		InitializeComponent();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		serviceProcessInstaller1 = new ServiceProcessInstaller();
		serviceInstaller1 = new ServiceInstaller();
		serviceProcessInstaller1.Account = ServiceAccount.LocalSystem;
		serviceProcessInstaller1.Password = null;
		serviceProcessInstaller1.Username = null;
		serviceInstaller1.Description = "OSE Cert Checker";
		serviceInstaller1.DisplayName = CertCheckerNames.ServiceDisplayName;
		serviceInstaller1.ServiceName = CertCheckerNames.ServiceName;
		base.Installers.AddRange(new Installer[2] { serviceProcessInstaller1, serviceInstaller1 });
	}
}
