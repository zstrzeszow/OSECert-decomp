namespace NASK.OSE.CertChecker.Service;

public enum CertificateLogEventId : short
{
	LocationOk = 1,
	LocationError,
	InstallationOk,
	InstallationError,
	UninstallationOk,
	UninstallationError
}
