using System.ServiceProcess;

namespace NASK.OSE.CertChecker.Service;

internal static class Program
{
	private static void Main()
	{
		ServiceBase.Run(new ServiceBase[1]
		{
			new CertCheckerService()
		});
	}
}
