namespace DoctorApp.Application.DTO;

public class UpdatePoliclinicRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Telephone { get; set; }
    public string Photo { get; set; }
}