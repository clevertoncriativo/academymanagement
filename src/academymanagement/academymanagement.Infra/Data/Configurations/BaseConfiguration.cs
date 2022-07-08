using academymanagement.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace academymanagement.Infra.Data.Configurations
{
    public class BaseConfiguration<T> where T : EntityBase
    {
        public void DefaultConfigs(EntityTypeBuilder<T> builder, string tableName = null)
        {
            builder.ToTable(tableName ?? typeof(T).Name);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreatedBy)
                   .HasMaxLength(250)
                    .IsRequired();

            builder.Property(x => x.ModifiedBy)
                   .HasMaxLength(250);
        }
    }
}
