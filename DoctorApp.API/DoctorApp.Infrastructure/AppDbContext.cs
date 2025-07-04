using DoctorApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoctorApp.Infrastructure;

public class AppDbContext:DbContext
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Policlinic> Policlinics { get; set; }
    public DbSet<Specialization> Specializations { get; set; }
    public DbSet<DoctorPoliclinic> DoctorPoliclinics { get; set; }
    public DbSet<DoctorSpecialization> DoctorSpecializations { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}