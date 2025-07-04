using DoctorApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorApp.Infrastructure.Configuration;

public class DoctorSpecializationConfiguration:IEntityTypeConfiguration<DoctorSpecialization>
{
    public void Configure(EntityTypeBuilder<DoctorSpecialization> builder)
    {
        builder.HasKey(k=>new {k.DoctorId,k.SpecializationId});
        builder.HasOne(x => x.Doctor)
            .WithMany(x => x.DoctorSpecializations)
            .HasForeignKey(x => x.DoctorId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.Specialization)
            .WithMany(x => x.DoctorSpecializations)
            .HasForeignKey(x => x.SpecializationId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}