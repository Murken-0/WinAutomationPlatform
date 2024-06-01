namespace Application.Dto.Jobs;

public class JobDto
{
	public string Name { get; set; }
	public string Cron { get; set; }
	public int WorkflowId { get; set; }
}
