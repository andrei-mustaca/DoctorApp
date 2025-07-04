using DoctorApp.Application.DTO;
using DoctorApp.Application.Interfaces;
using DoctorApp.Domain.Entities;

namespace DoctorApp.Application.Services;

public class CityService:ICityService
{
    private readonly IRepository<City> _cityRepository;

    public CityService(IRepository<City> cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<BaseResponse> AddCity(CreateCityRequest request)
    {
        await _cityRepository.Add(new City
        {
            Id=Guid.NewGuid(),
            Name=request.Name
        });
        await _cityRepository.SaveChanges();
        return new BaseResponse("Город успешно добавлен",true);
    }

    public async Task<BaseResponse> UpdateCity(UpdateCityRequest request)
    {
        var city = await _cityRepository.GetById(request.Id);
        if (city == null)
            return new BaseResponse("Город не найден",false);
        city.Name = request.Name;
        _cityRepository.Update(city);
        await _cityRepository.SaveChanges();
        return new BaseResponse("Название города успешно обновлено",true);
    }

    public async Task<BaseResponse> DeleteCity(DeleteCityRequest request)
    {
        var city = await _cityRepository.GetById(request.Id);
        if (city == null)
            return new BaseResponse("Город не найден",false);
        _cityRepository.Delete(city);
        await _cityRepository.SaveChanges();
        return new BaseResponse("город успешно удален",true);
    }
}