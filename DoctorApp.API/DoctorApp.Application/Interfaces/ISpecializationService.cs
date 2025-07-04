using DoctorApp.Application.DTO;

namespace DoctorApp.Application.Interfaces;

public interface ISpecializationService
{
    Task<BaseResponse> AddSpecialization(CreateSpecializationRequest request);
    Task<BaseResponse> UpdateSpecialization(UpdateSpecializationRequest request);
    Task<BaseResponse> DeleteSpecialization(DeleteSpecializationRequest request);
}