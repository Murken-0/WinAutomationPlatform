using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using CSScriptLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Template
{
	class Program
	{
		static void Main(string[] args)
		{
			DesktopSession desktopSession = new DesktopSession("http://192.168.0.128:4723/wd/hub");
			Thread.Sleep(2000);

			bool bSuccess = false;

			var path = @"D:\Script.cs";

			try
			{
				var code = File.ReadAllText(path);


				dynamic script = CSScript.Evaluator
					.LoadCode<IScript>(code);

				script.Perform(desktopSession);

				bSuccess = true;
			}
			finally
			{
				Assert.AreEqual(bSuccess, true);
			}
		}
	}

    public interface IScript
    {
       public void Perform(DesktopSession desktopSession);
    }

    public class DesktopSession
	{
		WindowsDriver<WindowsElement> desktopSession;

		public DesktopSession(string uri)
		{
			var options = new AppiumOptions();
			options.AddAdditionalCapability("app", "Root");
			options.AddAdditionalCapability("deviceName", "WindowsPC");
			desktopSession = new WindowsDriver<WindowsElement>(new Uri(uri), options);
			desktopSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
		}

		~DesktopSession()
		{
			desktopSession.Quit();
		}

		public WindowsDriver<WindowsElement> DesktopSessionElement
		{
			get { return desktopSession; }
		}

		public WindowsElement FindElementByAbsoluteXPath(string xPath, int nTryCount = 10)
		{
			WindowsElement uiTarget = null;

			while (nTryCount-- > 0)
			{
				try
				{
					uiTarget = desktopSession.FindElementByXPath(xPath);
				}
				catch
				{
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
