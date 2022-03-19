using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.Configuration
{
    public class TweetConfiguration : IEntityTypeConfiguration<Tweet>
    {
        public void Configure(EntityTypeBuilder<Tweet> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();

            builder.Property(b => b.Content).IsRequired().HasMaxLength(140);
            builder.Property(b => b.UserId).IsRequired();

            builder.HasOne(b => b.User)
                .WithMany(b => b.Tweet)
                .HasForeignKey(b => b.UserId);

        }
    }
}
