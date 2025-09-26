using DTLayer.Entities;
using DTLayer.Entities.EntityEnums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DTLayer.Configurations
{
    public class EnrollmentsConfigurations:IEntityTypeConfiguration<Enrollments>
    {

        public void Configure(EntityTypeBuilder<Enrollments> builder)
        {
            builder.HasKey(x => x.enrollID);

            builder.
    HasOne(x => x.student)
    .WithMany(x => x.enrollment).HasForeignKey(x => x.StudnetID)
    .OnDelete(DeleteBehavior.NoAction);

            builder.Property(c => c.enrollStatus)
            .HasConversion(
                v => (byte)v,                     // Enum → byte عند التخزين
                v => (EnrollmentEnums)v              // byte → Enum عند التحميل
            )
            .HasColumnType("TINYINT");
        }
    }
}