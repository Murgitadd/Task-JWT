using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProniaOnionAlpha.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnionAlpha.Persistence.Configurations
{
    internal class AccountRolesConfiguration : IEntityTypeConfiguration<AccountRoles>
    {
        public void Configure(EntityTypeBuilder<AccountRoles> builder)
        {
            builder.Property(a => a.AuthorId).IsRequired();
            builder.Property(a => a.RoleId).IsRequired();

            builder.HasKey(k => new { k.AuthorId, k.RoleId });

            builder.HasOne(c => c.Author)
                .WithMany(a => a.AccountRoles)
                .HasForeignKey(c => c.AuthorId);

            builder.HasOne(c => c.Role)
                .WithMany(r => r.AccountRoles)
                .HasForeignKey(c => c.RoleId);

        }
    }
}
