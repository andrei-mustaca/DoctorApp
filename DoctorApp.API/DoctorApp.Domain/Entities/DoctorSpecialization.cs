namespace DoctorApp.Domain.Entities;

public class DoctorSpecialization
{
    public Guid DoctorId { get; set; }
    public Guid SpecializationId { get; set; }
    
    public Doctor Doctor { get; set; }
    public Policlinic Policlinic { get; set; }
}