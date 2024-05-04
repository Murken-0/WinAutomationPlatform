using System;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSScriptLibrary;
using System.IO;
using OpenQA.Selenium;

namespace UIRecorderTemplate
{
	class Program
	{
		static void Main(string[] args)
		{
			DesktopSession desktopSession = new DesktopSession("http://192.168.0.5:4723/");
			System.Threading.Thread.Sleep(2000);

			bool bSuccess = false;

			try
			{
				// RightClick on List "" at (2708,499)
				Console.WriteLine("RightClick on List \"\" at (2708,499)");
				string xpath_RightClickList_2708_499 = "/Pane[@ClassName=\"#32769\"][@Name=\"Desktop 1\"]/List[@ClassName=\"SysListView32\"]";
				var winElem_RightClickList_2708_499 = desktopSession.FindElementByAbsoluteXPath(xpath_RightClickList_2708_499);
				if (winElem_RightClickList_2708_499 != null)
				{
					desktopSession.DesktopSessionElement.Mouse.MouseMove(winElem_RightClickList_2708_499.Coordinates);
					desktopSession.DesktopSessionElement.Mouse.ContextClick(null);
				}
				else
				{
					Console.WriteLine("Failed to find element using xpath: " + xpath_RightClickList_2708_499);
					return;
				}


				// LeftClick on MenuItem "New" at (163,25)
				Console.WriteLine("LeftClick on MenuItem \"New\" at (163,25)");
				string xpath_LeftClickMenuItemNew_163_25 = "/Pane[@ClassName=\"#32769\"][@Name=\"Desktop 1\"]/Pane[@ClassName=\"Microsoft.UI.Content.PopupWindowSiteBridge\"][@Name=\"PopupHost\"]/Window[@Name=\"Popup\"][@AutomationId=\"OverflowPopup\"]/MenuItem[@Name=\"New\"][@AutomationId=\"New\"]";
				var winElem_LeftClickMenuItemNew_163_25 = desktopSession.FindElementByAbsoluteXPath(xpath_LeftClickMenuItemNew_163_25);
				if (winElem_LeftClickMenuItemNew_163_25 != null)
				{
					winElem_LeftClickMenuItemNew_163_25.Click();
				}
				else
				{
					Console.WriteLine("Failed to find element using xpath: " + xpath_LeftClickMenuItemNew_163_25);
					return;
				}


				// LeftClick on Text "Folder" at (8,9)
				Console.WriteLine("LeftClick on Text \"Folder\" at (8,9)");
				string xpath_LeftClickTextFolder_8_9 = "/Pane[@ClassName=\"#32769\"][@Name=\"Desktop 1\"]/Pane[@ClassName=\"Microsoft.UI.Content.PopupWindowSiteBridge\"][@Name=\"PopupHost\"]/Window[@ClassName=\"Popup\"][@Name=\"Popup\"]/Menu[@ClassName=\"MenuFlyout\"]/MenuItem[@ClassName=\"MenuFlyoutItem\"][@Name=\"Folder\"]/Text[@Name=\"Folder\"][@AutomationId=\"TextBlock\"]";
				var winElem_LeftClickTextFolder_8_9 = desktopSession.FindElementByAbsoluteXPath(xpath_LeftClickTextFolder_8_9);
				if (winElem_LeftClickTextFolder_8_9 != null)
				{
					winElem_LeftClickTextFolder_8_9.Click();
				}
				else
				{
					Console.WriteLine("Failed to find element using xpath: " + xpath_LeftClickTextFolder_8_9);
					return;
				}


				// KeyboardInput VirtualKeys="Keys.LeftShift + "s" + Keys.LeftShift"oska"Keys.Return + Keys.Return" CapsLock=False NumLock=True ScrollLock=False
				Console.WriteLine("KeyboardInput VirtualKeys=\"Keys.LeftShift + \"s\" + Keys.LeftShift\"oska\"Keys.Return + Keys.Return\" CapsLock=False NumLock=True ScrollLock=False");
				System.Threading.Thread.Sleep(100);
				winElem_LeftClickTextFolder_8_9.SendKeys(Keys.LeftShift + "s" + Keys.LeftShift);
				winElem_LeftClickTextFolder_8_9.SendKeys("oska");
				winElem_LeftClickTextFolder_8_9.SendKeys(Keys.Return + Keys.Return);



				bSuccess = true;
			}
			finally
			{
				Assert.AreEqual(bSuccess, true);
			}
		}
	}

	public class DesktopSession
	{
		WindowsDriver<WindowsElement> desktopSession;

		public DesktopSession(string uri)
		{
			DesiredCapabilities appCapabilities = new DesiredCapabilities();
			appCapabilities.SetCapability("app", "Root");
			appCapabilities.SetCapability("deviceName", "WindowsPC");
			desktopSession = new WindowsDriver<WindowsElement>(new Uri(uri), appCapabilities);
			desktopSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(200);
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
					System.Threading.Thread.Sleep(2000);
				}
			}

			return uiTarget;
		}
	}
}
