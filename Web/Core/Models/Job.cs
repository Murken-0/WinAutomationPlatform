using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models;

public class Job
{
    public int Id { get; set; }
	public string Name { get; set; }
	public string Cron { get; set; }
	public int WorkflowId { get; set; }
	public Workflow Workflow { get; set; }
	public bool IsRecurring => Cron != null;
}
