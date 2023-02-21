using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PatientRecord.Web.Models.Appointments;

namespace PatientRecord.Web.Brokers.Storages.Configurations
{
    public class Appointments : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(app =>app.Id);

            builder.Property(app=>app.DateOfMeeting).
                IsRequired();

            builder.Property(app => app.Address)
                .HasMaxLength(250);

            builder.Property(app=>app.Doctor_Id)
                .IsRequired();
            
            builder.Property(app=>app.Patient_Id)
                .IsRequired();
        }
    }
}
