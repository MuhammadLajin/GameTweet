using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.Configuration
{
    public class ReplyConfiguration : IEntityTypeConfiguration<Reply>
    {
        public void Configure(EntityTypeBuilder<Reply> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();

            builder.Property(b => b.Content).IsRequired()
                .HasMaxLength(60);
            builder.Property(b => b.UserId).IsRequired();
            builder.Property(b => b.CommentId).IsRequired();

            builder.HasOne(b => b.Comment)
                .WithMany(b => b.Reply)
                .HasForeignKey(b=>b.CommentId);
        }
    }
}
