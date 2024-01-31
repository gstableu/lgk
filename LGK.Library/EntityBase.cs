using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace LGK.Library;

public class EntityBase
{
    public Guid Id { get; set; }

    public bool IsDeleted { get; set; }
    public DateTime Created { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime? Modified { get; set; }
    public Guid? ModifiedBy { get; set; }

}

public static class EntityFrameworkExtension
{
    public static EntityTypeBuilder<T> ApplyEntityDefault<T>(this EntityTypeBuilder<T> model) where T : EntityBase
    {

        model.HasQueryFilter(p => !p.IsDeleted);
        model.Property(x => x.Id).ValueGeneratedOnAdd().HasValueGenerator<SequentialGuidValueGenerator>();
        model.Property(x => x.Created).ValueGeneratedOnAdd().HasDefaultValue(DateTime.Now);
        model.Property(x => x.Modified).ValueGeneratedOnUpdate().HasDefaultValue(DateTime.Now);

        return model;
    }
}