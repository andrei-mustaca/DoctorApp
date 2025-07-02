namespace DoctorApp.Domain.Entities;

public class Policlinic
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Telephone { get; set; }
    public string Photo { get; set; }
    public Guid CityId { get; set; }
    
    public City City { get; set; }
    public List<DoctorPoliclinic> DoctorPoliclinics { get; set; }
}