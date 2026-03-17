using Microsoft.AspNetCore.Mvc;
using AIAnomaly.Infrastructure.Repositories;

namespace AIAnomaly.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnomaliesController : ControllerBase
{
    private readonly IAnomalyRepository _repository;

    public AnomaliesController(IAnomalyRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAnomalies()
    {
        var anomalies = await _repository.GetAllAnomaliesAsync();
        return Ok(anomalies);
    }
}