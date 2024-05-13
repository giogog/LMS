using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataConnection;


public class DomainDataContext : IdentityDbContext<User, Role, int
    , IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>
    , IdentityRoleClaim<int>, IdentityUserToken<int>>
{
    public DomainDataContext(DbContextOptions<DomainDataContext> options) : base(options)
    {

    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Person>()
            .HasDiscriminator<string>("PersonType")
            .HasValue<Student>("Student")
            .HasValue<Teacher>("Teacher");



        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(
            typeof(Configuration.RoleConfiguration).Assembly
        );


    }
}
