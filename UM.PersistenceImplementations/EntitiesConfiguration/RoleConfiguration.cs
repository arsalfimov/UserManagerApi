using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UM.Domain;

namespace UM.PersistenceImplementations.EntitiesConfiguration;

public class RoleConfiguration
: IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(entity => entity.Id);
        builder.HasIndex(entity => entity.Id).IsUnique();
        builder.Property(entity => entity.Name).HasMaxLength(32);
        builder.Property(entity => entity.Name).HasMaxLength(32);

    }
}
