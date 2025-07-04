using DoctorApp.Application.DTO;
using DoctorApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CityController:ControllerBase
{
    private ICityService _cityService;

    public CityController(ICityService cityService)
    {
        _cityService = cityService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCityRequest request)
    {
        var response = await _cityService.AddCity(request);
        if (!response.Success)
            return BadRequest(response);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCityRequest request)
    {
        var response = await _cityService.UpdateCity(request);
        if (!response.Success)
            return NotFound(response);
        return Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteCityRequest request)
    {
        var response = await _cityService.DeleteCity(request);
        if (!response.Success)
            return NotFound(response);
        return Ok(response);
    }
}