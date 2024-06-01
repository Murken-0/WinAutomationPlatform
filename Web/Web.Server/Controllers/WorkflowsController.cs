using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistense;
using Domain;
using Application.Dto.Workflows;

namespace Web.Backend.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class WorkflowsController : ControllerBase
{
	private readonly DatabaseContext _context;

	public WorkflowsController(DatabaseContext context)
	{
		_context = context;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<Workflow>>> GetAll()
	{
		return await _context.Workflows.ToListAsync();
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<Workflow>> Get(int id)
	{
		var workflow = await _context.Workflows.FirstOrDefaultAsync(w => w.Id == id);

		if (workflow == null)
		{
			return NotFound();
		}

		return workflow;
	}

	[HttpPost]
	public async Task<ActionResult<Workflow>> Create(WorkflowCreateDto dto)
	{
		var workflow = new Workflow()
		{
			Name = dto.Name,
			LastEdit = DateTime.UtcNow,
		};

		_context.Workflows.Add(workflow);
		await _context.SaveChangesAsync();

		return Ok();
	}

	[HttpPut("{id}")]
	public async Task<ActionResult> Update(int id, WorkflowUpdateDto dto)
	{
		var workflow = await _context.Workflows.FirstOrDefaultAsync(w => w.Id == id);

		if (workflow.Name != dto.Name || workflow.Script != dto.Script) 
			workflow.LastEdit = DateTime.UtcNow;
		
		workflow.Script = dto.Script;
		workflow.Name = dto.Name;

		_context.Update(workflow);
		await _context.SaveChangesAsync();

		return Ok();
	}

	[HttpDelete("{id}")]
	public async Task<ActionResult> Delete(int id)
	{
		var workflow = await _context.Workflows.FirstOrDefaultAsync(w => w.Id == id);

		if (workflow == null)
		{
			return NotFound();
		}

		_context.Workflows.Remove(workflow);
		await _context.SaveChangesAsync();

		return Ok();
	}

	private async Task<bool> WorkflowExists(int? id)
	{
		return await _context.Workflows.AnyAsync(e => e.Id == id);
	}
}
