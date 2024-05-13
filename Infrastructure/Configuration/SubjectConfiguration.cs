using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Infrastructure.Configuration;

public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.ToTable(nameof(Subject));

        builder.HasKey(x => x.Id);

        builder.HasMany(s => s.Seminars)
            .WithOne(s=>s.Subject)
            .HasForeignKey(s => s.SubjectId)
            .IsRequired(false);

        builder.HasMany(s => s.Lectures)
            .WithOne(l =>l.Subject)
            .HasForeignKey(s => s.SubjectId)
            .IsRequired();

        builder.Property(p => p.gradeTypes)
            .HasColumnName("gradeTypes")
            .HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<string[]>(v)).Metadata
            .SetValueComparer(new ValueComparer<string[]>(
                (x, y) => x.SequenceEqual(y), // Compare two arrays for equality
                c => c.GetHashCode(),         // Generate hash code for the array
                c => c.ToArray()));

    }
}
