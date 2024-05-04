using WorkflowCore.Interface;
using WorkflowCore.Models;
using CSScriptLib;
using Steps.Other;

namespace Steps
{
	public class ExecuteScript : StepBody
	{
        public string Script { get; set; }

        public override ExecutionResult Run(IStepExecutionContext context)
		{
			try
			{
				using (var desktopSession = new DesktopSession("http://192.168.0.170:4723"))
				{
					Thread.Sleep(2000);

					dynamic script = CSScript.Evaluator
						.LoadCode<IScript>(Script);

					script.Perform(desktopSession);
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

			return ExecutionResult.Next();
		}
	}

	public class ExecuteScriptData
	{
        public string Script { get; set; }
	}
}
