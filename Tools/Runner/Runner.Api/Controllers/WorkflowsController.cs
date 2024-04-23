using Microsoft.AspNetCore.Mvc;
using WorkflowCore.Interface;
using Steps;

namespace Runner.Api.Controllers
{
	[ApiController]
	public class WorkflowsController : ControllerBase
	{
		private readonly IDefinitionLoader _loader;
		private readonly IWorkflowHost _workflowHost;

		public WorkflowsController(IDefinitionLoader definitionLoader, IWorkflowHost host)
		{
			_loader = definitionLoader;
			_workflowHost = host;
		}

		[Route("workflows/execute")]
		public ActionResult<string> Execute()//[FromBody] string workflowYaml
		{

			//var workflow = _loader.LoadDefinition(workflowYaml, Deserializers.Yaml);
			_workflowHost.RegisterWorkflow<TestWorkflow, ExecuteScriptData>();
			_workflowHost.Start();
			_workflowHost.StartWorkflow("Test", 1);
			//_workflowHost.Stop();

			return Ok();
		}
	}
}
