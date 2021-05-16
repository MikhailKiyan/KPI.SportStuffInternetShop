using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KPI.SportStuffInternetShop.Domains.Identity;

namespace KPI.SportStuffInternetShop.Data.Identities.Configurations {
    public class IdentitiesConfiguration :
            IEntityTypeConfiguration<User>,
            IEntityTypeConfiguration<Role>,
            IEntityTypeConfiguration<UserClaim>,
            IEntityTypeConfiguration<UserRole>,
            IEntityTypeConfiguration<UserLogin>,
            IEntityTypeConfiguration<RoleClaim>,
            IEntityTypeConfiguration<UserToken> {

        const string SCHEMA_NAME = "Identity";

        public void Configure(EntityTypeBuilder<User> builder) {
            builder.ToTable(nameof(User), SCHEMA_NAME)
                   .HasKey(p => p.Id);

            builder.Property(p => p.Id)
                   .HasDefaultValueSql("NEWID()");
        }

        public void Configure(EntityTypeBuilder<Role> builder) {
            builder.ToTable(nameof(Role), SCHEMA_NAME)
                   .HasKey(p => p.Id);

            builder.Property(p => p.Id)
                   .HasDefaultValueSql("NEWID()");
        }

        public void Configure(EntityTypeBuilder<UserClaim> builder) {
            builder.ToTable(nameof(UserClaim), SCHEMA_NAME)
                   .HasKey(p => p.Id);

            builder.HasOne(uc => uc.User)
                   .WithMany()
                   .HasForeignKey(uc => uc.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(uc => uc.UserId);
        }

        public void Configure(EntityTypeBuilder<UserRole> builder) {
            builder.ToTable(nameof(UserRole), SCHEMA_NAME)
                   .HasKey(ur => new { ur.UserId, ur.RoleId });

            builder.HasOne(ur => ur.Role)
                   .WithMany(r => r.UserRoles)
                   .HasForeignKey(ur => ur.RoleId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ur => ur.User)
                   .WithMany(r => r.UserRoles)
                   .HasForeignKey(ur => ur.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(ur => ur.UserId);

            builder.HasIndex(ur => ur.RoleId);
        }

        public void Configure(EntityTypeBuilder<UserLogin> builder) {
            builder.ToTable(nameof(UserLogin), SCHEMA_NAME)
                   .HasKey(p => new { p.LoginProvider, p.ProviderKey });

            builder.HasOne(ul => ul.User)
                   .WithMany()
                   .HasForeignKey(ul => ul.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(ul => ul.UserId);
        }

        public void Configure(EntityTypeBuilder<RoleClaim> builder) {
            builder.ToTable(nameof(RoleClaim), SCHEMA_NAME)
                   .HasKey(p => p.Id);

            builder.HasOne(rc => rc.Role)
                   .WithMany()
                   .HasForeignKey(rc => rc.RoleId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(rc => rc.RoleId);
        }

        public void Configure(EntityTypeBuilder<UserToken> builder) {
            builder.ToTable(nameof(UserToken), SCHEMA_NAME)
                   .HasKey(p => new { p.UserId, p.LoginProvider, p.Name });

            builder.HasOne(ut => ut.User)
                   .WithMany()
                   .HasForeignKey(ut => ut.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(ut => ut.UserId);
        }
    }
}
