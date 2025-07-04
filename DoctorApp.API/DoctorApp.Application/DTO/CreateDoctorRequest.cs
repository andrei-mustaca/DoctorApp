using System.ComponentModel.DataAnnotations;
namespace DoctorApp.Application.DTO;

public class CreateDoctorRequest
{
    public string Name { get; set; }
    public string Telephone { get; set; }
    public string Photo { get; set; }
    public string ShortDescription { get; set; }
    public string FullDescription { get; set; }
    public List<DoctorPoliclinicRequest> DoctorPoliclinicRequests { get; set; }
    public List<DoctorSpecializationRequest> DoctorSpecializationRequests { get; set; }
}

public class DoctorPoliclinicRequest
{
    public string PoliclinicName { get; set; }
    [Range(100,1000,ErrorMessage = "Цена должна быть от 100 до 1000")]
    public decimal Price { get; set; }
}

public class DoctorSpecializationRequest
{
    public string Specialization { get; set; }
    [Range(1,40,ErrorMessage = "Опыт должен быть от 1 года до 40 лет")]
    public int Experience { get; set; }
}