using DoctorApp.Application.DTO;
using DoctorApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorApp.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class DoctorController:ControllerBase
{
    private IDoctorService _doctorService;

    public DoctorController(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDoctorRequest request)
    {
        var response = await _doctorService.AddDoctor(request);
        if (!response.Success)
            return BadRequest(response);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateDoctorRequest request)
    {
        var response = await _doctorService.UpdateDoctor(request);
        if (!response.Success)
            return NotFound(response);
        return Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteDoctorRequest request)
    {
        var response = await _doctorService.DeleteDoctor(request);
        if (!response.Success)
            return NotFound(response);
        return Ok(response);
    }
}