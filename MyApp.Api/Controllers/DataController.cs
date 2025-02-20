using Microsoft.AspNetCore.Mvc;
using MyApp.Domain;

namespace MyApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DataController : ControllerBase
{
    private readonly IRepository<DataEntity> _repository;
    public DataController(IRepository<DataEntity> repository) { _repository = repository; }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var data = await _repository.GetAllAsync(); return Ok(data);
    }
}
