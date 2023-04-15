using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDAL.Entites;

namespace UserDAL
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.FirstName).HasMaxLength(30);

            builder.Property(x => x.LastName).HasMaxLength(50);

            builder.Property(x => x.Password).HasMaxLength(50);

            builder.HasIndex(x => x.UserName).IsUnique();

            builder.HasIndex(x => x.Email).IsUnique();

        }
    }
}
