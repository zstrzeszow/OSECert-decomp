using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace NASK.OSE.CertChecker.Tray.Properties;

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
				resourceMan = new ResourceManager("NASK.OSE.CertChecker.Tray.Properties.Resources", typeof(Resources).Assembly);
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

	internal static string CertIsNotOk => ResourceManager.GetString("CertIsNotOk", resourceCulture);

	internal static string CertIsOk => ResourceManager.GetString("CertIsOk", resourceCulture);

	internal static string CertWindowCaption => ResourceManager.GetString("CertWindowCaption", resourceCulture);

	internal static Icon greenshield => (Icon)ResourceManager.GetObject("greenshield", resourceCulture);

	internal static string MenuAbout => ResourceManager.GetString("MenuAbout", resourceCulture);

	internal static string MenuCheckCert => ResourceManager.GetString("MenuCheckCert", resourceCulture);

	internal static string MenuExit => ResourceManager.GetString("MenuExit", resourceCulture);

	internal static string MenuRunMainApp => ResourceManager.GetString("MenuRunMainApp", resourceCulture);

	internal static Icon redshield => (Icon)ResourceManager.GetObject("redshield", resourceCulture);

	internal Resources()
	{
	}
}
