using Application.Interfaces;
using CSScriptLib;

namespace Application.Common.Execution;

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
