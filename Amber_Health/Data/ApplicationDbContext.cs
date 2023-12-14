﻿using Amber_Health.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Amber_Health.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("dbo");
            builder.Entity<IdentityUser>(option =>
            {
                option.ToTable(name: "User");
            });
            builder.Entity<IdentityRole>(option =>
            {
                option.ToTable(name: "Role");
            });
            builder.Entity<IdentityUserRole<string>>(option =>
            {
                option.ToTable(name: "UserRoles");
            });
            builder.Entity<IdentityUserClaim<string>>(option =>
            {
                option.ToTable(name: "UserClaims");
            });
            builder.Entity<IdentityUserLogin<string>>(option =>
            {
                option.ToTable(name: "UserLogins");
            });
            builder.Entity<IdentityRoleClaim<string>>(option =>
            {
                option.ToTable(name: "RoleClaims");
            });
            builder.Entity<IdentityUserToken<string>>(option =>
            {
                option.ToTable(name: "UserTokens");
            });
        }
    }
}