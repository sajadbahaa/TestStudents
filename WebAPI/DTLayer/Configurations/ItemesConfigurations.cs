using DTLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DTLayer.Configurations
{
    public class ItemesConfigurations:IEntityTypeConfiguration<Items>
    {
        public void Configure(EntityTypeBuilder<Items> builder)
        {
            builder.HasKey(x => x.itemID);
            builder.Property(x => x.itemName).HasColumnType("nvarchar").HasMaxLength(30);

            builder.HasOne(x => x.specilize).WithMany(x => x.Items).HasForeignKey(x => x.specilizeID);
        }
    }
}