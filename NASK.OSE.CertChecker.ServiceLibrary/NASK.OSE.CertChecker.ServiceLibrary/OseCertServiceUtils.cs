using System;
using System.Configuration.Install;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.ServiceProcess;
using NASK.OSE.CertChecker.Service;

namespace NASK.OSE.CertChecker.ServiceLibrary;

public class OseCertServiceUtils
{
	private ServiceController GetServiceController()
	{
		return new ServiceController(CertCheckerNames.ServiceName);
	}

	private AssemblyInstaller GetInstaller()
	{
		return new AssemblyInstaller(typeof(CertCheckerService).Assembly, null)
		{
			UseNewContext = true
		};
	}

	private bool RunCommand(CertCheckerMethods command)
	{
		if (!IsInstalled() || !IsRunning())
		{
			return false;
		}
		using (ServiceController serviceController = GetServiceController())
		{
			new ServiceControllerPermission(ServiceControllerPermissionAccess.Control, Environment.MachineName, CertCheckerNames.ServiceName).Assert();
			serviceController.Refresh();
			try
			{
				serviceController.ExecuteCommand((int)command);
			}
			catch
			{
				throw;
			}
		}
		return true;
	}

	public bool IsInstalled()
	{
		using ServiceController serviceController = GetServiceController();
		try
		{
			_ = serviceController.Status;
		}
		catch
		{
			return false;
		}
		return true;
	}

	public bool IsRunning()
	{
		if (!IsInstalled())
		{
			return false;
		}
		using ServiceController serviceController = GetServiceController();
		return serviceController.Status == ServiceControllerStatus.Running;
	}

	public bool Start()
	{
		if (!IsInstalled())
		{
			return false;
		}
		using (ServiceController serviceController = GetServiceController())
		{
			try
			{
				if (serviceController.Status != ServiceControllerStatus.Running)
				{
					serviceController.Start();
					serviceController.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(10.0));
					SetAutostart(serviceController);
				}
			}
			catch
			{
				throw;
			}
		}
		return true;
	}

	public bool Stop()
	{
		if (!IsInstalled())
		{
			return false;
		}
		using (ServiceController serviceController = GetServiceController())
		{
			try
			{
				if (serviceController.Status != ServiceControllerStatus.Stopped)
				{
					serviceController.Stop();
					serviceController.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(10.0));
					SetAutostart(serviceController, mode: false);
				}
			}
			catch
			{
				throw;
			}
		}
		return true;
	}

	public bool IsAutostart()
	{
		using ServiceController svc = GetServiceController();
		return ServiceHelper.QueryStartupMode(svc) == ServiceStartMode.Automatic;
	}

	public void SetAutostart(ServiceController svc, bool mode = true)
	{
		ServiceHelper.ChangeStartMode(svc, mode ? ServiceStartMode.Automatic : ServiceStartMode.Manual);
	}

	public bool CheckLastResult()
	{
		if (!RunCommand(CertCheckerMethods.CheckStatus))
		{
			return false;
		}
		string query = $"*[System/Provider/@Name=\"{CertCheckerNames.ServiceName}\" and System/Task={(short)1}]";
		EventLogQuery eventQuery = new EventLogQuery(CertCheckerNames.LogName, PathType.LogName, query);
		try
		{
			using EventLogReader eventLogReader = new EventLogReader(eventQuery);
			eventLogReader.Seek(SeekOrigin.End, -1L);
			return eventLogReader.ReadEvent().Id == 1;
		}
		catch (EventLogNotFoundException)
		{
			throw;
		}
	}
}
