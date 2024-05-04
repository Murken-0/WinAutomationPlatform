using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using CSScriptLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Template
{
	class Program
	{
		static void Main(string[] args)
		{
			DesktopSession desktopSession = new DesktopSession("http://localhost:4723");
			Thread.Sleep(2000);

			bool bSuccess = false;

			var path = @"D:\Script.cs";

			try
			{

				// LeftClick on ListItem "Blank document" at (105,64)
				Console.WriteLine("LeftClick on ListItem \"Blank document\" at (105,64)");
				string xpath_LeftClickListItemBlankdocum_105_64 = "/Pane[@ClassName=\"#32769\"][@Name=\"Desktop 1\"]/Window[@ClassName=\"OpusApp\"][@Name=\"Word\"]/Pane[@ClassName=\"FullpageUIHost\"]/Pane[@ClassName=\"NetUIFullpageUIWindow\"]/Pane[@Name=\"Backstage view\"][@AutomationId=\"BackstageView\"]/Group[@Name=\"Home\"][@AutomationId=\"PlaceTabHomeContent\"]/Group[@Name=\"New\"][@AutomationId=\"HomePageSlabCreateNew\"]/List[@ClassName=\"NetUIListView\"]/ListItem[@ClassName=\"NetUIListViewItem\"][@Name=\"Blank document\"]";
				var winElem_LeftClickListItemBlankdocum_105_64 = desktopSession.FindElementByAbsoluteXPath(xpath_LeftClickListItemBlankdocum_105_64);
				if (winElem_LeftClickListItemBlankdocum_105_64 != null)
				{
					winElem_LeftClickListItemBlankdocum_105_64.Click();
				}
				else
				{
					Console.WriteLine("Failed to find element using xpath: " + xpath_LeftClickListItemBlankdocum_105_64);
					return;
				}


				// LeftClick on Button "Center" at (15,11)
				Console.WriteLine("LeftClick on Button \"Center\" at (15,11)");
				string xpath_LeftClickButtonCenter_15_11 = "/Pane[@ClassName=\"#32769\"][@Name=\"Desktop 1\"]/Window[@ClassName=\"OpusApp\"][@Name=\"Document1 - Word\"]/Pane[@ClassName=\"MsoCommandBarDock\"][@Name=\"MsoDockTop\"]/ToolBar[@ClassName=\"MsoCommandBar\"]/Pane[@ClassName=\"MsoWorkPane\"][@Name=\"Ribbon\"]/Pane[@ClassName=\"NUIPane\"]/Pane[@ClassName=\"NetUIHWNDElement\"]/Pane[@ClassName=\"NetUInetpane\"][@Name=\"Ribbon\"]/Pane[@ClassName=\"NetUIPanViewer\"][@Name=\"Lower Ribbon\"]/Group[@ClassName=\"NetUIOrderedGroup\"][@Name=\"Home\"]/Group[@ClassName=\"NetUIChunk\"][@Name=\"Paragraph\"]/Button[@Name=\"Center\"][@AutomationId=\"AlignCenter\"]";
				var winElem_LeftClickButtonCenter_15_11 = desktopSession.FindElementByAbsoluteXPath(xpath_LeftClickButtonCenter_15_11);
				if (winElem_LeftClickButtonCenter_15_11 != null)
				{
					winElem_LeftClickButtonCenter_15_11.Click();
				}
				else
				{
					Console.WriteLine("Failed to find element using xpath: " + xpath_LeftClickButtonCenter_15_11);
					return;
				}


				// LeftClick on Edit "Page 1 content" at (560,20)
				Console.WriteLine("LeftClick on Edit \"Page 1 content\" at (560,20)");
				string xpath_LeftClickEditPage1conte_560_20 = "/Pane[@ClassName=\"#32769\"][@Name=\"Desktop 1\"]/Window[@ClassName=\"OpusApp\"][@Name=\"Document1 - Word\"]/Pane[@ClassName=\"_WwF\"]/Pane[@ClassName=\"_WwB\"][@Name=\"Document1\"]/Document[@ClassName=\"_WwG\"][@Name=\"Document1\"]/Custom[@Name=\"Page 1\"][starts-with(@AutomationId,\"UIA_AutomationId_Word_Page_\")]/Edit[@Name=\"Page 1 content\"][@AutomationId=\"Body\"]";
				var winElem_LeftClickEditPage1conte_560_20 = desktopSession.FindElementByAbsoluteXPath(xpath_LeftClickEditPage1conte_560_20);
				if (winElem_LeftClickEditPage1conte_560_20 != null)
				{
					winElem_LeftClickEditPage1conte_560_20.Click();
				}
				else
				{
					Console.WriteLine("Failed to find element using xpath: " + xpath_LeftClickEditPage1conte_560_20);
					return;
				}


				// KeyboardInput VirtualKeys=""ufufufufuf"Keys.Return + Keys.ReturnKeys.LeftControl + "s" + Keys.LeftControl" CapsLock=False NumLock=True ScrollLock=False
				Console.WriteLine("KeyboardInput VirtualKeys=\"\"ufufufufuf\"Keys.Return + Keys.ReturnKeys.LeftControl + \"s\" + Keys.LeftControl\" CapsLock=False NumLock=True ScrollLock=False");
				System.Threading.Thread.Sleep(100);
				new Actions(desktopSession.DesktopSessionElement)
					.SendKeys("abc")
					.SendKeys(Keys.Return + Keys.Return)
					.SendKeys(Keys.LeftControl + "s" + Keys.LeftControl)
					.Perform();


				// LeftClick on ComboBox "Choose a Location" at (211,22)
				Console.WriteLine("LeftClick on ComboBox \"Choose a Location\" at (211,22)");
				string xpath_LeftClickComboBoxChooseaLoc_211_22 = "/Pane[@ClassName=\"#32769\"][@Name=\"Desktop 1\"]/Window[@ClassName=\"OpusApp\"][@Name=\"Document1 - Word\"]/Window[@ClassName=\"NUIDialog\"]/Pane[@ClassName=\"NetUIHWNDElement\"]/Window[@ClassName=\"NetUINetUIDialog\"][@Name=\"Save this file\"]/Pane[@ClassName=\"NetUIScrollViewer\"]/ComboBox[@ClassName=\"NetUIAnchor\"][@Name=\"Choose a Location\"]";
				var winElem_LeftClickComboBoxChooseaLoc_211_22 = desktopSession.FindElementByAbsoluteXPath(xpath_LeftClickComboBoxChooseaLoc_211_22);
				if (winElem_LeftClickComboBoxChooseaLoc_211_22 != null)
				{
					winElem_LeftClickComboBoxChooseaLoc_211_22.Click();
				}
				else
				{
					Console.WriteLine("Failed to find element using xpath: " + xpath_LeftClickComboBoxChooseaLoc_211_22);
					return;
				}


				// LeftClick on ListItem "Downloads" at (135,21)
				Console.WriteLine("LeftClick on ListItem \"Downloads\" at (135,21)");
				string xpath_LeftClickListItemDownloads_135_21 = "/Pane[@ClassName=\"#32769\"][@Name=\"Desktop 1\"]/Window[@ClassName=\"OpusApp\"][@Name=\"Document1 - Word\"]/Window[@ClassName=\"NUIDialog\"]/Pane[@ClassName=\"NetUIHWNDElement\"]/Window[@ClassName=\"NetUINetUIDialog\"][@Name=\"Save this file\"]/Pane[@ClassName=\"NetUIScrollViewer\"]/ComboBox[@ClassName=\"NetUIAnchor\"][@Name=\"Choose a Location\"]/Custom[@ClassName=\"NetUIDismissBehavior\"]/List[@ClassName=\"NetUIListView\"]/ListItem[@ClassName=\"NetUIListViewItem\"][@Name=\"Downloads\"]";
				var winElem_LeftClickListItemDownloads_135_21 = desktopSession.FindElementByAbsoluteXPath(xpath_LeftClickListItemDownloads_135_21);
				if (winElem_LeftClickListItemDownloads_135_21 != null)
				{
					winElem_LeftClickListItemDownloads_135_21.Click();
				}
				else
				{
					Console.WriteLine("Failed to find element using xpath: " + xpath_LeftClickListItemDownloads_135_21);
					return;
				}


				// LeftClick on Button "Save" at (27,4)
				Console.WriteLine("LeftClick on Button \"Save\" at (27,4)");
				string xpath_LeftClickButtonSave_27_4 = "/Pane[@ClassName=\"#32769\"][@Name=\"Desktop 1\"]/Window[@ClassName=\"OpusApp\"][@Name=\"Document1 - Word\"]/Window[@ClassName=\"NUIDialog\"]/Pane[@ClassName=\"NetUIHWNDElement\"]/Window[@ClassName=\"NetUINetUIDialog\"][@Name=\"Save this file\"]/Pane[@ClassName=\"NetUIScrollViewer\"]/Button[@ClassName=\"NetUIButton\"][@Name=\"Save\"]";
				var winElem_LeftClickButtonSave_27_4 = desktopSession.FindElementByAbsoluteXPath(xpath_LeftClickButtonSave_27_4);
				if (winElem_LeftClickButtonSave_27_4 != null)
				{
					winElem_LeftClickButtonSave_27_4.Click();
				}
				else
				{
					Console.WriteLine("Failed to find element using xpath: " + xpath_LeftClickButtonSave_27_4);
					return;
				}













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
				catch(Exception ex)
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
