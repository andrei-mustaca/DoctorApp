namespace DoctorApp.Domain.Entities;

public class DoctorSpecialization
{
    public Guid DoctorId { get; set; }
    public Guid SpecializationId { get; set; }
    public int ExperienceSpecialization { get; set; }
    
    public Doctor Doctor { get; set; }
    public Specialization Specialization { get; set; }
}