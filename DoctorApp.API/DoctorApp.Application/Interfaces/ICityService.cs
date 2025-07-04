using DoctorApp.Application.DTO;

namespace DoctorApp.Application.Interfaces;

public interface ICityService
{
    Task<BaseResponse> AddCity(CreateCityRequest request);
    Task<BaseResponse> UpdateCity(UpdateCityRequest request);
    Task<BaseResponse> DeleteCity(DeleteCityRequest request);
}