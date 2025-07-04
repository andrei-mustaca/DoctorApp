using DoctorApp.Application.DTO;

namespace DoctorApp.Application.Interfaces;

public interface IPoliclinicService
{
    Task<BaseResponse> AddPoliclinic(CreatePoliclinicRequest request);
    Task<BaseResponse> UpdatePoliclinic(UpdatePoliclinicRequest request);
    Task<BaseResponse> DeletePoliclinic(DeletePoliclinicRequest request);
}