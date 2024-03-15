using System.Diagnostics;
using Microsoft.Win32;

namespace NASK.OSE.CertChecker.TrayLibrary;

public class OseCertTrayUtils : OseCertProcessUtils
{
	private static string AutostartRegistryKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";

	private static string AutostartRegistryKey6432 = "SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Run";

	public override string AppName => "OSECertCheckerTray.exe";

	public OseCertTrayUtils(string path = null)
		: base(path)
	{
	}

	public override Process Run()
	{
		Process process = base.Run();
		if (process != null && IsRunning())
		{
			SetAutostart();
		}
		return process;
	}

	public override bool Stop(bool withKill = true)
	{
		base.Stop(withKill);
		SetAutostart(mode: false);
		return !IsRunning();
	}

	public bool IsAutostart()
	{
		try
		{
			using RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(AutostartRegistryKey, writable: true);
			return registryKey != null && registryKey.GetValue(CertCheckerTrayNames.AutostartName) != null;
		}
		catch
		{
		}
		return false;
	}

	public void SetAutostart(bool mode = true)
	{
		try
		{
			using RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(AutostartRegistryKey, writable: true);
			if (registryKey != null)
			{
				if (mode)
				{
					registryKey.SetValue(CertCheckerTrayNames.AutostartName, base.AppPath);
				}
				else if (registryKey.GetValue(CertCheckerTrayNames.AutostartName) != null)
				{
					registryKey.DeleteValue(CertCheckerTrayNames.AutostartName);
				}
			}
		}
		catch
		{
		}
	}
}
