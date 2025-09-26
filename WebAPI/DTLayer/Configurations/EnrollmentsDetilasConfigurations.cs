using DTLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DTLayer.Configurations
{
    public class EnrollmentsDetilasConfigurations : IEntityTypeConfiguration<EnrollmentDetials>
    {

        public void Configure(EntityTypeBuilder<EnrollmentDetials> builder)
        {
            builder.HasKey(x => x.enrollDetialsID);


            builder.HasOne(x => x.enrollment)
                   .WithMany(x => x.enrollmentDetials)
                   .HasForeignKey(x => x.enrollID)
                   .OnDelete(DeleteBehavior.Cascade); // مسار واحد مسموح فقط

            builder.HasOne(x => x.TeacherCourse)
                   .WithMany(x => x.enrollmentDetials)
                   .HasForeignKey(x => x.TeacherCourseID)
                   .OnDelete(DeleteBehavior.NoAction); // لا تحذف تلقائياً
            builder
    .HasIndex(tc => new { tc.TeacherCourseID, tc.enrollID })
    .IsUnique();
        }
    }
    }
