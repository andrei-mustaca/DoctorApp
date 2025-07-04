using DoctorApp.Application.DTO;
using DoctorApp.Application.Interfaces;
using DoctorApp.Domain.Entities;

namespace DoctorApp.Application.Services;

public class DoctorService:IDoctorService
{
    private readonly IRepository<Doctor> _doctorRepository;
    private readonly IRepository<DoctorPoliclinic> _doctorPoliclinicRepository;
    private readonly IRepository<DoctorSpecialization> _doctorSpecializationRepository;
    private readonly IRepository<Specialization> _specializationRepository;
    private readonly IRepository<Policlinic> _policlinicRepository;

    public DoctorService(IRepository<Doctor> doctorRepository,IRepository<DoctorPoliclinic> doctorPoliclinicRepository,
        IRepository<DoctorSpecialization> doctorSpecializationRepository,IRepository<Specialization> specializationRepository,IRepository<Policlinic> policlinicRepository)
    {
        _doctorRepository = doctorRepository;
        _doctorPoliclinicRepository = doctorPoliclinicRepository;
        _doctorSpecializationRepository = doctorSpecializationRepository;
        _specializationRepository = specializationRepository;
        _policlinicRepository = policlinicRepository;
    }
    public async Task<BaseResponse> AddDoctor(CreateDoctorRequest request)
    {
        var policlinics = await _policlinicRepository.GetAll();
        List<Guid> idPoliclinic = new List<Guid>();
        foreach (var elem in request.DoctorPoliclinicRequests)
        {
            foreach (var policlinic in policlinics)
            {
                if(policlinic.Name==elem.PoliclinicName)
                    idPoliclinic.Add(policlinic.Id);
            }
        }
        if (idPoliclinic.Count!=request.DoctorPoliclinicRequests.Count)
            return new BaseResponse("Одна или несколько поликлиник неверно указаны",false);

        var specializations = await _specializationRepository.GetAll();
        List<Guid> idSpecialization = new List<Guid>();
        foreach (var elem in request.DoctorSpecializationRequests)
        {
            foreach (var specialization in specializations)
            {
                if(specialization.Name==elem.Specialization)
                    idSpecialization.Add(specialization.Id);
            }
        }
        if (idSpecialization.Count!=request.DoctorSpecializationRequests.Count)
            return new BaseResponse("Одна или несколько указанных специализаций не найдено",false);

        var doctor = new Doctor
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Telephone = request.Telephone,
            Photo = request.Photo,
            ShortDescription = request.ShortDescription,
            FullDescription = request.FullDescription
        };
        await _doctorRepository.Add(doctor);

        for (int i = 0; i < request.DoctorSpecializationRequests.Count; i++)
        {
            await _doctorSpecializationRepository.Add(new DoctorSpecialization
            {
                DoctorId = doctor.Id,
                SpecializationId = idSpecialization[i],
                ExperienceSpecialization = request.DoctorSpecializationRequests[i].Experience
            });
        }

        for (int i = 0; i < request.DoctorPoliclinicRequests.Count; i++)
        {
            await _doctorPoliclinicRepository.Add(new DoctorPoliclinic
            {
                DoctorId = doctor.Id,
                PoliclinicId = idPoliclinic[i],
                Price = request.DoctorPoliclinicRequests[i].Price
            });
        }

        await _doctorRepository.SaveChanges();
        return new BaseResponse("Информация о докторе успешно добавлена",true);
    }

    public async Task<BaseResponse> UpdateDoctor(UpdateDoctorRequest request)
    {
        var doctor = await _doctorRepository.GetById(request.Id);
        if (doctor == null)
            return new BaseResponse("Доктор не найден",false);
        doctor.Name = request.Name;
        doctor.Telephone = request.Telephone;
        doctor.Photo = request.Photo;
        doctor.ShortDescription = request.ShortDescription;
        doctor.FullDescription = request.FullDescription;
        
        _doctorRepository.Update(doctor);
        await _doctorRepository.SaveChanges();
        return new BaseResponse("Данные о докторе успешно обновлены",true);
    }

    public async Task<BaseResponse> DeleteDoctor(DeleteDoctorRequest request)
    {
        var doctor = await _doctorRepository.GetById(request.Id);
        if (doctor == null)
            return new BaseResponse("Доктор не найден", false);

        _doctorRepository.Delete(doctor);
        await _doctorRepository.SaveChanges();
        return new BaseResponse("Информация о враче успешно удалена",true);
    }
}