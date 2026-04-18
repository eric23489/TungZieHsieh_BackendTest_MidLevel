using Microsoft.AspNetCore.Mvc;
using TungZieHsieh_BackendTest_MiLevel.Models;
using TungZieHsieh_BackendTest_MiLevel.Repositories;

namespace TungZieHsieh_BackendTest_MiLevel.Controllers;

[ApiController]
[Route("api/myofficeacpd")]
public class MyOfficeAcpdController : ControllerBase
{
    private readonly IMyOfficeAcpdRepository _repo;

    public MyOfficeAcpdController(IMyOfficeAcpdRepository repo)
    {
        _repo = repo;
    }

    // GET api/myofficeacpd
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _repo.GetAllAsync();
        return Ok(data);
    }

    // GET api/myofficeacpd/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var data = await _repo.GetByIdAsync(id);
        if (data == null) return NotFound(new { message = $"找不到 SID={id} 的資料" });
        return Ok(data);
    }

    // POST api/myofficeacpd
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AcpdCreateDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var newSid = await _repo.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = newSid }, new { ACPD_SID = newSid });
    }

    // PUT api/myofficeacpd/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] AcpdUpdateDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var success = await _repo.UpdateAsync(id, dto);
        if (!success) return NotFound(new { message = $"找不到 SID={id} 的資料" });
        return NoContent();
    }

    // DELETE api/myofficeacpd/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var success = await _repo.DeleteAsync(id);
        if (!success) return NotFound(new { message = $"找不到 SID={id} 的資料" });
        return NoContent();
    }
}
