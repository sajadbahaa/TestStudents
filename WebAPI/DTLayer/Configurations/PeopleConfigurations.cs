using DTLayer.Entities;
using DTLayer.Entities.EntityEnums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DTLayer.Configurations
{
    public class PeopleConfigurations:IEntityTypeConfiguration<People>
    {

        public void Configure(EntityTypeBuilder<People> builder)
        {
            builder.HasKey(x => x.PersonID);
            builder.Property(x => x.firstName).HasColumnType("nvarchar").HasMaxLength(30);
            builder.Property(x => x.secondName).HasColumnType("nvarchar").HasMaxLength(30);
            builder.Property(x => x.lastName).HasColumnType("nvarchar").HasMaxLength(30);

            builder.Property(x => x.email).HasColumnType("varchar").HasMaxLength(60);
            builder.Property(x => x.phone).HasColumnType("varchar").HasMaxLength(12);


            builder.Property(c => c.gendor)
            .HasConversion(
                v => (byte)v,                     // Enum → byte عند التخزين
                v => (PeopleEnum)v              // byte → Enum عند التحميل
            )
            .HasColumnType("TINYINT");


        }
    }
}