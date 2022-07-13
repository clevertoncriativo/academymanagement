using academymanagement.Domain.Entities;
using academymanagement.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace academymanagement.Infra.Data.Configurations
{
    public class UserConfiguration : BaseConfiguration<User>, IEntityTypeConfiguration<User>, IEntityConfiguration
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            DefaultConfigs(builder);

            builder.Property(p => p.Name)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(p => p.Email)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(p => p.Password)
                .HasMaxLength(450)
                .IsRequired();

            builder.Property(p => p.IsEnabled)
                .HasColumnType("bit");

            builder.HasOne(o => o.UserGroup)
                .WithMany(x => x.Users)
                .HasForeignKey(f => f.UserGroupId)
                .IsRequired();
        }
    }
}
