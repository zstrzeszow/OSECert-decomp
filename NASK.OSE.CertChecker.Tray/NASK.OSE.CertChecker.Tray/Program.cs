using System;
using System.Windows.Forms;

namespace NASK.OSE.CertChecker.Tray;

internal static class Program
{
	private static TrayContext context;

	[STAThread]
	private static void Main()
	{
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(defaultValue: false);
		Application.ApplicationExit += Application_ApplicationExit;
		context = new TrayContext();
		Application.Run(context);
	}

	private static void Application_ApplicationExit(object sender, EventArgs e)
	{
		context.StopMainApp();
		context.PreExit();
	}
}
