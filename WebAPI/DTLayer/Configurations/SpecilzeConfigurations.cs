using DTLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTLayer.Configurations
{
    public class SpecilzeConfigurations : IEntityTypeConfiguration<Specilzeations>
    {
        public void Configure(EntityTypeBuilder<Specilzeations> builder)
        {
            builder.HasKey(x => x.specilizeId);
            builder.Property(x => x.specilizeName).HasColumnType("nvarchar").HasMaxLength(30);
        }
    }
}
