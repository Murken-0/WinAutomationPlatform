using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models;

public class Workflow
{
    public int Id { get; set; }
	public string Name { get; set; }
	public int Version { get; set; }
	public DateTime LastEdit { get; set; }
	public string Script { get; set; }
}
