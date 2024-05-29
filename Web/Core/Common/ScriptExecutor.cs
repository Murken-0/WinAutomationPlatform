using CSScriptLib;
using Microsoft.CodeAnalysis.Scripting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common
{
	public class ScriptExecutor
	{
		public void Execute(string scriptText, string url)
		{
			try
			{
				using (var desktopSession = new DesktopSession(url))
				{
					Thread.Sleep(2000);

					dynamic script = CSScript.Evaluator
						.LoadCode<IScript>(scriptText);

					script.Perform(desktopSession);
				}
			}
			catch (Exception ex)
			{
                Console.WriteLine(ex.Message);
            }
		}
	}
}
