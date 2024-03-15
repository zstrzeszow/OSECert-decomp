using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace NASK.OSE.CertChecker.TrayLibrary;

public abstract class OseCertProcessUtils
{
	private readonly string path;

	public abstract string AppName { get; }

	public string AppPath => path + AppName;

	protected OseCertProcessUtils(string path = null)
	{
		this.path = path;
		if (this.path == null)
		{
			this.path = Environment.CurrentDirectory + "\\";
		}
	}

	public bool IsRunning()
	{
		return GetProcess() != null;
	}

	public virtual Process Run()
	{
		if (!IsRunning())
		{
			ProcessStartInfo processStartInfo = new ProcessStartInfo();
			processStartInfo.FileName = AppPath;
			processStartInfo.WorkingDirectory = path;
			try
			{
				return Process.Start(processStartInfo);
			}
			catch
			{
				return null;
			}
		}
		return GetProcess();
	}

	public virtual bool Stop(bool withKill = true)
	{
		if (withKill)
		{
			GetProcess()?.Kill();
		}
		return !IsRunning();
	}

	private Process GetProcess()
	{
		return Process.GetProcessesByName(Path.GetFileNameWithoutExtension(AppName)).FirstOrDefault();
	}
}
