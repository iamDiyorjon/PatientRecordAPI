using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PatientRecord.Web.Models.Appointments;
using PatientRecord.Web.Models.Patients;

namespace PatientRecord.Web.Brokers.Storages.Configurations
{
    public class PatientsConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(pa => pa.Id);

            builder.HasMany<Appointment>()
                .WithOne(app => app.Patient)
                .HasForeignKey(pa => pa.Patient_Id);

            builder.HasIndex(pa => pa.PhoneNumber)
                .IsUnique();

            builder.Property(pa => pa.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(pa => pa.LastName)
                .HasMaxLength(50);

            builder.Property(pa => pa.Email)
                .HasMaxLength(50);

            builder.Property(pa => pa.Password)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(pa => pa.Salt)
                .HasMaxLength(50)
                .IsRequired();   
        }
    }
}
