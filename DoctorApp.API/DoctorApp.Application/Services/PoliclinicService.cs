using DoctorApp.Application.DTO;
using DoctorApp.Application.Interfaces;
using DoctorApp.Domain.Entities;

namespace DoctorApp.Application.Services;

public class PoliclinicService:IPoliclinicService
{
    private readonly IRepository<Policlinic> _policlinicRepository;
    private readonly IRepository<City> _cityRepository;

    public PoliclinicService(IRepository<Policlinic> policlinicRepository,IRepository<City> cityRepository)
    {
        _policlinicRepository = policlinicRepository;
        _cityRepository = cityRepository;
    }


    public async Task<BaseResponse> AddPoliclinic(CreatePoliclinicRequest request)
    {
        var cityList = await _cityRepository.GetAll();
        var city = cityList.FirstOrDefault(x=>x.Name==request.Name);
        if (city == null)
            return new BaseResponse("Введенного города не существует",false);
        await _policlinicRepository.Add(new Policlinic
        {
            Id = Guid.NewGuid(),
            Name=request.Name,
            Address = request.Address,
            CityId = city.Id,
            Telephone = request.Telephone,
            Photo = request.Photo
        });
        await _policlinicRepository.SaveChanges();
        return new BaseResponse("Поликлиника успешно добавлена",true);
    }

    public async Task<BaseResponse> UpdatePoliclinic(UpdatePoliclinicRequest request)
    {
        var policlinic =await _policlinicRepository.GetById(request.Id);
        if (policlinic == null)
            return new BaseResponse("Поликлиника не найдена",false);
        policlinic.Name = request.Name;
        policlinic.Address = request.Address;
        policlinic.Telephone = request.Telephone;
        policlinic.Photo = request.Photo;
        _policlinicRepository.Update(policlinic);
        await _policlinicRepository.SaveChanges();
        return new BaseResponse("Данные о поликлинике обновлены",true);
    }

    public async Task<BaseResponse> DeletePoliclinic(DeletePoliclinicRequest request)
    {
        var policlinic = await _policlinicRepository.GetById(request.Id);
        if (policlinic == null)
            return new BaseResponse("Поликлиника не найдена",false);
        _policlinicRepository.Delete(policlinic);
        await _policlinicRepository.SaveChanges();
        return new BaseResponse("Данные о поликлинике удалены",true);
    }
}