﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RentH2.Infrastructure.Repositories.Base.PostgreSQL.Configurations.Entities
{
    public class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "cac43a6e-f7bb-4448-baaf-ladd431ccbbf",
                    UserId = "408aa945-3d84-4421-8342-7269ec64d949"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "cac43a7e-f7cb-4448-baaf-labb431eabbf",
                    UserId = "208aa945-2d84-2421-2342-2269ec64d949"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "cac43a7e-f7cb-4448-baaf-labb431eabbf",
                    UserId = "208dd945-2d84-2421-2342-2269fc54d949"
                }
            );
        }
    }
}