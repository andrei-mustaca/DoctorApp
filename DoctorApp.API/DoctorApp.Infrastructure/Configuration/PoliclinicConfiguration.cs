using DoctorApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorApp.Infrastructure.Configuration;

public class PoliclinicConfiguration:IEntityTypeConfiguration<Policlinic>
{
    public void Configure(EntityTypeBuilder<Policlinic> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.City)
            .WithMany(x => x.Policlinics)
            .HasForeignKey(x => x.CityId);
    }
}