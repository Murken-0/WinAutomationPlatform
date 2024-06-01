using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Domain;
using Persistense;
using Microsoft.EntityFrameworkCore;
using Application.Dto.Jobs;
using Application.Common.Execution;

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

	[HttpGet]
	public async Task<ActionResult<IEnumerable<Job>>> GetAll()
	{
		return await _context.Jobs.Include(j => j.Workflow).ToListAsync();
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<Job>> Get(int id)
	{
		var job = await _context.Jobs.Include(j => j.Workflow).FirstOrDefaultAsync(j => j.Id == id);

		if (job == null)
		{
			return NotFound();
		}

		return job;
	}

	[HttpPost]
	public async Task<ActionResult> Create(JobDto dto)
	{
		var job = new Job()
		{
			Name = dto.Name,
			Cron = dto.Cron,
			WorkflowId = dto.WorkflowId,
		};

		_context.Jobs.Add(job);
		await _context.SaveChangesAsync();

		if (job.IsRecurring)
		{
			_recurringJobs.AddOrUpdate<ScriptExecutor>(
				job.Id.ToString(),
				executor =>
					executor.Execute(
					   _context.Workflows.First(w => w.Id == job.WorkflowId).Script,
					   _configuration.GetConnectionString("WinAppDriver")),
				job.Cron);
		}

		return Ok();
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> Update(int id, JobDto dto)
	{
		var job = await _context.Jobs.Include(j => j.Workflow).FirstOrDefaultAsync(j => j.Id == id);
		
		if (job == null) return NotFound();

		job.Name = dto.Name;
		job.Cron = dto.Cron;
		job.WorkflowId = dto.WorkflowId;

		_context.Update(job);
		await _context.SaveChangesAsync();

		if (job.IsRecurring)
		{
			_recurringJobs.AddOrUpdate<ScriptExecutor>(
				job.Id.ToString(),
				executor =>
					executor.Execute(
						job.Workflow.Script,
						_configuration.GetConnectionString("WinAppDriver")),
				job.Cron);
		}
		else
		{
			_recurringJobs.RemoveIfExists(job.Name);
		}
		
		return Ok();
	}


	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(int id)
	{
		var job = await _context.Jobs.FirstOrDefaultAsync(w => w.Id == id);

		if (job == null) return NotFound();

		_context.Jobs.Remove(job);
		await _context.SaveChangesAsync();

		if (job.IsRecurring)
		{
			_recurringJobs.RemoveIfExists(job.Id.ToString());
		}

		return Ok();
	}

	[HttpPost("{id}")]
	public async Task<ActionResult> Execute(int id)
	{
		var job = await _context.Jobs.Include(j => j.Workflow).FirstOrDefaultAsync(w => w.Id == id);

		if (job == null) return NotFound();

		if (job.IsRecurring)
		{
			_recurringJobs.Trigger(job.Id.ToString());
		}
		else
		{
			_backgroundJobs.Enqueue<ScriptExecutor>(executor => executor.Execute(
				job.Workflow.Script,
				_configuration.GetConnectionString("WinAppDriver")));
		}

		return Ok();
	}
}
