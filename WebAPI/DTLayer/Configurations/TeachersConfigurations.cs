using DTLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DTLayer.Configurations
{
    public class TeachersConfigurations: IEntityTypeConfiguration<Teachers>
    {
        public void Configure(EntityTypeBuilder<Teachers> builder)
        {
            builder.HasKey(x => x.TeacherID);
            builder.Property(x => x.hireDate).HasColumnType("Date");

            builder.
    HasOne(x => x.person)
    .WithOne(x => x.teacher).HasForeignKey<Teachers>(x => x.personID)
    .OnDelete(DeleteBehavior.Cascade);
            builder.
    HasOne(x => x.specilze)
    .WithMany(x => x.Teachers).HasForeignKey(x => x.specilzeID);

        }
    }
}
