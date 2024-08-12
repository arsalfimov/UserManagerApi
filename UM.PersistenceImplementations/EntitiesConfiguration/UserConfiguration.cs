using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UM.Domain;

namespace UM.PersistenceImplementations.EntitiesConfiguration;

public class UserConfiguration
: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(entity => entity.Id);
        builder.HasIndex(entity => entity.Id).IsUnique();
        builder.Property(entity => entity.Name).HasMaxLength(32);
        builder.Property(entity => entity.Email).HasMaxLength(32);
    }
}
