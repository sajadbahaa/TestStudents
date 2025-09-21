using DTLayer.Entities;
using DTLayer.Entities.EntityEnums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DTLayer.Configurations
{
    public class CoursesConfigurations: IEntityTypeConfiguration<Courses>
    {

        public void Configure(EntityTypeBuilder<Courses> builder)
        {
            builder.HasKey(x => x.courseID);
            builder.Property(x => x.title).HasColumnType("nvarchar").HasMaxLength(30);
            builder.Property(x => x.description).HasColumnType("nvarchar").HasMaxLength(100);
            builder.Property(x => x.CreateAt).HasColumnType("Date");

            builder.Property(c => c.level)
            .HasConversion(
                v => (byte)v,                     // Enum → byte عند التخزين
                v => (CourseEnums)v              // byte → Enum عند التحميل
            )
            .HasColumnType("TINYINT");
            builder.
    HasOne(x => x.Items)
    .WithOne(x => x.course).HasForeignKey<Courses>(x => x.itemID);
        }
    }
}