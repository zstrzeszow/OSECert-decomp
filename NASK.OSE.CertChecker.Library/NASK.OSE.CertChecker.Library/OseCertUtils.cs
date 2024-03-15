using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using Microsoft.Win32;
using NASK.OSE.CertChecker.Library.Properties;

namespace NASK.OSE.CertChecker.Library;

public class OseCertUtils
{
	private string cert_subject;

	private string CertSubject
	{
		get
		{
			if (string.IsNullOrEmpty(cert_subject))
			{
				cert_subject = GetCertificate().Subject;
			}
			return cert_subject;
		}
	}

	private X509Certificate2 GetCertificate()
	{
		return new X509Certificate2(Resources.certyfikatose);
	}

	private X509Store GetStore()
	{
		return new X509Store(StoreName.Root, StoreLocation.LocalMachine);
	}

	private X509Certificate2Collection FindCertificates(X509Store store)
	{
		return store?.Certificates.Find(X509FindType.FindBySubjectDistinguishedName, CertSubject, validOnly: false);
	}

	public bool IsInstalled()
	{
		if (IsCertInstalled())
		{
			return IsInstalledForFF();
		}
		return false;
	}

	public bool IsCertInstalled()
	{
		X509Store store = GetStore();
		store.Open(OpenFlags.ReadOnly);
		X509Certificate2Collection x509Certificate2Collection = FindCertificates(store);
		store.Close();
		if (x509Certificate2Collection != null)
		{
			return x509Certificate2Collection.Count > 0;
		}
		return false;
	}

	public bool IsInstalledForFF()
	{
		string text = FirefoxPath();
		if (text == null)
		{
			return true;
		}
		return File.Exists(Path.Combine(text, "distribution", "policies.json"));
	}

	public bool Install()
	{
		InstallCert();
		InstallForFF();
		return true;
	}

	private bool InstallCert()
	{
		if (IsCertInstalled())
		{
			return false;
		}
		X509Certificate2 certificate = GetCertificate();
		X509Store store = GetStore();
		store.Open(OpenFlags.ReadWrite);
		store.Add(certificate);
		store.Close();
		return true;
	}

	public bool Uninstall()
	{
		UninstallCert();
		UninstallForFF();
		return true;
	}

	private bool UninstallCert()
	{
		X509Store store = GetStore();
		store.Open(OpenFlags.ReadWrite);
		X509Certificate2Collection x509Certificate2Collection = FindCertificates(store);
		store.RemoveRange(x509Certificate2Collection);
		store.Close();
		if (x509Certificate2Collection != null)
		{
			return x509Certificate2Collection.Count > 0;
		}
		return false;
	}

	public string FirefoxPath()
	{
		if (Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\firefox.exe", "", null) is string path)
		{
			return Path.GetDirectoryName(path);
		}
		return null;
	}

	public bool InstallForFF()
	{
		if (IsInstalledForFF())
		{
			return false;
		}
		string text = FirefoxPath();
		if (text == null)
		{
			return false;
		}
		string text2 = Path.Combine(text, "distribution");
		if (!Directory.Exists(text2))
		{
			Directory.CreateDirectory(text2);
		}
		string path = Path.Combine(text2, "policies.json");
		try
		{
			File.WriteAllBytes(path, Resources.policies);
			return true;
		}
		catch
		{
			return false;
		}
	}

	public bool UninstallForFF()
	{
		if (!IsInstalledForFF())
		{
			return false;
		}
		string text = FirefoxPath();
		if (text == null)
		{
			return false;
		}
		string path = Path.Combine(Path.Combine(text, "distribution"), "policies.json");
		if (File.Exists(path))
		{
			File.Delete(path);
		}
		return true;
	}

	public string GetUserName()
	{
		return WindowsIdentity.GetCurrent().Name;
	}

	public static bool IsUserAdministrator()
	{
		if (new WindowsPrincipal(WindowsIdentity.GetCurrent() ?? throw new NullReferenceException("Could not determine windows identity")).IsInRole(WindowsBuiltInRole.Administrator))
		{
			return true;
		}
		return false;
	}
}
