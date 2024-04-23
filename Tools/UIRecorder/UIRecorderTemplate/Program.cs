﻿using System;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSScriptLibrary;
using System.IO;

namespace UIRecorderTemplate
{
	class Program
	{
		static void Main(string[] args)
		{
			DesktopSession desktopSession = new DesktopSession("http://localhost:4723/");
			System.Threading.Thread.Sleep(2000);

			bool bSuccess = false;

			var path = @"D:\Script.txt";

			try
			{
				var code = File.ReadAllText(path);

				dynamic script = CSScript.Evaluator
					.ReferenceDomainAssemblies()
					.LoadMethod(code);
				script.Perform(desktopSession);

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
