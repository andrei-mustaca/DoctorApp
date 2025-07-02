namespace DoctorApp.Domain.Entities;

public class DoctorPoliclinic
{
    public Guid DoctorId { get; set; }
    public Guid PoliclinicId { get; set; }
    public decimal Price { get; set; }
    
    public Doctor Doctor { get; set; }
    public Policlinic Policlinic { get; set; }
}