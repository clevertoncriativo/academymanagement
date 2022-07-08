using academymanagement.Domain.Entities;
using academymanagement.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace academymanagement.Infra.Data.Configurations
{
    public class UserGroupConfiguration : BaseConfiguration<UserGroup>, IEntityTypeConfiguration<UserGroup>, IEntityConfiguration
    {
        public void Configure(EntityTypeBuilder<UserGroup> builder)
        {
            DefaultConfigs(builder);

            builder.HasMany(m => m.Users)
                .WithOne(w => w.UserGroup);
        }
    }
}
