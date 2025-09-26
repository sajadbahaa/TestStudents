using DTLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DTLayer.Configurations
{
    public class StudentsConfigurations:  IEntityTypeConfiguration<Students>
    {
        public void Configure(EntityTypeBuilder<Students> builder)
        {
            builder.HasKey(x => x.StudnetID);

            builder.
    HasOne(x => x.person)
    .WithOne(x => x.students).HasForeignKey<Students>(x => x.PersonID)
    .OnDelete(DeleteBehavior.Cascade);
        
        }
    }
}