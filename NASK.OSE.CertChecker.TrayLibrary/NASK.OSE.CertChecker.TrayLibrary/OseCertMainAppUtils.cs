namespace NASK.OSE.CertChecker.TrayLibrary;

public class OseCertMainAppUtils : OseCertProcessUtils
{
	public override string AppName => "OSECertChecker.exe";

	public OseCertMainAppUtils(string path = null)
		: base(path)
	{
	}
}
