using WorkflowCore.Interface;
using WorkflowCore.Models;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using CSScriptLib;
using System.IO;

namespace Steps
{
	public class TestWorkflow : IWorkflow<ExecuteScriptData>
	{
		public string Id => "Test";
		public int Version => 1;

		public void Build(IWorkflowBuilder<ExecuteScriptData> builder)
		{
			builder
				.StartWith<ExecuteScript>()
					.Input(step => step.Script, data => data.Script);
		}
	}

	public class ExecuteScript : StepBody
	{
        public string Script { get; set; }

        public override ExecutionResult Run(IStepExecutionContext context)
		{
			using (var desktopSession = new DesktopSession("http://localhost:4723"))
			{
				Thread.Sleep(2000);

				dynamic script = CSScript.Evaluator
					.LoadCode<IScript>(Script);

				script.Perform(desktopSession);
			}

			return ExecutionResult.Next();
		}
	}

	public class ExecuteScriptData
	{
        public string Script => File.ReadAllText(@"D:\Script.cs");
	}

	public interface IScript
	{
		public void Perform(DesktopSession desktopSession);
	}

	public class DesktopSession : IDisposable
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

		public WindowsDriver<WindowsElement> DesktopSessionElement
		{
			get { return desktopSession; }
		}

		public void Dispose()
		{
			desktopSession.Quit();
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
