using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Configuration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();

            builder.Property(b => b.Content).IsRequired()
                .HasMaxLength(60);
            builder.Property(b => b.UserId).IsRequired();
            builder.Property(b => b.TweetId).IsRequired();

            builder.Property(b => b.TotalReplies).HasDefaultValue(0);

            builder.HasOne(b => b.Tweet)
                .WithMany(b => b.Comment)
                .HasForeignKey(b => b.TweetId);
        }
    }
}
