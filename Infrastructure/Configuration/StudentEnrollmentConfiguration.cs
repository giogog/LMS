using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Infrastructure.Configuration;

public class StudentEnrollmentConfiguration : IEntityTypeConfiguration<StudentEnrollment>
{
    public void Configure(EntityTypeBuilder<StudentEnrollment> builder)
    {
        builder.ToTable(nameof(StudentEnrollment));

        builder.HasKey(x => x.Id);


        builder.HasOne(se => se.Student)
            .WithMany(s => s.Enrollments)
            .HasForeignKey(se => se.StudentId)
            .IsRequired();


        builder.Property(p => p.Grades)
            .HasColumnName("Grades")
            .HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<double[]>(v)).Metadata
            .SetValueComparer(new ValueComparer<double[]>(
                (x, y) => x.SequenceEqual(y), // Compare two arrays for equality
                c => c.GetHashCode(),         // Generate hash code for the array
                c => c.ToArray()));


    }
}
