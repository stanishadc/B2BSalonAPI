using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using B2BSalonAPI.Models;

namespace B2BSalonAPI.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
            new IdentityRole
            {
                Name = UserRoles.Admin,
                NormalizedName = UserRoles.Admin
            },
            new IdentityRole
            {
                Name = UserRoles.Business,
                NormalizedName = UserRoles.Business
            },
            new IdentityRole
            {
                Name = UserRoles.Customer,
                NormalizedName = UserRoles.Customer
            });
        }
    }
}
