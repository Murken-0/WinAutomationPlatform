using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistense;
using Core.Models;

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
	public async Task<ActionResult<Workflow>> Create(Workflow workflow)
	{
		_context.Workflows.Add(workflow);
		await _context.SaveChangesAsync();

		return CreatedAtAction(nameof(Get), new { id = workflow.Id }, workflow);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> Update(int id, Workflow workflow)
	{
		if (id != workflow.Id)
		{
			return NotFound();
		}

		try
		{
			_context.Update(workflow);
			await _context.SaveChangesAsync();
		}
		catch (DbUpdateConcurrencyException)
		{
			if (!await WorkflowExists(workflow.Id))
			{
				return NotFound();
			}
			else
			{
				throw;
			}
		}

		return Ok();
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(int id)
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
