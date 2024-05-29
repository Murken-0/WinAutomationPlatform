using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common
{
	public class DesktopSession : IDisposable
	{
		private readonly WindowsDriver<WindowsElement> _session;

		public DesktopSession(string uri)
		{
			var options = new AppiumOptions();
			options.AddAdditionalCapability("app", "Root");
			options.AddAdditionalCapability("deviceName", "WindowsPC");
			_session = new WindowsDriver<WindowsElement>(new Uri(uri), options);
			_session.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(200);
		}

		public WindowsDriver<WindowsElement> DesktopSessionElement
		{
			get { return _session; }
		}

		public void Dispose() => _session.Quit();

		public WindowsElement FindElementByAbsoluteXPath(string xPath, int nTryCount = 10)
		{
			WindowsElement uiTarget = null;

			while (nTryCount-- > 0)
			{
				try
				{
					uiTarget = _session.FindElementByXPath(xPath);
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message);
				}

				if (uiTarget != null)
				{
					break;
				}
				else
				{
					Thread.Sleep(2000);
				}
			}

			return uiTarget;
		}
	}
}
