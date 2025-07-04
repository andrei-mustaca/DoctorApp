using DoctorApp.Application.DTO;

namespace DoctorApp.Application.Interfaces;

public interface IDoctorService
{
    Task<BaseResponse> AddDoctor(CreateDoctorRequest request);
    Task<BaseResponse> UpdateDoctor(UpdateDoctorRequest request);
    Task<BaseResponse> DeleteDoctor(DeleteDoctorRequest request);
}