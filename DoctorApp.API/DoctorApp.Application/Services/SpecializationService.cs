using DoctorApp.Application.DTO;
using DoctorApp.Application.Interfaces;
using DoctorApp.Domain.Entities;

namespace DoctorApp.Application.Services;

public class SpecializationService:ISpecializationService
{
    private readonly IRepository<Specialization> _specializationRepository;

    public SpecializationService(IRepository<Specialization> specializationRepository)
    {
        _specializationRepository =specializationRepository ;
    }

    public async Task<BaseResponse> AddSpecialization(CreateSpecializationRequest request)
    {
        await _specializationRepository.Add(new Specialization
        {
            Id=Guid.NewGuid(),
            Name=request.Name
        });
        await _specializationRepository.SaveChanges();
        return new BaseResponse("Специализация успешно добавлена",true);
    }

    public async Task<BaseResponse> UpdateSpecialization(UpdateSpecializationRequest request)
    {
        var specialization = await _specializationRepository.GetById(request.Id);
        if (specialization == null)
            return new BaseResponse("Специализация не найдена",false);
        specialization.Name = request.Name;
        _specializationRepository.Update(specialization);
        await _specializationRepository.SaveChanges();
        return new BaseResponse("Название специализации успешно обновлено",true);
    }

    public async Task<BaseResponse> DeleteSpecialization(DeleteSpecializationRequest request)
    {
        var specialization = await _specializationRepository.GetById(request.Id);
        if (specialization == null)
            return new BaseResponse("Специализация не найдена",false);
        _specializationRepository.Delete(specialization);
        await _specializationRepository.SaveChanges();
        return new BaseResponse("город успешно удален",true);
    }
}