using Microsoft.AspNetCore.Mvc;
using WorkflowCore.Interface;
using Steps;
using WorkflowCore.Services.DefinitionStorage;

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
		public async Task<ActionResult<string>> Execute([FromBody] string workflowYaml)
		{
			var workflow = _loader.LoadDefinition(workflowYaml, Deserializers.Yaml); 

			var result = await _workflowHost.StartWorkflow(
				workflow.Id, 
				workflow.Version, 
				new ExecuteScriptData() { Script = System.IO.File.ReadAllText(@"D:\Script.cs") });

			return Ok(result);
		}
	}
}
