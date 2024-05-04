using WorkflowCore.Interface;

namespace Runner.Api.Middleware
{
	public class WorkflowHostMiddleware
	{
		private readonly IWorkflowHost _workflowHost;
		private readonly RequestDelegate _next;

		public WorkflowHostMiddleware(RequestDelegate next, IWorkflowHost host)
		{
			_next = next;
			_workflowHost = host;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			_workflowHost.Start();
			await _next.Invoke(context);
			_workflowHost.Stop();
		}
	}
}
