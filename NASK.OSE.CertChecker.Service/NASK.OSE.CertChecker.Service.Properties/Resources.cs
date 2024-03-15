using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace NASK.OSE.CertChecker.Service.Properties;

[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
internal class Resources
{
	private static ResourceManager resourceMan;

	private static CultureInfo resourceCulture;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager ResourceManager
	{
		get
		{
			if (resourceMan == null)
			{
				resourceMan = new ResourceManager("NASK.OSE.CertChecker.Service.Properties.Resources", typeof(Resources).Assembly);
			}
			return resourceMan;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo Culture
	{
		get
		{
			return resourceCulture;
		}
		set
		{
			resourceCulture = value;
		}
	}

	internal static string InstallationError => ResourceManager.GetString("InstallationError", resourceCulture);

	internal static string InstallationOk => ResourceManager.GetString("InstallationOk", resourceCulture);

	internal static string LocationError => ResourceManager.GetString("LocationError", resourceCulture);

	internal static string LocationOk => ResourceManager.GetString("LocationOk", resourceCulture);

	internal static string Start => ResourceManager.GetString("Start", resourceCulture);

	internal static string Stop => ResourceManager.GetString("Stop", resourceCulture);

	internal static string UninstallationError => ResourceManager.GetString("UninstallationError", resourceCulture);

	internal static string UninstallationOk => ResourceManager.GetString("UninstallationOk", resourceCulture);

	internal Resources()
	{
	}
}
