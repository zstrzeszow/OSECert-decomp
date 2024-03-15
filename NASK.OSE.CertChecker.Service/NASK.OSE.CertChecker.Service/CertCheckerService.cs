using System.ComponentModel;
using System.Diagnostics;
using System.ServiceProcess;
using System.Timers;
using NASK.OSE.CertChecker.Library;
using NASK.OSE.CertChecker.Service.Properties;

namespace NASK.OSE.CertChecker.Service;

public class CertCheckerService : ServiceBase
{
	private readonly OseCertUtils certificate = new OseCertUtils();

	private readonly Timer timer = new Timer();

	private readonly int timer_interval = 10000;

	private IContainer components;

	public CertCheckerService()
	{
		InitializeComponent();
		if (!EventLog.SourceExists(CertCheckerNames.ServiceName))
		{
			EventLog.CreateEventSource(CertCheckerNames.ServiceName, CertCheckerNames.LogName);
		}
	}

	protected override void OnStart(string[] args)
	{
		TimerInitialize();
	}

	private void TimerInitialize()
	{
		timer.Elapsed += OnElapsedTime;
		timer.Interval = timer_interval;
		timer.Enabled = true;
	}

	protected override void OnStop()
	{
	}

	private void OnElapsedTime(object source, ElapsedEventArgs e)
	{
		Check();
	}

	private void Check()
	{
		if (certificate.IsInstalled())
		{
			LogInfo(Resources.LocationOk, 1, 1);
			return;
		}
		LogInfo(Resources.LocationError, 2, 1, EventLogEntryType.Warning);
		Install();
	}

	private void Install()
	{
		if (certificate.Install())
		{
			LogInfo(Resources.InstallationOk, 3, 2);
			Check();
		}
		else
		{
			LogInfo(Resources.InstallationError, 4, 2, EventLogEntryType.Error);
		}
	}

	private void Uninstall()
	{
		if (certificate.Uninstall())
		{
			LogInfo(Resources.UninstallationOk, 5, 3);
			Check();
		}
		else
		{
			LogInfo(Resources.UninstallationError, 6, 3, EventLogEntryType.Error);
		}
	}

	private void LogInfo(string Message, int eventid, short eventcategory, EventLogEntryType entrytype = EventLogEntryType.Information)
	{
		using EventLog eventLog = new EventLog(CertCheckerNames.LogName);
		try
		{
			eventLog.Source = CertCheckerNames.ServiceName;
			eventLog.WriteEntry(Message, entrytype, eventid, eventcategory);
		}
		catch
		{
		}
	}

	protected override void OnCustomCommand(int command)
	{
		switch (command)
		{
		case 128:
			Check();
			break;
		case 129:
			Install();
			break;
		case 130:
			Uninstall();
			break;
		}
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
		components = new Container();
		base.ServiceName = CertCheckerNames.ServiceName;
	}
}
