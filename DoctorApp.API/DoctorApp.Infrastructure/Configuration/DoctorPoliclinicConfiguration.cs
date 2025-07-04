using DoctorApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorApp.Infrastructure.Configuration;

public class DoctorPoliclinicConfiguration:IEntityTypeConfiguration<DoctorPoliclinic>
{
    public void Configure(EntityTypeBuilder<DoctorPoliclinic> builder)
    {
        builder.HasKey(k => new { k.DoctorId, k.PoliclinicId });
        builder.HasOne(x => x.Doctor)
            .WithMany(x => x.DoctorPoliclinics)
            .HasForeignKey(x => x.DoctorId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.Policlinic)
            .WithMany(x => x.DoctorPoliclinics)
            .HasForeignKey(x => x.PoliclinicId)
            .OnDelete(DeleteBehavior.Cascade);
    }    
}