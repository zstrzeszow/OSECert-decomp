using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace NASK.OSE.CertChecker.UI.Properties;

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
				resourceMan = new ResourceManager("NASK.OSE.CertChecker.UI.Properties.Resources", typeof(Resources).Assembly);
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

	internal static Bitmap GreenShield100 => (Bitmap)ResourceManager.GetObject("GreenShield100", resourceCulture);

	internal static Bitmap GreenShield500 => (Bitmap)ResourceManager.GetObject("GreenShield500", resourceCulture);

	internal static Bitmap logo_ose => (Bitmap)ResourceManager.GetObject("logo_ose", resourceCulture);

	internal static Bitmap RedShield100 => (Bitmap)ResourceManager.GetObject("RedShield100", resourceCulture);

	internal static Bitmap RedShield500 => (Bitmap)ResourceManager.GetObject("RedShield500", resourceCulture);

	internal static Bitmap ribbon => (Bitmap)ResourceManager.GetObject("ribbon", resourceCulture);

	internal Resources()
	{
	}
}
