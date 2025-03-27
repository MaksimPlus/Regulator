using Microsoft.AspNetCore.Mvc;
using Regulator.API.Implementations;
using Regulator.API.Models;

namespace Regulator.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OperationController : ControllerBase
{
    private readonly CalculateService _calculateService;
    public OperationController(CalculateService calculateService)
    {
        _calculateService = calculateService;
    }
    [HttpPost]
    public double Calculate(double a, double b)
    {
        return _calculateService.CalculateSum(a, b);
    }
    [HttpGet]
    public ActionResult<IReadOnlyList<OperationLog>> GetLogOperations()
    {
        var logs = _calculateService.GetOperationLogs();
        return Ok(logs);
    }
}
