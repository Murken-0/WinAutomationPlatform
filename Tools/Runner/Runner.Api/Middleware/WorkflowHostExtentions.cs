namespace Runner.Api.Middleware
{
	public static class WorkflowHostExtentions
	{
		public static IApplicationBuilder UseWorkflowHost(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<WorkflowHostMiddleware>();
		}
	}
}
