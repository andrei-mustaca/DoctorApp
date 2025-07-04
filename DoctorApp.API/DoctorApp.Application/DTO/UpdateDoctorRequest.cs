namespace DoctorApp.Application.DTO;

public class UpdateDoctorRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Telephone { get; set; }
    public string Photo { get; set; }
    public string ShortDescription { get; set; }
    public string FullDescription { get; set; }
}