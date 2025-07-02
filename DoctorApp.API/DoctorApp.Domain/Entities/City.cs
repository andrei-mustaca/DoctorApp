namespace DoctorApp.Domain.Entities;

public class City
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public List<Policlinic> Policlinics { get; set; }
}