namespace DoctorApp.Domain.Entities;

public class Specialization
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public List<DoctorSpecialization> DoctorSpecializations { get; set; }
}