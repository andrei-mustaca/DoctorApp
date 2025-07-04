using DoctorApp.Application.DTO;
using DoctorApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PoliclinicController:ControllerBase
{
    private IPoliclinicService _policlinicService;

    public PoliclinicController(IPoliclinicService policlinicService)
    {
        _policlinicService = policlinicService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePoliclinicRequest request)
    {
        var response = await _policlinicService.AddPoliclinic(request);
        if (!response.Success)
            return BadRequest(response);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdatePoliclinicRequest request)
    {
        var response = await _policlinicService.UpdatePoliclinic(request);
        if (!response.Success)
            return NotFound(response);
        return Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(DeletePoliclinicRequest request)
    {
        var response = await _policlinicService.DeletePoliclinic(request);
        if (!response.Success)
            return NotFound(response);
        return Ok(response);
    }
}