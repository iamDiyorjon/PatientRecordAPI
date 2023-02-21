using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PatientRecord.Web.Models.Appointments;
using PatientRecord.Web.Models.Doctors;

namespace PatientRecord.Web.Brokers.Storages.Configurations
{
    public class Doctors : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {

            builder.HasKey(doc => doc.Id);

            builder.HasMany<Appointment>()
                .WithOne(app => app.Doctor)
                .HasForeignKey(pa => pa.Docotor_Id);

            builder.HasIndex(pa => pa.PhoneNumber)
                .IsUnique();

            builder.Property(pa => pa.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(pa => pa.LastName)
                .HasMaxLength(50);

            builder.Property(pa => pa.Specialist)
                .HasMaxLength(50);
        }
    }
}
