namespace DoctorApp.Domain.Entities;

public class Doctor
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Telephone { get; set; }
    public string Photo { get; set; }
    public int Experience { get; set; }
    public string ShortDescription { get; set; }
    public string FullDescription { get; set; }
    
    public List<DoctorPoliclinic> DoctorPoliclinics { get; set; }
    public List<DoctorSpecialization> DoctorSpecializations { get; set; }
}