using DTLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;
using System.Reflection.Emit;

namespace DTLayer.Configurations
{
    public class TeacherCourseaConfigurations : IEntityTypeConfiguration<TeacherCourses>
    {

        public void Configure(EntityTypeBuilder<TeacherCourses> builder)
        {
            builder.HasKey(x => x.TeacherCourseID);
            builder.Property(x => x.startDate).HasColumnType("Date");
            builder.Property(x => x.endDate).HasColumnType("Date");

            builder.HasOne(x => x.teacher)
            .WithMany(x => x.teacherCourses)
            .HasForeignKey(x => x.teacherID)
            .OnDelete(DeleteBehavior.Cascade); 
            
            // نخلي الكاسكيد من جهة المدرّس

            builder.HasOne(x => x.course)
                   .WithMany(x => x.teacherCourses)
                   .HasForeignKey(x => x.courseID)
                   .OnDelete(DeleteBehavior.NoAction); // نوقف الكاسكيد من جهة الكورس

            /// هنا نسوي Unique Constraint
builder
    .HasIndex(tc => new { tc.teacherID, tc.courseID})
    .IsUnique();
        }
    }
}