using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Core.Models;
using Core.Common;
using Persistense;
using Microsoft.EntityFrameworkCore;

namespace Web.Backend.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class JobsController : Controller
{
	private readonly DatabaseContext _context;
	private readonly IBackgroundJobClient _backgroundJobs;
	private readonly IRecurringJobManager _recurringJobs;
	private readonly IConfiguration _configuration;

	public JobsController(
		DatabaseContext context,
		IBackgroundJobClient backgroundJobs,
		IRecurringJobManager recurringJobManager,
		IConfiguration configuration)
	{
		_context = context;
		_backgroundJobs = backgroundJobs;
		_recurringJobs = recurringJobManager;
		_configuration = configuration;
	}

	[HttpPost]
	public async Task<ActionResult> Execute(int id)
	{
		var job = await _context.Jobs.FirstOrDefaultAsync(w => w.Id == id);

		if (job == null)
		{
			return NotFound();
		}

		if (job.IsRecurring)
		{
			_recurringJobs.Trigger(job.Name);
		}
		else
		{
			_backgroundJobs.Enqueue<ScriptExecutor>(executor => executor.Execute(
				_context.Workflows.First(w => w.Id == job.WorkflowId).Script,
				_configuration.GetConnectionString("WinAppDriver")));
		}

		return Ok();
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<Job>>> GetAll()
	{
		return await _context.Jobs.ToListAsync();
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<Job>> Get(int id)
	{
		var job = await _context.Jobs.FirstOrDefaultAsync(j => j.Id == id);

		if (job == null)
		{
			return NotFound();
		}

		return job;
	}

	[HttpPost]
	public async Task<ActionResult> Create(Job job)
	{
		_context.Jobs.Add(job);
		await _context.SaveChangesAsync();

		if (job.IsRecurring)
		{
			_recurringJobs.AddOrUpdate<ScriptExecutor>(
				job.Name,
				executor =>
					executor.Execute(
					   _context.Workflows.First(w => w.Id == job.WorkflowId).Script,
					   _configuration.GetConnectionString("WinAppDriver")),
				job.Cron);
		}

		return Ok();
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> Update(int id, Job job)
	{
		if (id != job.Id)
		{
			return NotFound();
		}

		try
		{
			_context.Update(job);
			await _context.SaveChangesAsync();

			if (job.IsRecurring)
			{
				_recurringJobs.AddOrUpdate<ScriptExecutor>(
					job.Name,
					executor =>
						executor.Execute(
						   _context.Workflows.First(w => w.Id == job.WorkflowId).Script,
						   _configuration.GetConnectionString("WinAppDriver")),
					job.Cron);
			}
		}
		catch (DbUpdateConcurrencyException)
		{
			if (!await JobExists(job.Id))
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
		var job = await _context.Jobs.FirstOrDefaultAsync(w => w.Id == id);

		if (job == null)
		{
			return NotFound();
		}

		_context.Jobs.Remove(job);
		await _context.SaveChangesAsync();

		if (job.IsRecurring)
		{
			_recurringJobs.RemoveIfExists(job.Name);
		}

		return Ok();
	}

	private async Task<bool> JobExists(int id)
	{
		return await _context.Jobs.AnyAsync(e => e.Id == id);
	}
}
