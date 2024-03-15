using System;
using System.Diagnostics;
using System.IO;
using System.Timers;
using System.Windows.Forms;
using NASK.OSE.CertChecker.ServiceLibrary;
using NASK.OSE.CertChecker.Tray.Properties;
using NASK.OSE.CertChecker.TrayLibrary;

namespace NASK.OSE.CertChecker.Tray;

public class TrayContext : ApplicationContext
{
	private NotifyIcon icon;

	private readonly OseCertServiceUtils service;

	private readonly System.Timers.Timer timer = new System.Timers.Timer();

	private readonly int timer_interval = 5000;

	private Process mainapphandle;

	public TrayContext()
	{
		service = new OseCertServiceUtils();
		icon = new NotifyIcon
		{
			Icon = Resources.greenshield,
			ContextMenu = new ContextMenu(new MenuItem[2]
			{
				new MenuItem(Resources.MenuRunMainApp, RunMainApp),
				new MenuItem(Resources.MenuExit, Exit)
			}),
			Visible = true
		};
		icon.DoubleClick += Icon_DoubleClick;
		TimerInitialize();
	}

	private void Icon_DoubleClick(object sender, EventArgs e)
	{
		RunMainApp(sender, e);
	}

	private void DoCheck(Action<bool> what_to_do)
	{
		what_to_do?.Invoke(service.CheckLastResult());
	}

	private void TimerInitialize()
	{
		timer.Elapsed += OnElapsedTime;
		timer.Interval = timer_interval;
		timer.Enabled = true;
	}

	private void OnElapsedTime(object source, ElapsedEventArgs e)
	{
		DoCheck(delegate(bool result)
		{
			if (result)
			{
				icon.Icon = Resources.greenshield;
			}
			else
			{
				icon.Icon = Resources.redshield;
			}
		});
	}

	private void Check(object sender, EventArgs e)
	{
		DoCheck(delegate(bool result)
		{
			if (result)
			{
				MessageBox.Show(Resources.CertIsOk, Resources.CertWindowCaption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
				MessageBox.Show(Resources.CertIsNotOk, Resources.CertWindowCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		});
	}

	private void RunMainApp(object sender, EventArgs e)
	{
		OseCertMainAppUtils oseCertMainAppUtils = new OseCertMainAppUtils(Path.GetDirectoryName(Application.ExecutablePath) + "\\");
		mainapphandle = oseCertMainAppUtils.Run();
	}

	private void About(object sender, EventArgs e)
	{
		new About().Show();
	}

	private void Exit(object sender, EventArgs e)
	{
		PreExit();
		Application.Exit();
	}

	public void StopMainApp()
	{
		if (mainapphandle != null)
		{
			new OseCertMainAppUtils().Stop();
			mainapphandle = null;
		}
	}

	public void PreExit()
	{
		icon.Visible = false;
	}
}
