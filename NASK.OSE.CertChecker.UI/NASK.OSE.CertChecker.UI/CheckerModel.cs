using System.ComponentModel;

namespace NASK.OSE.CertChecker.UI;

public class CheckerModel : INotifyPropertyChanged
{
	private bool is_cert_installed;

	private bool is_service_installed;

	private bool is_service_running;

	private bool is_tray_running;

	private string username;

	private bool flag = true;

	public bool IsSafe
	{
		get
		{
			if (Flag)
			{
				if (IsCertInstalled && IsServiceRunning)
				{
					return IsTrayRunning;
				}
				return false;
			}
			return IsCertInstalled;
		}
	}

	public bool IsCertInstalled
	{
		get
		{
			return is_cert_installed;
		}
		set
		{
			if (value != is_cert_installed)
			{
				is_cert_installed = value;
				OnPropertyChanged("IsSafe");
				OnPropertyChanged("IsCertInstalled");
			}
		}
	}

	public bool IsServiceInstalled
	{
		get
		{
			return is_service_installed;
		}
		set
		{
			if (value != is_service_installed)
			{
				is_service_installed = value;
				OnPropertyChanged("IsSafe");
				OnPropertyChanged("IsServiceInstalled");
			}
		}
	}

	public bool IsServiceRunning
	{
		get
		{
			return is_service_running;
		}
		set
		{
			if (value != is_service_running)
			{
				is_service_running = value;
				OnPropertyChanged("IsSafe");
				OnPropertyChanged("IsServiceRunning");
			}
		}
	}

	public bool IsTrayRunning
	{
		get
		{
			return is_tray_running;
		}
		set
		{
			if (value != is_tray_running)
			{
				is_tray_running = value;
				OnPropertyChanged("IsSafe");
				OnPropertyChanged("IsTrayRunning");
			}
		}
	}

	public bool Flag
	{
		get
		{
			return flag;
		}
		set
		{
			if (value != flag)
			{
				flag = value;
				OnPropertyChanged("IsSafe");
				OnPropertyChanged("Flag");
			}
		}
	}

	public string UserName
	{
		get
		{
			return username;
		}
		set
		{
			username = value;
			OnPropertyChanged("UserName");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	private void OnPropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
