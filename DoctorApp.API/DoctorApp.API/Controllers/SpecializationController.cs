using DoctorApp.Application.DTO;
using DoctorApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SpecializationController:ControllerBase
{
    private ISpecializationService _specializationService;

    public SpecializationController(ISpecializationService specializationService)
    {
        _specializationService = specializationService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSpecializationRequest request)
    {
        var response = await _specializationService.AddSpecialization(request);
        if (!response.Success)
            return BadRequest(response);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateSpecializationRequest request)
    {
        var response = await _specializationService.UpdateSpecialization(request);
        if (!response.Success)
            return NotFound(response);
        return Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteSpecializationRequest request)
    {
        var response = await _specializationService.DeleteSpecialization(request);
        if (!response.Success)
            return NotFound(response);
        return Ok(response);
    }
}