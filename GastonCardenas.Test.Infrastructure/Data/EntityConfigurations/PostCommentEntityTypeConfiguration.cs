using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GastonCardenas.Test.Domain.Posts;

namespace GastonCardenas.Test.Infrastructure.Data.EntityConfigurations
{
    class PostCommentEntityTypeConfiguration : IEntityTypeConfiguration<PostComment>
    {
        public void Configure(EntityTypeBuilder<PostComment> entityConfiguration)
        {
            entityConfiguration.ToTable("PostComment");
            entityConfiguration.HasKey(t => t.PostCommentId);
            entityConfiguration.Property(t => t.PostCommentId).ValueGeneratedOnAdd();
            entityConfiguration.Property(t => t.CreationtDate).IsRequired(true);
            entityConfiguration.Property(t => t.PostId).IsRequired(true);
            entityConfiguration.Property(t => t.AuthorName).IsRequired(true).HasMaxLength(100);
            entityConfiguration.Property(t => t.AuthorEmail).IsRequired(true).HasMaxLength(100);
            entityConfiguration.Property(t => t.Comment).IsRequired(true).HasMaxLength(4000);

        }
    }
}
