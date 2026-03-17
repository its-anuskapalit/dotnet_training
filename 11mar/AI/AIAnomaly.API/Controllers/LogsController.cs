using Microsoft.AspNetCore.Mvc;
using AIAnomaly.Application.Interfaces;
using AIAnomaly.Domain.Models;

namespace AIAnomaly.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LogsController : ControllerBase
{
    private readonly ILogService _logService;

    public LogsController(ILogService logService)
    {
        _logService = logService;
    }

    [HttpGet]
    public async Task<IActionResult> GetLogs()
    {
        var logs = await _logService.GetLogsAsync();
        return Ok(logs);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetLog(int id)
    {
        var log = await _logService.GetLogByIdAsync(id);

        if (log == null)
            return NotFound();

        return Ok(log);
    }

    [HttpPost]
    public async Task<IActionResult> AddLog([FromBody] Log log)
    {
        await _logService.AddLogAsync(log);
        return CreatedAtAction(nameof(GetLog), new { id = log.Id }, log);
    }
}