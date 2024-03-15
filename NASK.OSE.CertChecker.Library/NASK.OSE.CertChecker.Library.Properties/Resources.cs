using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace NASK.OSE.CertChecker.Library.Properties;

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
				resourceMan = new ResourceManager("NASK.OSE.CertChecker.Library.Properties.Resources", typeof(Resources).Assembly);
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

	internal static byte[] certyfikat => (byte[])ResourceManager.GetObject("certyfikat", resourceCulture);

	internal static byte[] certyfikatose => (byte[])ResourceManager.GetObject("certyfikatose", resourceCulture);

	internal static byte[] local_settings_js => (byte[])ResourceManager.GetObject("local_settings_js", resourceCulture);

	internal static byte[] naskca => (byte[])ResourceManager.GetObject("naskca", resourceCulture);

	internal static byte[] ose_cfg => (byte[])ResourceManager.GetObject("ose_cfg", resourceCulture);

	internal static byte[] policies => (byte[])ResourceManager.GetObject("policies", resourceCulture);

	internal Resources()
	{
	}
}
